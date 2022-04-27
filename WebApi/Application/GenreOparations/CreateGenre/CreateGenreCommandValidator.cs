using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.GenreOparations.CreateGenre {
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>{
        public CreateGenreCommandValidator () {
            
            RuleFor(command => command.Model.IsActive).NotNull();
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);

        }
    }
}
