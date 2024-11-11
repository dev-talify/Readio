

using Readio.Core.Model.Response;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Dtos.Global;
using Readio.Model.Example.Dtos.Update;

namespace Readio.Service.Example.Abstract;

public interface IExampleService
{
    Task<OperationResponse<List<ExampleDto>>> GetAllAsync();
    Task<OperationResponse<ExampleDto>>GetByIdAsync(int id);
    Task<OperationResponse<CreateExampleResponse>> CreateAsync(CreateExampleRequest request);
    Task<OperationResponse> UpdateAsync (int id , UpdateExampleRequest request);
    Task<OperationResponse> DeleteAsync (int id);

}
