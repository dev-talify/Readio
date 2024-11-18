using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Dtos.Login;
using Readio.Service.Authentication.Abstracts;

namespace Readio.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateToken(LoginDto loginDto) => Ok(await authenticationService.CreateTokenAsync(loginDto));

    [HttpPost]
    public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto) => Ok(await authenticationService.RevokeRefreshToken(refreshTokenDto.Token));


    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto) => Ok(await authenticationService
        .CreateTokenByRefreshToken(refreshTokenDto.Token));
}
