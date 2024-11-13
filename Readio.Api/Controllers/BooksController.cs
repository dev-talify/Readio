using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Book.Dtos.Create.Request;
using Readio.Model.Book.Dtos.Update;
using Readio.Service.Author.Concretes;
using Readio.Service.Book.Abstracts;

namespace Readio.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBookService bookService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllBooks() => Ok(await bookService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBookById([FromRoute] Guid id) => Ok(await bookService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request) => Ok(await bookService
    .CreateAsync(request));
    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request) =>
    Ok(await bookService.UpdateAsync(request));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook([FromRoute] Guid id) => Ok(await bookService.DeleteAsync(id));
}
