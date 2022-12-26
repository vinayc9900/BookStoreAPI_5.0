using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost("")] //   http://localhost:43589/api/books 
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookmodel)
        {
            var id = await _bookRepository.AddBookAsync(bookmodel);

            return CreatedAtAction(nameof(GetBookById), new { id = id, controller = "Books" }, id);
        }

        [HttpPut("{id:int}")] //   http://localhost:43589/api/books/7
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookmodel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookmodel);

            return Ok();
        }
        [HttpPatch("{id:int}")] //   http://localhost:43589/api/books/7
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument jpmodel, [FromRoute] int id)
        {
            // use below code in Body Section in POSTMAN
            //[
            //   {
            //         "op":"replace",   // we can use "remove" to delete value of Title
            //         "path":"Title",
            //         "value":"Patch Update"
            //   }
            //]
            await _bookRepository.UpdateBookPatchAsync(id, jpmodel);

            return Ok();
        }
        [HttpDelete("{id:int}")] //   http://localhost:43589/api/books/7
        public async Task<IActionResult> DeleteBookById([FromRoute] int id)
        {
            await _bookRepository.DeleteBookByIdAsync(id);
            return Ok();
        }
    }
} 
