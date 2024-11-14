
using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Genre.Abstracts;
using Readio.Model.Genre.Entity;

namespace Readio.DataAccess.Genre.Concretes;

public class GenreRepository(AppDbContext context) : GenericRepository<AppDbContext, GenreEntity, int>(context),IGenreRepository
{

}
