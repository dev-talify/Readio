

using Readio.Core.Model.Response;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Book.Dtos.Create.Request;
using Readio.Model.Book.Dtos.Create.Response;
using Readio.Model.Book.Dtos.Global;
using Readio.Model.Book.Dtos.Update;

namespace Readio.Service.Book.Abstracts;

public interface IBookService
{
    Task<OperationResponse<List<BookDto>>> GetAllAsync();
    Task<OperationResponse<BookDto>> GetByIdAsync(Guid id);
    Task<OperationResponse<CreateBookResponse>> CreateAsync(CreateBookRequest request);
    Task<OperationResponse> UpdateAsync(UpdateBookRequest request);
    Task<OperationResponse> DeleteAsync(Guid id);
}
