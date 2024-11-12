
using Readio.Core.Model.Response;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;

namespace Readio.Service.Author.Abstracts;

public interface IAuthorService
{
    Task<OperationResponse<List<AuthorDto>>> GetAllAsync();
    Task<OperationResponse<AuthorDto>> GetByIdAsync(int id);
    Task<OperationResponse<CreateAuthorResponse>> CreateAsync (CreateAuthorRequest request);
    Task<OperationResponse> UpdateAsync(UpdateAuthorRequest request);
    Task<OperationResponse> DeleteAsync(int id);


}
