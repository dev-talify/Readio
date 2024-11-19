

using Readio.Core.Repository.Concrete;
using Readio.DataAccess.Comment.Abstracts;
using Readio.DataAccess.Contexts;
using Readio.Model.Comment.Entity;

namespace Readio.DataAccess.Comment.Concretes;

public class CommentRepository(AppDbContext context) : GenericRepository<AppDbContext,CommentEntity,int>(context),ICommentRepository
{

}
