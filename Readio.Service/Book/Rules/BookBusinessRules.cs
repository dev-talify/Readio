

using Readio.Core.Exceptions;
using Readio.Model.Author.Entity;
using Readio.Model.Book.Entity;
using Readio.Service.Constants;

namespace Readio.Service.Book.Rules;

public class BookBusinessRules
{
    public void CheckIfBookNameExists(bool anyBook)
    {
        if (anyBook)
        {
            throw new BusinessException(Messages.BookNameAlreadyExistMessage);
        }
    }

    public void CheckIfBookExists(BookEntity? book)
    {
        if (book is null)
        {
            throw new NotFoundException(Messages.BookNotFoundMessage);
        }
    }
}
