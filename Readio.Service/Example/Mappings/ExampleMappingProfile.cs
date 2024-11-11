

using AutoMapper;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Entity;

namespace Readio.Service.Example.Mappings;

public class ExampleMappingProfile : Profile
{
    public ExampleMappingProfile()
    {
        //Mapleme ornek
        CreateMap<CreateExampleRequest, ExampleEntity>(); //ForMember
            

    }
}
