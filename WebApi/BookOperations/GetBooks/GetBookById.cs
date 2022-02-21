using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks {
    public class GetBookById {
        private readonly BookStoreDbContext context;
        public int BookId { get; set; }

        public GetBookById (BookStoreDbContext context) {
            this.context = context;
        }

        public BookByIdViewModel Handle () {
            var getBook = context.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (getBook==null) {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookByIdViewModel bookByIdViewModels = new () {
                Genre = ((GenreEnum)getBook.GenreId).ToString(),
                Title = getBook.Title,
                PageCount = getBook.PageCount,
                PublishDate = getBook.PublishDate.Date.ToString("dd/MM/yyyy")
            };


            return bookByIdViewModels;
        }
    }
    public class BookByIdViewModel {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

}
