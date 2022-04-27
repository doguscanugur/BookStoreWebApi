using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOparations.DeleteGenre {
    public class DeleteGenreCommand {

        private readonly BookStoreDbContext context;
        public int GenreId { get; set; }

        public DeleteGenreCommand (BookStoreDbContext context) {
            this.context = context;
        }
        public void Handle () {
            var genre = context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre ==null) {
                throw new InvalidOperationException("Kitap türü bulunamadı.");

            }
            context.Genres.Remove(genre);
            context.SaveChanges();
        }

    }
}
