
namespace Readio.Model.Comment.Dtos.Global;

public sealed record CommentDto(
       int Id,
       string Content,
       DateTime CreatedAt,
       DateTime UpdatedAt,
       Guid BookId,
       int MemberId
       );

