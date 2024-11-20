using AutoMapper;
using Readio.Model.Comment.Dtos.Create.Request;
using Readio.Model.Comment.Dtos.Create.Response;
using Readio.Model.Comment.Dtos.Global;
using Readio.Model.Comment.Dtos.Update;
using Readio.Model.Comment.Entity;

namespace Readio.Service.Comment.Mapping;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<CommentEntity, CommentDto>().ReverseMap();
        CreateMap<CreateCommentRequest, CommentEntity>().ForMember(des => des.Content,
            opt => opt.MapFrom(src => src.Content));
        CreateMap<UpdateCommentRequest, CommentEntity>().ForMember(des => des.Content,
            opt => opt.MapFrom(src => src.Content));
        CreateMap<CommentEntity, CreateCommentResponse>();
    }
}
