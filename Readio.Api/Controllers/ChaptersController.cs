using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Chapter.Dtos.Create.Request;
using Readio.Model.Chapter.Dtos.Update;
using Readio.Service.Chapter.Abstracts;

namespace Readio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController(IChapterService chapterServices) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateChapterRequest request) => Ok(await chapterServices.CreateAsync(request));
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) => Ok(await chapterServices.DeleteAsync(id));


        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await chapterServices.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await chapterServices.GetByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateChapterRequest request) => Ok(await chapterServices.UpdateAsync(request));
    }
}
