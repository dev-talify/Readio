

using AutoMapper;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Author.Entity;

namespace Readio.Service.Author.Mapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<AuthorEntity,AuthorDto>().ReverseMap();
        CreateMap<CreateAuthorRequest, AuthorEntity>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name)).ForMember(des => des.Bio,
            opt=> opt.MapFrom(src=>src.Bio));
        CreateMap<UpdateAuthorRequest,AuthorEntity>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name)).ForMember(des => des.Bio,
            opt => opt.MapFrom(src => src.Bio));
        CreateMap<AuthorEntity, CreateAuthorResponse>();
    }
}
