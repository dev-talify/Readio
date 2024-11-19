using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Readio.Model.Comment.Dtos.Create.Request;
using Readio.Model.Comment.Dtos.Update;
using Readio.Service.Comment.Abstracts;
using Readio.Service.Comment.Concretes;
using System.Net;

namespace Readio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController(ICommentService commentServices) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCommentRequest request) => Ok(await commentServices.CreateAsync(request));
        

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) => Ok(await commentServices.DeleteAsync(id));

        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await commentServices.GetAllAsync());
        

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await commentServices.GetByIdAsync(id));
        

        
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCommentRequest request) => Ok(await commentServices.UpdateAsync(request));
        
    }
}
