
using AutoMapper;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Member.Dtos.Create.Request;
using Readio.Model.Member.Dtos.Create.Response;
using Readio.Model.Member.Dtos.Global;
using Readio.Model.Member.Dtos.Update;
using Readio.Model.Member.Entity;

namespace Readio.Service.Member.Mapping;

public class MemberMappingProfile : Profile
{
    public MemberMappingProfile()
    {
        CreateMap<MemberEntity, MemberDto>().ReverseMap();

        CreateMap<CreateMemberRequest, MemberEntity>().ForMember(des => des.FirstName,
            opt => opt.MapFrom(src => src.FirstName)).ForMember(des => des.LastName,
            opt => opt.MapFrom(src => src.LastName)).ForMember(des => des.ProfilePicture,
            opt => opt.MapFrom(src => src.ProfilePicture));

        CreateMap<UpdateMemberRequest, MemberEntity>().ForMember(des => des.FirstName,
            opt => opt.MapFrom(src => src.FirstName)).ForMember(des => des.LastName,
            opt => opt.MapFrom(src => src.LastName)).ForMember(des => des.ProfilePicture,
            opt => opt.MapFrom(src => src.ProfilePicture));

        CreateMap<MemberEntity, CreateMemberResponse>();
    }
}
