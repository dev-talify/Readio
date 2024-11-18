

using AutoMapper;
using Readio.Model.Genre.Dtos.Create.Request;
using Readio.Model.Genre.Dtos.Create.Response;
using Readio.Model.Genre.Dtos.Global;
using Readio.Model.Genre.Dtos.Update;
using Readio.Model.Genre.Entity;

namespace Readio.Service.Genre.Mapping;

public class GenreMappingProfile : Profile
{
    public GenreMappingProfile() 
    {
        CreateMap<GenreEntity, GenreDto>().ReverseMap();

        CreateMap<CreateGenreRequest, GenreEntity>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateGenreRequest, GenreEntity>().ForMember(des => des.Name,
            opt => opt.MapFrom(src => src.Name));

        CreateMap<GenreEntity, CreateGenreResponse>();
    }
}
