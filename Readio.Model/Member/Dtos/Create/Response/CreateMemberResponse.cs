
namespace Readio.Model.Member.Dtos.Create.Response;

public sealed record CreateMemberResponse(
    int Id,
    string FirstName,
    string LastName,
    string ProfilePicture,
    DateTime CreatedAt
    );
