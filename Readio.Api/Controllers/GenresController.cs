using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Genre.Dtos.Create.Request;
using Readio.Model.Genre.Dtos.Update;
using Readio.Service.Genre.Abstracts;

namespace Readio.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController(IGenreService genreService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllGenres() => Ok(await genreService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGenreById([FromRoute] int id) => Ok(await genreService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequest requst) => Ok(await genreService
    .CreateAsync(requst));

    [HttpPut]
    public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequest request) => Ok(await genreService
    .UpdateAsync(request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGenre([FromRoute] int id) => Ok(await genreService.DeleteAsync(id));
}
