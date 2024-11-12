

using Readio.Core.Repository.Abstract;
using Readio.Model.Author.Entity;

namespace Readio.DataAccess.Author.Abstracts;

public interface IAuthorRepository : IGenericRepository<AuthorEntity,int>
{

}
