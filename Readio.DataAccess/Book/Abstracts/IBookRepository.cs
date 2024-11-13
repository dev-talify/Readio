

using Readio.Core.Repository.Abstract;
using Readio.Model.Book.Entity;

namespace Readio.DataAccess.Book.Abstracts;

public interface IBookRepository : IGenericRepository<BookEntity,Guid>
{

}
