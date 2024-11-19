

using Readio.Core.Exceptions;
using Readio.Model.Comment.Entity;
using Readio.Service.Constants;

namespace Readio.Service.Comment.Rules;

public class CommentBusinessRules
{
    public void CheckIfCommentExists(CommentEntity? comment)
    {
        if (comment is null)
        {
            throw new NotFoundException(Messages.CommentNotFoundMessage);
        }
    }
}
