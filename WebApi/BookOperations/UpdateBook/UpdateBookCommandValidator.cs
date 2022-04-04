using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.BookOperations.UpdateBook {
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand> {
        public UpdateBookCommandValidator () {
            RuleFor(command => command.BookId).GreaterThan(0).NotEmpty();
            RuleFor(command => command.UpdateBookModel.Genre).NotEmpty().MinimumLength(2).ToString();
            RuleFor(command => command.UpdateBookModel.PageCount).GreaterThan(0);
            RuleFor(command => command.UpdateBookModel.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.UpdateBookModel.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
