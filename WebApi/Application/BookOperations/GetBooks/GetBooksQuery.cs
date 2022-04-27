using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.GetBooks {
    public class GetBooksQuery {

        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public GetBooksQuery (BookStoreDbContext dbContext, IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<BookViewModel> Handle () {
            var bookList = dbContext.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> returnObj = mapper.Map<List<BookViewModel>>(bookList);
            return returnObj;

            //foreach (var book in bookList) {
            //    bookViewModels.Add(new BookViewModel {
            //        Title = book.Title,
            //        PageCount = book.PageCount,
            //        PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //        Genre = ((GenreEnum)book.GenreId).ToString()

            //    });

            
            //return bookViewModels;
        }
    }

    public class BookViewModel {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
