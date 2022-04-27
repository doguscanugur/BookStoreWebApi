using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.BookOperations.GetBooks {
    public class GetBookByIdValidator : AbstractValidator<GetBookById> {
        public GetBookByIdValidator () {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
