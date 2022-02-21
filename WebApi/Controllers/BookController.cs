using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers {
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase {

        private readonly BookStoreDbContext context;

        public BookController (BookStoreDbContext context) {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetBooks () {
            GetBooksQuery query = new(context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById (int id) {

            BookByIdViewModel result;
            GetBookById getBookById = new(context) {
                BookId = id
            };
            try {
                 result = getBookById.Handle();
            }
            catch (Exception e) {

                return BadRequest(e.Message);
            }


            return Ok(result);
        }


        [HttpPost]

        public IActionResult AddBook ([FromBody] CreateBookModel createBookModel) {
            CreateBookCommand createBookCommand = new(context) {
                CreateBookModel = createBookModel
            };
            try {
                createBookCommand.Handle();
            }
            catch (Exception e) {

                return BadRequest(e.Message);
            }
            return Ok();


        }



        [HttpPut]
        public IActionResult UpdateBook ([FromBody] UpdateBookModel book) {

            UpdateBookCommand update = new(context) {
                UpdateBookModel = book
            };

            try {
                update.Handle();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id) {

            var book = context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null) {
                return BadRequest();
            }

            context.Books.Remove(book);
            context.SaveChanges();
            return Ok();

        }






    }
}
