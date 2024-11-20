namespace Readio.Model.Chapter.Dtos.Create.Request;

public sealed record CreateChapterRequest
(
    string Title,
    string Content,
    Guid BookId
);
