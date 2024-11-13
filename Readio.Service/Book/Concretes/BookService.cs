using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Readio.Core.Model.Response;
using Readio.DataAccess.Book.Abstracts;
using Readio.DataAccess.UnitOfWorks.Abstracts;
using Readio.Model.Book.Dtos.Create.Request;
using Readio.Model.Book.Dtos.Create.Response;
using Readio.Model.Book.Dtos.Global;
using Readio.Model.Book.Dtos.Update;
using Readio.Model.Book.Entity;
using Readio.Service.Book.Abstracts;
using Readio.Service.Book.Rules;
using Readio.Service.Constants;
using System.Net;

namespace Readio.Service.Book.Concretes;

public class BookService(IBookRepository bookRepository, IMapper mapper,IUnitOfWork unitOfWork,BookBusinessRules bookBusinessRules) : IBookService
{
    public async Task<OperationResponse<CreateBookResponse>> CreateAsync(CreateBookRequest request)
    {
        var anyBook = await bookRepository.Find(x=> x.Title == request.Title).AnyAsync();
        bookBusinessRules.CheckIfBookNameExists(anyBook);

        var book = mapper.Map<BookEntity>(request);
        await bookRepository.AddAsync(book);
        await unitOfWork.SaveChangesAsync();

        var bookAsDto = mapper.Map<CreateBookResponse>(book);

        return OperationResponse<CreateBookResponse>.Success(bookAsDto, Messages.BookAddedMessage, HttpStatusCode.Created);

    }

    public async Task<OperationResponse> DeleteAsync(Guid id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        bookBusinessRules.CheckIfBookExists(book);

        bookRepository.Delete(book);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.BookDeletedMessage,HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<BookDto>>> GetAllAsync()
    {
        var books = await bookRepository.GetAll().ToListAsync();

        var booksAsDto = mapper.Map<List<BookDto>>(books);

        return OperationResponse<List<BookDto>>.Success(booksAsDto, Messages.AllBooksListedMessage);
    }

    public async Task<OperationResponse<BookDto>> GetByIdAsync(Guid id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        bookBusinessRules.CheckIfBookExists(book);
        
        var bookAsDto = mapper.Map<BookDto>(book);

        return OperationResponse<BookDto>.Success(bookAsDto, Messages.BookByIdMessage);
    }

    public async Task<OperationResponse> UpdateAsync(UpdateBookRequest request)
    {
        var book = await bookRepository.GetByIdAsync(request.Id);
        bookBusinessRules.CheckIfBookExists(book);

        var anyBook = await bookRepository.Find(x=> x.Title == request.Title && x.Id != book.Id).AnyAsync();
        bookBusinessRules.CheckIfBookNameExists(anyBook);

        book = mapper.Map(request,book);

        bookRepository.Update(book);
        await unitOfWork.SaveChangesAsync();

        return OperationResponse.Success(Messages.BookUpdatedMessage,HttpStatusCode.NoContent);

    }
}
