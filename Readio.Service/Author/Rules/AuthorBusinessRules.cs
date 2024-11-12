

using Microsoft.EntityFrameworkCore;
using Readio.Core.Exceptions;
using Readio.DataAccess.Author.Abstracts;
using Readio.DataAccess.Author.Concretes;
using Readio.Model.Author.Entity;
using Readio.Service.Constants;

namespace Readio.Service.Author.Rules;

public class AuthorBusinessRules
{
    public void  CheckIfAuthorNameExists(bool anyAuthor)
    {
        if (anyAuthor)
        {
            throw new BusinessException(Messages.AuthorNameAlreadyExistMessage);
        }
    }

    public void CheckIfAuthorExists(AuthorEntity? author)
    {   
        if (author is null)
        {
            throw new NotFoundException(Messages.AuthorNotFoundMessage);
        }
    }

}
