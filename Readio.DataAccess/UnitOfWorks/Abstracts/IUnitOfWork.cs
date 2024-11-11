

namespace Readio.DataAccess.UnitOfWorks.Abstracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
