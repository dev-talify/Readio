﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Readio.Core.Token;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Readio.Service.Token.Abstracts; 


namespace Readio.Service.Token.Concretes;

public class TokenService : ITokenService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly CustomTokenOption _tokenOption;
    public TokenService(UserManager<UserEntity> userManager, IOptions<CustomTokenOption> options)
    {
        _userManager = userManager;
        _tokenOption = options.Value;
    }
    public async Task<TokenDto> CreateTokenAsync(UserEntity user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
        var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
        var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claims = await GetClaims(user, _tokenOption.Audience);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOption.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: claims, 
            signingCredentials: signingCredentials);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);

        var tokenDto = new TokenDto(
            AccessToken: token,
            AccessTokenExpiration: accessTokenExpiration,
            RefreshToken: CreateRefreshToken(),
            RefreshTokenExpiration: refreshTokenExpiration
        );

        return tokenDto;
    }


    // refresh token üretecek
    private string CreateRefreshToken()
    {
        var numberByte = new byte[32];
        using var rnd = RandomNumberGenerator.Create();
        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }
    private async Task<IEnumerable<Claim>> GetClaims(UserEntity user, List<String> audiences)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        var userList = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

        userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        userList.AddRange(userRoles.Select(x=> new Claim(ClaimTypes.Role,x)));

        return userList;
    }

}