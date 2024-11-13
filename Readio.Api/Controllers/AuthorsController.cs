using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Dtos.Update;
using Readio.Service.Author.Abstracts;
using Readio.Service.Example.Concretes;

namespace Readio.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(IAuthorService authorService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors() => Ok(await authorService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorById([FromRoute] int id) => Ok(await authorService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequest request) => Ok(await authorService
    .CreateAsync(request));
    [HttpPut]
    public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorRequest request) =>
    Ok(await authorService.UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int id) => Ok(await authorService.DeleteAsync(id));
}
