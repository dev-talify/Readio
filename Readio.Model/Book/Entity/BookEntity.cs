


using Readio.Core.Model.Entity;
using Readio.Model.Author.Entity;
using Readio.Model.Genre.Entity;

namespace Readio.Model.Book.Entity;

public sealed class BookEntity : BaseEntity<Guid>, IAuditEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AuthorEntityId { get; set; }
    public AuthorEntity Author { get; set; }
    public List<GenreEntity> Genres { get; set; }
}
