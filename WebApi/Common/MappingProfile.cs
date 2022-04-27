using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.GenreOparations.CreateGenre;
using WebApi.Application.GenreOparations.GetGenres;
using WebApi.Entities;

namespace WebApi.Common {
    public class MappingProfile : Profile {

        public MappingProfile () {
            CreateMap<CreateBookModel, Book>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Book, BookByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenreByIdViewModel>();
            CreateMap<Genre, GenresViewModel>();
        }
    }
}
