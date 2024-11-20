

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Model.Response;
using Readio.DataAccess.Chapter.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Chapter.Dtos.Create.Request;
using Readio.Model.Chapter.Dtos.Create.Response;
using Readio.Model.Chapter.Dtos.Global;
using Readio.Model.Chapter.Dtos.Update;
using Readio.Model.Chapter.Entity;
using Readio.Service.Author.Mapping;
using Readio.Service.Chapter.Abstracts;
using Readio.Service.Chapter.Rules;
using Readio.Service.Constants;
using System.Net;

namespace Readio.Service.Chapter.Concretes;

public class ChapterService(IChapterRepository chapterRepository, IMapper mapper, IUnitOfWork unitOfWork, ChapterBusinessRules chapterBusinessRules) : IChapterService
{
    public async Task<OperationResponse<CreateChapterResponse>> CreateAsync(CreateChapterRequest request)
    {
        var chapter = mapper.Map<ChapterEntity>(request);
        await chapterRepository.AddAsync(chapter);
        await unitOfWork.SaveChangesAsync();

        var chapterAsDto = mapper.Map<CreateChapterResponse>(chapter);

        return OperationResponse<CreateChapterResponse>.Success(chapterAsDto, Messages.ChapterCreatedMessage, System.Net.HttpStatusCode.Created);
    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var chapter = await chapterRepository.GetByIdAsync(id);
        chapterBusinessRules.CheckIfChapterExists(chapter);

        chapterRepository.Delete(chapter);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.ChapterDeletedMessage, HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<ChapterDto>>> GetAllAsync()
    {
        var chapters = await chapterRepository.GetAll().ToListAsync();

        var chaptersAsDto = mapper.Map<List<ChapterDto>>(chapters);

        return OperationResponse<List<ChapterDto>>.Success(chaptersAsDto, Messages.AllChaptersListedMessage);
    }

    public async Task<OperationResponse<ChapterDto>> GetByIdAsync(int id)
    {
        var chapter = await chapterRepository.GetByIdAsync(id);
        chapterBusinessRules.CheckIfChapterExists(chapter);

        var chapterAsDto = mapper.Map<ChapterDto>(chapter);

        return OperationResponse<ChapterDto>.Success(chapterAsDto, Messages.ChapterByIdMessage);
    }

    public async Task<OperationResponse> UpdateAsync(UpdateChapterRequest request)
    {
        var chapter = await chapterRepository.GetByIdAsync(request.Id);
        chapterBusinessRules.CheckIfChapterExists(chapter);

        chapter = mapper.Map(request, chapter);

        chapterRepository.Update(chapter);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.ChapterUpdatedMessage, HttpStatusCode.NoContent);
    }
}
