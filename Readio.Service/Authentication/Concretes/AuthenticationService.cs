

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Readio.Core.Model.Response;
using Readio.Core.Repository.Abstract;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Dtos.Login;
using Readio.Model.User.Entity;
using Readio.Model.User.Token;
using Readio.Service.Authentication.Abstracts;
using Readio.Service.Token.Abstracts;
using System.Net;
using IAuthenticationService = Readio.Service.Authentication.Abstracts.IAuthenticationService;

namespace Readio.Service.Authentication.Concretes;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<UserEntity> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRefreshTokenService _userRefreshTokenService;
    public AuthenticationService(ITokenService tokenService, UserManager<UserEntity> userManager, IUnitOfWork unitOfWork, IUserRefreshTokenService userRefreshTokenService)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _userRefreshTokenService = userRefreshTokenService;
    }

    public async Task<OperationResponse<TokenDto>> CreateTokenAsync(LoginDto loginDto)
    {
        if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return OperationResponse<TokenDto>.Fail("Email veya  Password yanlış", HttpStatusCode.BadRequest);
        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return OperationResponse<TokenDto>.Fail("Email veya Password yanlış", HttpStatusCode.BadRequest);
        }
        var token =await _tokenService.CreateTokenAsync(user);
        var userRefreshToken = await _userRefreshTokenService.Find(x => x.Id == user.Id).SingleOrDefaultAsync();
        if (userRefreshToken == null)
        {
            await _userRefreshTokenService.AddAsync(new UserRefreshToken { Id = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
        }
        else
        {
            userRefreshToken.Code = token.RefreshToken;
            userRefreshToken.Expiration = token.RefreshTokenExpiration;
        }
        await _unitOfWork.SaveChangesAsync();
        return OperationResponse<TokenDto>.Success(token,"Token oluşturuldu",HttpStatusCode.OK);
    }

    public async Task<OperationResponse<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userRefreshTokenService.Find(x => x.Code == refreshToken).SingleOrDefaultAsync();
        if (existRefreshToken == null)
        {
            return OperationResponse<TokenDto>.Fail("Refresh token bulunamadı", HttpStatusCode.NotFound);
        }
        var user = await _userManager.FindByIdAsync(existRefreshToken.Id);
        if (user == null)
        {
            return OperationResponse<TokenDto>.Fail("User Id bulunamadı", HttpStatusCode.NotFound);
        }
        var tokenDto =await _tokenService.CreateTokenAsync(user);
        existRefreshToken.Code = tokenDto.RefreshToken;
        existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
        await _unitOfWork.SaveChangesAsync();
        return OperationResponse<TokenDto>.Success(tokenDto, "Refresh token oluşturuldu." ,HttpStatusCode.OK);
    }

    public async Task<OperationResponse> RevokeRefreshToken(string refreshToken)
    {
        var existRefreshToken = await _userRefreshTokenService.Find(x => x.Code == refreshToken).SingleOrDefaultAsync();
        if (existRefreshToken == null)
        {
            return OperationResponse.Fail("Refresh token bulunamadı", HttpStatusCode.NotFound);
        }
        _userRefreshTokenService.Delete(existRefreshToken);
        await _unitOfWork.SaveChangesAsync();
        return OperationResponse.Success("Refresh token silindi.",HttpStatusCode.OK);
    }
}
