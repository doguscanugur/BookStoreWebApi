using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOparations.CreateGenre {
    public class CreateGenreCommand {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateGenreModel Model { get; set; }

        public CreateGenreCommand (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        public void Handle () {
            var genre = context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre !=null) {
                throw new InvalidOperationException("Bu kitap türü zaten var");

            }
            context.Genres.Add(mapper.Map<Genre>(Model));
            context.SaveChanges();
        }
    }
    public class CreateGenreModel {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
