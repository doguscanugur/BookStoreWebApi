using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers {
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase {

        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public BookController (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks () {
            GetBooksQuery query = new(context,mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById (int id) {

            BookByIdViewModel result;
            GetBookById getBookById = new(context, mapper) {
                BookId = id
            };

            GetBookByIdValidator valitator = new();
            valitator.ValidateAndThrow(getBookById);
            result = getBookById.Handle();


            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook ([FromBody] CreateBookModel createBookModel) {
            CreateBookCommand createBookCommand = new(context, mapper) {
                CreateBookModel = createBookModel
            };

            CreateBookCommandValidator valitator = new();
            valitator.ValidateAndThrow(createBookCommand);

            createBookCommand.Handle();
            //}
            //catch (Exception e) {

            //    return BadRequest(e.Message);
            //}
            return Ok();


        }



        [HttpPut("{id}")]
        public IActionResult UpdateBook (int id, [FromBody] UpdateBookModel book) {

            UpdateBookCommand update = new(context) {
                UpdateBookModel = book,
                BookId = id

            };


            UpdateBookCommandValidator valitator = new();
            valitator.ValidateAndThrow(update);
            update.Handle();


            return Ok();


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id) {

            DeleteBookCommand deleteBookCommand = new(context) {
                BookId = id
            };

            DeleteBookCommandValidator valitator = new();
            valitator.ValidateAndThrow(deleteBookCommand);

            deleteBookCommand.Handle();

            return Ok();
        }
    }


}







