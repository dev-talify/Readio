

namespace Readio.Model.Member.Dtos.Global;

public sealed record MemberDto(
    int Id,
    string FirstName,
    string LastName,
    string? ProfilePicture,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
