namespace Readio.Model.Comment.Dtos.Create.Request;

public sealed record CreateCommentRequest
   (
       string Content,   
       Guid BookId,      
       int MemberId      
   );

