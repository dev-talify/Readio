using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.User.Dtos.Create;
using Readio.Model.User.Dtos.Update;
using Readio.Service.User.Abstracts;
using Readio.Service.User.Concretes;

namespace Readio.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
       => Ok(await userService.CreateUserAsync(createUserDto));

    [Authorize]
    [HttpGet("username")]
    public async Task<IActionResult> GetUser()
    {
        var userName = HttpContext.User.Identity?.Name;
        if (string.IsNullOrEmpty(userName))
        {
            return NotFound("Kullanıcı adı bulunamadı.");
        }
        return Ok(await userService.GetUserByNameAsync(userName));
    }

    [Authorize(Roles = "admin,superadmin")]
    [HttpPost("CreateUserRoles/{userName}")]
    public async Task<IActionResult> CreateUserRoles(string userName, [FromBody] List<string> roles) => Ok(await userService
        .CreateUserRolesAsync(userName, roles));
    

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
        => Ok(await userService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
        => Ok(await userService.GetByIdAsync(id));

    [Authorize(Roles = "admin,superadmin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] string id)
        => Ok(await userService.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] UpdateUserRequest request)
        => Ok(await userService.UpdateAsync(id, request));


}
