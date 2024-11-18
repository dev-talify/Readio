
using Readio.Core.Model.Response;
using Readio.Model.Genre.Dtos.Create.Request;
using Readio.Model.Genre.Dtos.Create.Response;
using Readio.Model.Genre.Dtos.Global;
using Readio.Model.Genre.Dtos.Update;

namespace Readio.Service.Genre.Abstracts;

public interface IGenreService
{
    Task<OperationResponse<List<GenreDto>>> GetAllAsync();
    Task<OperationResponse<GenreDto>> GetByIdAsync(int id);
    Task<OperationResponse<CreateGenreResponse>> CreateAsync(CreateGenreRequest request);
    Task<OperationResponse> UpdateAsync(UpdateGenreRequest request);
    Task<OperationResponse> DeleteAsync(int id);
}
