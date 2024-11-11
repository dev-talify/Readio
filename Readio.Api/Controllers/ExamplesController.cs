using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Dtos.Update;
using Readio.Service.Example.Abstract;

namespace Readio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController(IExampleService exampleService) : ControllerBase
    {
        //controller oluştururken entity adının sonuna s eklenir.

        [HttpGet]
        public async Task<IActionResult> GetAllExamples() => Ok(await exampleService.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExampleById([FromRoute] int id) => Ok(await exampleService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateExample([FromBody] CreateExampleRequest request) => Ok(await exampleService
        .CreateAsync(request));
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateExample([FromRoute] int id, [FromBody] UpdateExampleRequest request) =>
        Ok(await exampleService.UpdateAsync(id, request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id) => Ok(await exampleService.DeleteAsync(id));

    }
}
