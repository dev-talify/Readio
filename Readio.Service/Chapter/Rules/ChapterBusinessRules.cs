
using Readio.Core.Exceptions;
using Readio.Model.Chapter.Entity;
using Readio.Service.Constants;

namespace Readio.Service.Chapter.Rules;

public class ChapterBusinessRules
{
    public void CheckIfChapterExists(ChapterEntity? chapter)
    {
        if (chapter is null)
        {
            throw new NotFoundException(Messages.ChapterNotFoundMessage);
        }
    }
}
