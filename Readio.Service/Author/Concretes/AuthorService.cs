
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Exceptions;
using Readio.Core.Model.Response;
using Readio.DataAccess.Author.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Author.Dtos.Create.Request;
using Readio.Model.Author.Dtos.Create.Response;
using Readio.Model.Author.Dtos.Global;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.Author.Entity;
using Readio.Service.Author.Abstracts;
using Readio.Service.Author.Rules;
using Readio.Service.Constants;
using System.Net;

namespace Readio.Service.Author.Concretes;

public class AuthorService(IAuthorRepository authorRepository,IMapper mapper,IUnitOfWork unitOfWork,AuthorBusinessRules authorBusinessRules) : IAuthorService
{
    public async Task<OperationResponse<CreateAuthorResponse>> CreateAsync(CreateAuthorRequest request)
    {
        var anyAuthor = await authorRepository.Find(x => x.Name == request.Name).AnyAsync();
        authorBusinessRules.CheckIfAuthorNameExists(anyAuthor);

        var author = mapper.Map<AuthorEntity>(request);

        await authorRepository.AddAsync(author);
        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateAuthorResponse>(author);

        return OperationResponse<CreateAuthorResponse>.Success(response,Messages.AuthorAddedMessage,HttpStatusCode.Created);

    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var author = await authorRepository.GetByIdAsync(id);
        authorBusinessRules.CheckIfAuthorExists(author);

        authorRepository.Delete(author);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.AuthorDeletedMessage,HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<AuthorDto>>> GetAllAsync()
    {
        var authors = await authorRepository.GetAll().ToListAsync();

        var authorAsDto = mapper.Map<List<AuthorDto>>(authors);

        return OperationResponse<List<AuthorDto>>.Success(authorAsDto,Messages.AllAuthorsListedMessage,HttpStatusCode.OK);
    }

    public async Task<OperationResponse<AuthorDto>> GetByIdAsync(int id)
    {
        var author = await authorRepository.GetByIdAsync(id);
        authorBusinessRules.CheckIfAuthorExists(author);

        var authorAsDto = mapper.Map<AuthorDto>(author);

        return OperationResponse<AuthorDto>.Success(authorAsDto,Messages.AuthorByIdMessage);

    }

    public async Task<OperationResponse> UpdateAsync(UpdateAuthorRequest request)
    {
        var author = await authorRepository.GetByIdAsync(request.Id);
        authorBusinessRules.CheckIfAuthorExists(author);

        var anyAuthor = await authorRepository.Find(x=> x.Name == request.Name && x.Id != author.Id).AnyAsync();
        authorBusinessRules.CheckIfAuthorNameExists(anyAuthor);

        author = mapper.Map(request,author);

        authorRepository.Update(author);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.AuthorUpdatedMessage, HttpStatusCode.NoContent);
    }
}
