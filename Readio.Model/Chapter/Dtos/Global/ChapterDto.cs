namespace Readio.Model.Chapter.Dtos.Global;

public sealed record ChapterDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    Guid BookId
);
