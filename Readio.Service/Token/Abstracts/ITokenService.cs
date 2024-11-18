

using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Entity;

namespace Readio.Service.Token.Abstracts;

public interface ITokenService
{
    Task<TokenDto> CreateTokenAsync(UserEntity user);
}
