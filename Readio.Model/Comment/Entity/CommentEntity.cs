

using Readio.Core.Model.Entity;
using Readio.Model.Book.Entity;
using Readio.Model.Member.Entity;

namespace Readio.Model.Comment.Entity;

public class CommentEntity : BaseEntity<int>,IAuditEntity
{
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }
    public int MemberId { get; set; }
    public MemberEntity Member { get; set; }
}
