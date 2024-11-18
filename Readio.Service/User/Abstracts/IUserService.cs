

using Readio.Core.Model.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.User.Dtos.Create;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Dtos.Update;

namespace Readio.Service.User.Abstracts;

public interface IUserService
{
    Task<OperationResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
    Task<OperationResponse<UserDto>> GetUserByNameAsync(string userName);
    Task<OperationResponse> CreateUserRolesAsync(string userName ,List<string> roles);
    Task<OperationResponse<List<UserDto>>> GetAllAsync();
    Task<OperationResponse<UserDto>> GetByIdAsync(string id);
    Task<OperationResponse> UpdateAsync(string id,UpdateUserRequest request);
    Task<OperationResponse> DeleteAsync(string id);
}
