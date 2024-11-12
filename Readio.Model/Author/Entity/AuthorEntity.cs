

using Readio.Core.Model.Entity;

namespace Readio.Model.Author.Entity;

public sealed class AuthorEntity : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public string? Bio { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
