

using Readio.Core.Model.Entity;

namespace Readio.Model.User.Token;

public class UserRefreshToken : BaseEntity<string>
{
    public string Code { get; set; }
    public DateTime Expiration { get; set; }
}
