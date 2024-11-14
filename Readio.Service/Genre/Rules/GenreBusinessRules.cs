

using Readio.Core.Exceptions;
using Readio.Model.Genre.Entity;
using Readio.Service.Constants;

namespace Readio.Service.Genre.Rules;

public class GenreBusinessRules
{
    public void CheckIfGenreNameExists(bool anyGenre)
    {
        if (anyGenre)
        {
            throw new BusinessException(Messages.GenreNameAlreadyExistMessage);
        }
    }

    public void CheckIfGenreExists(GenreEntity? genre)
    {
        if (genre is null)
        {
            throw new NotFoundException(Messages.GenreNotFoundMessage);
        }
    }

    internal void CheckIfGenreNameExists(object anyGenre)
    {
        throw new NotImplementedException();
    }
}
