using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.BookOperations.UpdateBook {
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> {
        public UpdateBookCommandValidator () {
            RuleFor(command => command.BookId).GreaterThan(0).NotEmpty();
            RuleFor(command => command.UpdateBookModel.Genre).NotNull();
            RuleFor(command => command.UpdateBookModel.PageCount).GreaterThan(0);
            RuleFor(command => command.UpdateBookModel.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.UpdateBookModel.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
