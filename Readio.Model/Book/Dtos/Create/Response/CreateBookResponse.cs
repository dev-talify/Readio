namespace Readio.Model.Book.Dtos.Create.Response;

public sealed record CreateBookResponse(
    Guid Id,
    string Title,
    string Description,
    DateTime CreatedAt
    );

