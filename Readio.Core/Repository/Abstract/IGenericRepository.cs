using System.Linq.Expressions;
using Readio.Core.Model.Entity;

namespace Readio.Core.Repository.Abstract;

public interface IGenericRepository<TEntity, in TId> where TEntity : BaseEntity<TId>, new()
{
    IQueryable<TEntity> GetAll();
    ValueTask<TEntity?> GetByIdAsync(TId id);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? predicate = null);
    ValueTask AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}