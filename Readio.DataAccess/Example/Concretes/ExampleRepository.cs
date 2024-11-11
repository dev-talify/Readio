

using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Contexts;
using Readio.DataAccess.Example.Abstracts;
using Readio.Model.Example.Entity;

namespace Readio.DataAccess.Example.Concretes;

public class ExampleRepository(AppDbContext context) : GenericRepository<AppDbContext, ExampleEntity, int>(context), IExampleRepository
{

}
