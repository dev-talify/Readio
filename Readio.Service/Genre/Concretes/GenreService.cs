
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Model.Response;
using Readio.DataAccess.Genre.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Genre.Dtos.Create.Request;
using Readio.Model.Genre.Dtos.Create.Response;
using Readio.Model.Genre.Dtos.Global;
using Readio.Model.Genre.Dtos.Update;
using Readio.Model.Genre.Entity;
using Readio.Service.Constants;
using Readio.Service.Genre.Abstracts;
using Readio.Service.Genre.Rules;
using System.Net;

namespace Readio.Service.Genre.Concretes;

public class GenreService(IGenreRepository genreRepository, IMapper mapper, IUnitOfWork unitOfWork, GenreBusinessRules genreBusinessRules) : IGenreService
{
    public async Task<OperationResponse<CreateGenreResponse>> CreateAsync(CreateGenreRequest request)
    {
        var anyGenre = await genreRepository.Find(x => x.Name == request.Name).AnyAsync();
        genreBusinessRules.CheckIfGenreNameExists(anyGenre);

        var genre = mapper.Map<GenreEntity>(request);

        await genreRepository.AddAsync(genre);
        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateGenreResponse>(genre);

        return OperationResponse<CreateGenreResponse>.Success(response, Messages.GenreAddedMessage, HttpStatusCode.Created);
    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var genre = await genreRepository.GetByIdAsync(id);
        genreBusinessRules.CheckIfGenreExists(genre);

        genreRepository.Delete(genre);
        await unitOfWork.SaveChangesAsync();
        
        return OperationResponse.Success(Messages.GenreDeletedMessage,HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<GenreDto>>> GetAllAsync()
    {
        var genres = await genreRepository.GetAll().ToListAsync();

        var genreDto = mapper.Map<List<GenreDto>>(genres);

        return OperationResponse<List<GenreDto>>.Success(genreDto, Messages.AllAuthorsListedMessage, HttpStatusCode.OK);
    }

    public async Task<OperationResponse<GenreDto>> GetByIdAsync(int id)
    {
        var genre = await genreRepository.GetByIdAsync(id);
        genreBusinessRules.CheckIfGenreExists(genre);

        var genreAsDto = mapper.Map<GenreDto>(genre);

        return OperationResponse<GenreDto>.Success(genreAsDto, Messages.GenreByIdMessage);
    }

    public async Task<OperationResponse> UpdateAsync(UpdateGenreRequest request)
    {
        var genre = await genreRepository.GetByIdAsync(request.Id);
        genreBusinessRules.CheckIfGenreExists(genre);

        var anyGenre = await genreRepository.Find(x => x.Name == request.Name && x.Id != genre.Id).AnyAsync();
        genreBusinessRules.CheckIfGenreNameExists(anyGenre);

        genre = mapper.Map(request, genre);

        genreRepository.Update(genre);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.GenreUpdatedMessage, HttpStatusCode.NoContent);
    }
}
