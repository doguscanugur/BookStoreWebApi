﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.GenreOparations.DeleteGenre {
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand> {
        public DeleteGenreCommandValidator () {
            RuleFor(command => command.GenreId).GreaterThan(0).NotEmpty();
        }
    }
}
