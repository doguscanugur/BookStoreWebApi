using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.GenreOparations.CreateGenre;
using WebApi.Application.GenreOparations.DeleteGenre;
using WebApi.Application.GenreOparations.GetGenres;
using WebApi.Application.GenreOparations.UpdateGenre;
using WebApi.DBOperations;

namespace WebApi.Controllers {

    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController : Controller {


        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GenreController (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres () {
            GetGenresQuery query = new(context, mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById (int id) {
            GetGenreById genreById = new(context, mapper) {
                GenreId = id
            };
            GetGenreByIdValidator validationRules = new();
            validationRules.ValidateAndThrow(genreById);
            GenreByIdViewModel result = genreById.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre ([FromBody] CreateGenreModel createGenreModel) {
            CreateGenreCommand createGenreCommand = new(context, mapper) {
                Model = createGenreModel
            };
            CreateGenreCommandValidator validationRules = new();
            validationRules.ValidateAndThrow(createGenreCommand);
            createGenreCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody] UpdateGenreModel updateGenreModel,int id) {
            UpdateGenreCommand updateGenreCommand = new(context) {
                GenreId = id,
                Model = updateGenreModel
            };
            UpdateGenreCommandValidator validationRules = new();
            validationRules.ValidateAndThrow(updateGenreCommand);
            updateGenreCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id) {
            
            DeleteGenreCommand deleteGenreCommand = new(context) {
                GenreId = id
            };
            DeleteGenreCommandValidator validationRules = new();
            validationRules.ValidateAndThrow(deleteGenreCommand);
            deleteGenreCommand.Handle();
            return Ok();

        }

    }
}
