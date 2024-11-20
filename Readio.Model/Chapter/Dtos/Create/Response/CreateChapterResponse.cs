namespace Readio.Model.Chapter.Dtos.Create.Response;

public sealed record CreateChapterResponse(
    int Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    string BookTitle
);

