


using Readio.Core.Model.Entity;

namespace Readio.Model.Book.Entity;

public sealed class BookEntity : BaseEntity<Guid>, IAuditEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // navigation proplar author genre bittikten sonra
}
