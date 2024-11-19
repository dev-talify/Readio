namespace Readio.Model.Comment.Dtos.Create.Response;

public sealed record CreateCommentResponse(
        int Id,             
        string Content,     
        DateTime CreatedAt, 
        string BookTitle,       
        string MemberFirstName,
        string MemberLastName
    );

