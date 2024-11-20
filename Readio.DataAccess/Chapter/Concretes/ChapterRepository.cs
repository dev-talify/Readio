
using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Chapter.Abstracts;
using Readio.DataAccess.Contexts;
using Readio.Model.Chapter.Entity;

namespace Readio.DataAccess.Chapter.Concretes;

public class ChapterRepository(AppDbContext context) : GenericRepository<AppDbContext, ChapterEntity, int>(context),IChapterRepository
{

}
