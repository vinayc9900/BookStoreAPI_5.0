using BookStoreAPI.DBContext;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
    public class BookRepository:IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _bookStoreContext.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description

            }).ToListAsync();
            return books;
        }
        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var books = await _bookStoreContext.Books.Where(x=>x.Id==id).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description

            }).FirstOrDefaultAsync();
            return books;
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title=bookModel.Title,
                Description=bookModel.Description
            };
            await _bookStoreContext.Books.AddAsync(book);
           await  _bookStoreContext.SaveChangesAsync();

            return book.Id; 
        }
        public async Task UpdateBookAsync(int id,BookModel model)
        {
            //var book = await _bookStoreContext.Books.FindAsync(id);
            //if(book!=null)
            //{

            //    book.Title = model.Title;
            //    book.Description = model.Description;

            //    await _bookStoreContext.SaveChangesAsync();
            //}
            var book = new Books()
            {
                Id = id,
                Title = model.Title,
                Description = model.Description
            };
             _bookStoreContext.Books.Update(book);
            await _bookStoreContext.SaveChangesAsync();

        }
        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument jpmodel)
        {
            var book = await _bookStoreContext.Books.FindAsync(id);
            if(book!=null)
            {
                jpmodel.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }
        public async Task DeleteBookByIdAsync(int id)
        {
            //var book = await _bookStoreContext.Books.FindAsync(id);
            var book = new Books() { Id=id}; // if we have primary key
           
                _bookStoreContext.Books.Remove(book);
                await _bookStoreContext.SaveChangesAsync();
            
        }
    }
}
