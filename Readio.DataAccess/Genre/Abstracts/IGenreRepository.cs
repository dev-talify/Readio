
using Readio.Core.Repository.Abstract;
using Readio.Model.Genre.Entity;

namespace Readio.DataAccess.Genre.Abstracts;

public interface IGenreRepository : IGenericRepository<GenreEntity, int>
{

}
