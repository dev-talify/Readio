

namespace Readio.Model.Genre.Dtos.Global;

public sealed record GenreDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    public GenreDto() { }
    public GenreDto(int id, string name, DateTime createdAt, DateTime updatedAt) 
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

}
