using BookStoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repository
{
   public  interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int id, BookModel model);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument jpmodel);
        Task DeleteBookByIdAsync(int id);
    }

   
}
