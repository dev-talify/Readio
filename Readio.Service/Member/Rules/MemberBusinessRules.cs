

using Readio.Core.Exceptions;
using Readio.Model.Member.Entity;
using Readio.Service.Constants;
using System.Security.Cryptography.X509Certificates;

namespace Readio.Service.Member.Rules;

public class MemberBusinessRules
{
    public void CheckIfMemberNameExists(bool anyMember)
    {
        if (anyMember)
        {
            throw new BusinessException(Messages.MemberNameAlreadyExistMessage);
        }
    }

    public void CheckIfMemberExists(MemberEntity? member)
    {
        if (member is null)
        {
            throw new NotFoundException(Messages.MemberNotFoundMessage);
        }
    }
}
