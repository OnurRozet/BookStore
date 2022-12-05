using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{


    [ApiController]
    [Route("[Controller]")]
    public class BookController : Controller
    {


        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookContext.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;

        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookContext.Books.Where(x => x.Id == id).SingleOrDefault();
            return book;

        }


        

        [HttpPost]


        public IActionResult AddBook(Book newbook)
        {
            Book lastBook = null;

            if (BookContext.Books.Count>0)
            {
                lastBook = BookContext.Books.Last();
            }
            newbook.Id = 0;
            if (lastBook!=null)
            {
                newbook.Id = lastBook.Id + 1;
            }
          
            if (newbook.Title == null)
            {

                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "BookName_Invalid";
                errorResponse.Message = "Name  can not be blank";
                return BadRequest(errorResponse);
            }

            
            if (newbook.PublishDate.Date> DateTime.Now.Date)
            {
                ErrorResponse error = new ErrorResponse();
                error.Code = "PublishDate_Invalid";
                error.Message = "PublishDate can not be later than today";
                return BadRequest(error);
            }
            if (newbook.AuthorId == 0)
            {
                ErrorResponse error = new ErrorResponse();
                error.Code = "Id_Invalid";
                error.Message = "AuthorId not Found";
                return NotFound(error);
            }

            newbook.PublishDate = newbook.PublishDate.Date;
            BookContext.Books.Add(newbook);
            return Ok();
        }


        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {

            var book = BookContext.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                ErrorResponse error = new ErrorResponse();
                error.Code = "Id_Invalid";
                error.Message = "Not Found Id";

                return NotFound(error);
            }
            if (updatedBook.PublishDate.Date > DateTime.Now.Date)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "PublishDate_Invalid";
                errorResponse.Message = "PublishDate can not be later than today";
                return BadRequest(errorResponse);
            }
            if (updatedBook.AuthorId != book.AuthorId)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "Author_Invalid";
                errorResponse.Message = "AuthorId can not be Update";
                return BadRequest(errorResponse);
            }

            book.Title = updatedBook.Title;
            book.GenreId = updatedBook.GenreId;
            book.PublishDate = updatedBook.PublishDate.Date;
            book.PageCount = updatedBook.PageCount;
            
            return Ok();
            
        }
           
          
          




        [HttpDelete("{id}")]

        public ActionResult DeleteBook(int id)
        {
            var book = BookContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                ErrorResponse error = new ErrorResponse();
                error.Code = "Id_Invalid";
                error.Message = "Not Found Id";
                return NotFound(error);
            }
            BookContext.Books.Remove(book);
            return Ok();
        }

       

    }
   
}
