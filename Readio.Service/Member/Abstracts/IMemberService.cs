
using Readio.Core.Model.Response;
using Readio.Model.Member.Dtos.Create.Request;
using Readio.Model.Member.Dtos.Create.Response;
using Readio.Model.Member.Dtos.Global;
using Readio.Model.Member.Dtos.Update;

namespace Readio.Service.Member.Abstracts;

public interface IMemberService
{
    Task<OperationResponse<List<MemberDto>>> GetAllAsync();
    Task<OperationResponse<MemberDto>> GetByIdAsync(int id);
    Task<OperationResponse<CreateMemberResponse>> CreateAsync(CreateMemberRequest request);
    Task<OperationResponse> UpdateAsync(UpdateMemberRequest request);
    Task<OperationResponse> DeleteAsync(int id);
}
