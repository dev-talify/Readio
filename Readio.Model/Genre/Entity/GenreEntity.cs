
using Readio.Core.Model.Entity;
using Readio.Model.Book.Entity;

namespace Readio.Model.Genre.Entity;

public sealed class GenreEntity : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<BookEntity> Books { get; set; }
}
