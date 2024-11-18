
namespace Readio.Model.User.Dtos.Create;

public sealed record CreateUserDto 
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}


