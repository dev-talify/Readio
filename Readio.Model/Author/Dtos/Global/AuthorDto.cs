

namespace Readio.Model.Author.Dtos.Global;

public sealed record AuthorDto(
    int Id,
    string Name,
    string? Bio,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );

