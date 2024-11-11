

using AutoMapper;
using Readio.Core.Model.Response;
using Readio.DataAccess.Example.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Example.Dtos.Create;
using Readio.Model.Example.Dtos.Global;
using Readio.Model.Example.Dtos.Update;
using Readio.Service.Example.Abstract;
using Readio.Service.Example.Rules;

namespace Readio.Service.Example.Concretes;

public class ExampleService(IExampleRepository exampleRepository,IUnitOfWork unitOfWork,
    IMapper mapper,ExampleBusinessRules exampleBusinessRules) : IExampleService
{
    public Task<OperationResponse<CreateExampleResponse>> CreateAsync(CreateExampleRequest request)
    {
        //businessrules
        //mapping request -> ExampleEntity
        //exampleRepository.Add();
        //unitOfWork.SaveChanges()
        //mapping ExampleEntity -> response
        //return OperationResponse
        return null; //patlamasın diye
    }

    public Task<OperationResponse> DeleteAsync(int id)
    {
        //business rules
        //exampleRepository.Delete()
        //unitofwork.SaveChanges()
        //return OperationResponse
        return null;
    }

    public Task<OperationResponse<List<ExampleDto>>> GetAllAsync()
    {
        //exampleRepository.GetAll().ToListAsync();
        //mapping ExampleEntity -> ExampleDto
        //return OperationResponse
        return null;
    }

    public Task<OperationResponse<ExampleDto>> GetByIdAsync(int id)
    {
        //exampleRepository.GetByIdAsync();
        //business rules
        //mapping ExampleEntity -> ExampleDto
        // return OperationResponse
        return null;

    }

    public Task<OperationResponse> UpdateAsync(int id, UpdateExampleRequest request)
    {
        //exampleRepository.GetByIdAsync();
        //business rules
        // mapping request -> ExampleEntity
        //exampleRepository.Update
        //unitOfWork.SaveChanges
        //return OperationResponse

        return null;
    }
}
