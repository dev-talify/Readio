
using Readio.Core.Repository.Abstract;
using Readio.Model.User.Token;

namespace Readio.Service.Token.Abstracts;

public interface IUserRefreshTokenService : IGenericRepository<UserRefreshToken,string>
{
}
