using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DBOperations {
    public class DataGenerator {

        public static void Initialize (IServiceProvider serviceProvider) {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) {
                if (context.Books.Any()) {
                    return;
                }
                context.Genres.AddRange(
                    new Genre { Name = "PersonelGrowth" },
                    new Genre { Name = "ScienceFiction" },
                    new Genre { Name = "Noval" }
                    );

                context.Books.AddRange(
                    new Book {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 21)
                    },
                    new Book {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(202, 12, 27)
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
