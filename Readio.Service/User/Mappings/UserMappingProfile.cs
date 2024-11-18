

using AutoMapper;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Entity;

namespace Readio.Service.User.Mappings;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity,UserDto>().ReverseMap();
    }
}
