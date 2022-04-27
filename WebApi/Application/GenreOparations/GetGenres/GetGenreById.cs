using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOparations.GetGenres {
    public class GetGenreById {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int GenreId { get; set; }
        public GetGenreById(BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public GenreByIdViewModel Handle () {
            var genre = context.Genres.SingleOrDefault(x =>x.IsActive && x.Id == GenreId);
            GenreByIdViewModel returnObj = mapper.Map<GenreByIdViewModel>(genre);
            if (genre==null) {
                throw new InvalidOperationException("Tür bulunamadı.");
            }
            return returnObj;


        }

    }
    public class GenreByIdViewModel {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

