using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Member.Dtos.Create.Request;
using Readio.Model.Member.Dtos.Update;
using Readio.Service.Member.Abstracts;

namespace Readio.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController(IMemberService memberService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllMembers() => Ok(await memberService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMemberById([FromRoute] int id) => Ok(await memberService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest request) => Ok(await memberService
    .CreateAsync(request));

    [HttpPut]
    public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberRequest request) =>
    Ok(await memberService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMember([FromRoute] int id) => Ok(await memberService.DeleteAsync(id));
}
