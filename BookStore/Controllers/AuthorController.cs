using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthorController : Controller
    {



        [HttpGet]
        public List<Author> GetList()
        {
            var author = AuthorContext.authorList.OrderBy(x => x.Id).ToList();
            return author;
        }

        [HttpGet("{id}")]
        public Author GetById(int id)
        {
            var author = AuthorContext.authorList.FirstOrDefault(x => x.Id == id);
            return author;
        }

        [HttpPost]

        public IActionResult AddAuthor(Author newAuthor)
        {


           

            if (newAuthor.Name == null || newAuthor.SurName==null)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "NameSurname_Invalid";
                errorResponse.Message = "Author Name or Surname can not be null";
                return BadRequest(errorResponse);
            }

            Author lastAuthor = null;
            if (AuthorContext.authorList.Count>0)
            {
                lastAuthor = AuthorContext.authorList.Last();
            }
            if (lastAuthor!=null)
            {
                newAuthor.Id = lastAuthor.Id + 1;
            }

           
              AuthorContext.authorList.Add(newAuthor);
              return Ok();


        }
         
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            var author = AuthorContext.authorList.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "Id_Invalid";
                errorResponse.Message = "Id Not Found";
                return NotFound(errorResponse);
            }



            author.Name = updatedAuthor.Name;
            author.SurName = updatedAuthor.SurName;


            return Ok();

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {

            var author = AuthorContext.authorList.SingleOrDefault(x => x.Id == id);
            if (author == null)
            {
                ErrorResponse errorResponse = new ErrorResponse();
                errorResponse.Code = "Id_Invalid";
                errorResponse.Message = "not Found Id";
                return NotFound(errorResponse);

            }
            AuthorContext.authorList.Remove(author);
            return Ok();
        }
    }
}
