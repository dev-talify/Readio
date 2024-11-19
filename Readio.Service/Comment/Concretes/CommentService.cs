

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Model.Response;
using Readio.DataAccess.Comment.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Comment.Dtos.Create.Request;
using Readio.Model.Comment.Dtos.Create.Response;
using Readio.Model.Comment.Dtos.Global;
using Readio.Model.Comment.Dtos.Update;
using Readio.Model.Comment.Entity;
using Readio.Service.Comment.Abstracts;
using Readio.Service.Comment.Rules;
using Readio.Service.Constants;
using System.Net;

namespace Readio.Service.Comment.Concretes;

public class CommentService(ICommentRepository commentRepository, IMapper mapper, IUnitOfWork unitOfWork , CommentBusinessRules commentBusinessRules) : ICommentService
{
    public async Task<OperationResponse<CreateCommentResponse>> CreateAsync(CreateCommentRequest request)
    {
        var comment = mapper.Map<CommentEntity>(request);
        await commentRepository.AddAsync(comment);
        await unitOfWork.SaveChangesAsync();

        var commentAsDto = mapper.Map<CreateCommentResponse>(comment);

        return OperationResponse<CreateCommentResponse>.Success(commentAsDto, Messages.CommentCreatedMessage, HttpStatusCode.Created);
    }

    public async Task<OperationResponse> DeleteAsync(int id)
    {
        var comment = await commentRepository.GetByIdAsync(id);
        commentBusinessRules.CheckIfCommentExists(comment);

        commentRepository.Delete(comment);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.CommentDeletedMessage, HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<CommentDto>>> GetAllAsync()
    {
        var comments = await commentRepository.GetAll().ToListAsync();

        var commentsAsDto = mapper.Map<List<CommentDto>>(comments);

        return OperationResponse<List<CommentDto>>.Success(commentsAsDto, Messages.AllCommentsListedMessage);
    }

    public async Task<OperationResponse<CommentDto>> GetByIdAsync(int id)
    {
        var comment = await commentRepository.GetByIdAsync(id);
        commentBusinessRules.CheckIfCommentExists(comment);

        var commentAsDto = mapper.Map<CommentDto>(comment);

        return OperationResponse<CommentDto>.Success(commentAsDto, Messages.CommentByIdMessage);
    }

    public async Task<OperationResponse> UpdateAsync(UpdateCommentRequest request)
    {
        var comment = await commentRepository.GetByIdAsync(request.Id);
        commentBusinessRules.CheckIfCommentExists(comment);

        comment = mapper.Map(request, comment);

        commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.CommentUpdatedMessage, HttpStatusCode.NoContent);
    }
}
