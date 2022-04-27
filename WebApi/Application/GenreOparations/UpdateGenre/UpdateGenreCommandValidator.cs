using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.GenreOparations.UpdateGenre {
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {

        public UpdateGenreCommandValidator () {

            
            RuleFor(command => command.Model.GenreName).MinimumLength(4).When(x=>x.Model.GenreName.Trim() != string.Empty);
            
        }
    }
}
