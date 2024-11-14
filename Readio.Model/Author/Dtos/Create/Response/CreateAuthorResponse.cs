

namespace Readio.Model.Author.Dtos.Create.Response;

public sealed record CreateAuthorResponse(
    int Id,
    string Name,
    string? Bio,
    DateTime CreatedAt
    );

