using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.CreateBook {
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand> {
        public CreateBookCommandValidator () {
            RuleFor(command => command.CreateBookModel.GenreId).GreaterThan(0);
            RuleFor(command => command.CreateBookModel.PageCount).GreaterThan(0);
            RuleFor(command => command.CreateBookModel.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.CreateBookModel.Title).NotEmpty().MinimumLength(4);
        }
    }
}
