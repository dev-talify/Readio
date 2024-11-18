

using Readio.Core.Model.Response;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Dtos.Login;

namespace Readio.Service.Authentication.Abstracts;

public interface IAuthenticationService
{
    Task<OperationResponse<TokenDto>> CreateTokenAsync(LoginDto loginDto);
    Task<OperationResponse<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
    Task<OperationResponse> RevokeRefreshToken(string refreshToken);
}
