using AutoMapper;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Author.Entity;
using Readio.Model.Book.Dtos.Create.Request;
using Readio.Model.Book.Dtos.Create.Response;
using Readio.Model.Book.Dtos.Global;
using Readio.Model.Book.Dtos.Update;
using Readio.Model.Book.Entity;

namespace Readio.Service.Book.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookEntity, BookDto>().ReverseMap();
        CreateMap<CreateBookRequest, BookEntity>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title)).ForMember(des => des.Description,
            opt => opt.MapFrom(src => src.Description));
        CreateMap<UpdateBookRequest, BookEntity>().ForMember(des => des.Title,
            opt => opt.MapFrom(src => src.Title)).ForMember(des => des.Description,
            opt => opt.MapFrom(src => src.Description));
        CreateMap<BookEntity, CreateBookResponse>();
    }
}
