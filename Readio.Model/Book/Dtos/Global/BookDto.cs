
namespace Readio.Model.Book.Dtos.Global;

public sealed record BookDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    public BookDto() { }

    public BookDto(Guid id, string title, string description, DateTime createdAt,DateTime updatedAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
    
