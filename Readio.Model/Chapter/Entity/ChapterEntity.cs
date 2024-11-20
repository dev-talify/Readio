using Readio.Core.Model.Entity;
using Readio.Model.Book.Entity;

namespace Readio.Model.Chapter.Entity;

public class ChapterEntity : BaseEntity<int>, IAuditEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int ChapterNumber { get; set; }
    public Guid BookId { get; set; }
    public BookEntity Book { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
