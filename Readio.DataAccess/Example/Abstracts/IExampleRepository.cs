

using Readio.Core.Repository.Abstract;
using Readio.Model.Example.Entity;

namespace Readio.DataAccess.Example.Abstracts;

public interface IExampleRepository : IGenericRepository<ExampleEntity,int>
{

}
