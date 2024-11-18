
using Readio.Core.Model.Entity;

namespace Readio.Model.Genre.Entity;

public sealed class GenreEntity : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
