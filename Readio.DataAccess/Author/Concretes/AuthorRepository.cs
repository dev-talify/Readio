

using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Author.Abstracts;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Example.Abstracts;
using Readio.Model.Author.Entity;
using Readio.Model.Example.Entity;

namespace Readio.DataAccess.Author.Concretes;

public class AuthorRepository(AppDbContext context) : GenericRepository<AppDbContext, AuthorEntity, int>(context), IAuthorRepository
{

}
