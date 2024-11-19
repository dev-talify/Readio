

using Readio.Core.Repository.Abstract;
using Readio.Model.Comment.Entity;

namespace Readio.DataAccess.Comment.Abstracts;

public interface ICommentRepository : IGenericRepository<CommentEntity,int>
{

}
