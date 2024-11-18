using Microsoft.AspNetCore.Identity;
using Readio.Core.Model.Entity;

namespace Readio.Model.User.Entity;

public class UserEntity : IdentityUser, IAuditEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
