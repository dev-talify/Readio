

using Readio.Core.Model.Response;
using Readio.Model.Book.Dtos.Create.Request;
using Readio.Model.Book.Dtos.Create.Response;
using Readio.Model.Book.Dtos.Global;
using Readio.Model.Book.Dtos.Update;
using Readio.Model.Comment.Dtos.Create.Request;
using Readio.Model.Comment.Dtos.Create.Response;
using Readio.Model.Comment.Dtos.Global;
using Readio.Model.Comment.Dtos.Update;

namespace Readio.Service.Comment.Abstracts;

public interface ICommentService 
{
    Task<OperationResponse<List<CommentDto>>> GetAllAsync();
    Task<OperationResponse<CommentDto>> GetByIdAsync(int id);
    Task<OperationResponse<CreateCommentResponse>> CreateAsync(CreateCommentRequest request);
    Task<OperationResponse> UpdateAsync(UpdateCommentRequest request);
    Task<OperationResponse> DeleteAsync(int id);
}
