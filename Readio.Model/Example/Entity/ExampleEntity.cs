
using Readio.Core.Model.Entity;

namespace Readio.Model.Example.Entity;

public class ExampleEntity : BaseEntity<int>, IAuditEntity
{
    public string? MyExampleProperty { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
