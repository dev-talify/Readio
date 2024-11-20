
using AutoMapper;
using Readio.Model.Chapter.Dtos.Create.Request;
using Readio.Model.Chapter.Dtos.Create.Response;
using Readio.Model.Chapter.Dtos.Global;
using Readio.Model.Chapter.Dtos.Update;
using Readio.Model.Chapter.Entity;

namespace Readio.Service.Chapter.Mapping;
public class ChapterMappingProfile : Profile
{
    public ChapterMappingProfile()
    {
        CreateMap<ChapterEntity, ChapterDto>().ReverseMap();
        CreateMap<CreateChapterRequest, ChapterEntity>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title)).ForMember(des => des.Content,
            opt => opt.MapFrom(src => src.Content));
        CreateMap<UpdateChapterRequest, ChapterEntity>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title)).ForMember(des => des.Content,
            opt => opt.MapFrom(src => src.Content));
        CreateMap<ChapterEntity, CreateChapterResponse>();
    }
}

