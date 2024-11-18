
using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Member.Abstracts;
using Readio.Model.Member.Entity;

namespace Readio.DataAccess.Member.Concretes;

public class MemberRepository(AppDbContext context) : GenericRepository<AppDbContext, MemberEntity, int>(context), IMemberRepository
{

}
