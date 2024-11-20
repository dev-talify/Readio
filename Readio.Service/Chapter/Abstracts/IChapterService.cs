using Readio.Core.Model.Response;
using Readio.Model.Chapter.Dtos.Create.Request;
using Readio.Model.Chapter.Dtos.Create.Response;
using Readio.Model.Chapter.Dtos.Global;
using Readio.Model.Chapter.Dtos.Update;

namespace Readio.Service.Chapter.Abstracts;

public interface IChapterService
{
    Task<OperationResponse<List<ChapterDto>>> GetAllAsync();
    Task<OperationResponse<ChapterDto>> GetByIdAsync(int id);
    Task<OperationResponse<CreateChapterResponse>> CreateAsync(CreateChapterRequest request);
    Task<OperationResponse> UpdateAsync(UpdateChapterRequest request);
    Task<OperationResponse> DeleteAsync(int id);
}
