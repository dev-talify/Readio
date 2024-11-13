

using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Book.Abstracts;
using Readio.DataAccess.Contexts;
using Readio.Model.Book.Entity;

namespace Readio.DataAccess.Book.Concretes;

public class BookRepository(AppDbContext context) : GenericRepository<AppDbContext,BookEntity,Guid>(context),IBookRepository
{
}
