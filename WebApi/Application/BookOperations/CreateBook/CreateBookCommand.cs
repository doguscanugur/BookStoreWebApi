using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.CreateBook {
    public class CreateBookCommand {

        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;
        public CreateBookModel CreateBookModel { get; set; }
        public CreateBookCommand (BookStoreDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        public void Handle () {
            var book = context.Books.SingleOrDefault(x => x.Title == CreateBookModel.Title);

            if (book!=null) {
                throw new InvalidOperationException("Bu kitap zaten mevcut");
            }
            context.Books.Add(mapper.Map<Book>(CreateBookModel));
            //context.Books.Add(new Book {
            //    Title= CreateBookModel.Title,
            //    GenreId= CreateBookModel.GenreId,
            //    PageCount= CreateBookModel.PageCount,
            //    PublishDate= CreateBookModel.PublishDate

            //});
            context.SaveChanges();
            
        }
    }
    public class CreateBookModel {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
