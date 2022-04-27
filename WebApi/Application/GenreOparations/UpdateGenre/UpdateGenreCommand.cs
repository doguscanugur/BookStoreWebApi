using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOparations.UpdateGenre {
    public class UpdateGenreCommand {

        private readonly BookStoreDbContext context;
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }

        public UpdateGenreCommand (BookStoreDbContext context) {
            this.context = context; 
        }

        public void Handle () {
            var genre = context.Genres.Where(x => x.Id == GenreId).SingleOrDefault();
            if (genre==null) {
                throw new InvalidOperationException("Güncellenecek kitap türü bulanamadı");
            }
            if (context.Genres.Any(x=>x.Name.ToLower() == Model.GenreName.ToLower() && x.Id!= GenreId)) {
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
            }
            genre.Name = Model.GenreName.Trim() != default ? Model.GenreName : genre.Name;
            genre.IsActive = Model.IsActive;
            context.SaveChanges();

        }
    }
    public class UpdateGenreModel {
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}
