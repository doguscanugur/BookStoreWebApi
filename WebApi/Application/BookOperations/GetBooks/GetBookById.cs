using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.GetBooks {
    public class GetBookById {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public int BookId { get; set; }

        public GetBookById (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        public BookByIdViewModel Handle () {
            var getBook = context.Books.Include(x=>x.Genre).Where(x => x.Id == BookId).SingleOrDefault();
            if (getBook==null) {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            BookByIdViewModel bookByIdViewModels = mapper.Map<BookByIdViewModel>(getBook);


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
