using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOparations.GetGenres {
    public class GetGenresQuery {

        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public GetGenresQuery (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public List<GenresViewModel> Handle () {
            var genres= context.Genres.Where(x => x.IsActive).OrderBy(x=>x.Id);
            List<GenresViewModel> returnObj = mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
            

        }

    }
    public class GenresViewModel {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
