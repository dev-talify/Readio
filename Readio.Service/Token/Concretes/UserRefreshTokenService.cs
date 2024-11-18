

using Readio.Core.Repository.Abstract;
using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Contexts;
using Readio.Model.User.Token;
using Readio.Service.Token.Abstracts;
using System.Linq.Expressions;

namespace Readio.Service.Token.Concretes;

public class UserRefreshTokenService(AppDbContext context) : GenericRepository<AppDbContext, UserRefreshToken, string>(context), IUserRefreshTokenService
{
    
}
