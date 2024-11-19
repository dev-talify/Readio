
using Readio.Core.Model.Entity;
using Readio.Model.Comment.Entity;

namespace Readio.Model.Member.Entity;

public sealed class MemberEntity : BaseEntity<int>, IAuditEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<CommentEntity> Comments { get; set; }

    // userid eklenecek !!
}
