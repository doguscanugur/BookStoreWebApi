using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks {
    public class GetBooksQuery {

        private readonly BookStoreDbContext dbContext;
        public GetBooksQuery (BookStoreDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public List<BookViewModel> Handle () {
            var bookList = dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach (var book in bookList) {
                bookViewModels.Add(new BookViewModel {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    Genre = ((GenreEnum)book.GenreId).ToString()

                });

            }
            return bookViewModels;
        }
    }

    public class BookViewModel {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
