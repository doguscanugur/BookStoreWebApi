using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.GenreOparations.GetGenres {
    public class GetGenreByIdValidator : AbstractValidator<GetGenreById> {

        public GetGenreByIdValidator () {
            RuleFor(command => command.GenreId).NotEmpty().GreaterThan(0);
        }

    }
}
