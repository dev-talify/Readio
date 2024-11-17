using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Model.Response;
using Readio.DataAccess.Member.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Member.Dtos.Create.Request;
using Readio.Model.Member.Dtos.Create.Response;
using Readio.Model.Member.Dtos.Global;
using Readio.Model.Member.Dtos.Update;
using Readio.Model.Member.Entity;
using Readio.Service.Constants;
using Readio.Service.Member.Abstracts;
using Readio.Service.Member.Rules;
using System.Net;

namespace Readio.Service.Member.Concretes;

public class MemberService(IMemberRepository memberRepository, IMapper mapper, IUnitOfWork unitOfWork, MemberBusinessRules memberBusinessRules) : IMemberService
{
    public async Task<OperationResponse<CreateMemberResponse>> CreateAsync(CreateMemberRequest request)
    {
        var anyMember = await memberRepository.Find(x => x.FirstName == request.FirstName).AnyAsync();
        memberBusinessRules.CheckIfMemberNameExists(anyMember);

        var member = mapper.Map<MemberEntity>(request);

        await memberRepository.AddAsync(member);
        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateMemberResponse>(member);

        return OperationResponse<CreateMemberResponse>.Success(response,Messages.MemberAddedMessage, HttpStatusCode.Created);
    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var member = await memberRepository.GetByIdAsync(id);
        memberBusinessRules.CheckIfMemberExists(member);

        memberRepository.Delete(member);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.MemberDeletedMessage, HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<MemberDto>>> GetAllAsync()
    {
        var members = await memberRepository.GetAll().ToListAsync();

        var membersAsDto = mapper.Map<List<MemberDto>>(members);

        return OperationResponse<List<MemberDto>>.Success(membersAsDto, Messages.AllMembersListedMessage, HttpStatusCode.OK);
    }

    public async Task<OperationResponse<MemberDto>> GetByIdAsync(int id)
    {
        var member = await memberRepository.GetByIdAsync(id);
        memberBusinessRules.CheckIfMemberExists(member);

        var memberAsDto = mapper.Map<MemberDto>(member);

        return OperationResponse<MemberDto>.Success(memberAsDto,Messages.MemberByIdMessage);

    }

    public async Task<OperationResponse> UpdateAsync(UpdateMemberRequest request)
    {
        var member = await memberRepository.GetByIdAsync(request.Id);
        memberBusinessRules.CheckIfMemberExists(member);

        var antMember = await memberRepository.Find(x => x.FirstName == request.FirstName && x.Id != member.Id).AnyAsync();
        memberBusinessRules.CheckIfMemberNameExists(antMember);

        member = mapper.Map(request, member);

        memberRepository.Update(member);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.MemberUpdatedMessage, HttpStatusCode.NoContent);
    }
}
