

using Readio.DataAccess.Contexts;
using Readio.DataAccess.UnitOfWorks.Abstracts;

namespace Readio.DataAccess.UnitOfWorks.Concretes;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}
