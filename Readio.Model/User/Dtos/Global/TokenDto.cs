

namespace Readio.Model.User.Dtos.Global;

public sealed record TokenDto(string AccessToken, DateTime AccessTokenExpiration, string RefreshToken, DateTime RefreshTokenExpiration);

