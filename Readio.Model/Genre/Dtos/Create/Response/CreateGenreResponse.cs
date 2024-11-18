
namespace Readio.Model.Genre.Dtos.Create.Response;

public sealed record CreateGenreResponse(
    int Id,
    string Name,
    DateTime CreatedAt
    );

