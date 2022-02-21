using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook {
    public class UpdateBookCommand {

        private readonly BookStoreDbContext dbcontext;
        public UpdateBookModel UpdateBookModel { get; set; }

        public int BookId { get; set; }

        public UpdateBookCommand (BookStoreDbContext dbcontext) {
            this.dbcontext = dbcontext;
        }

        public void Handle() {
            Book getBook = dbcontext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (getBook == null) {
                throw new InvalidOperationException("Güncellenmek istenen kitap bulunamadı.");  
            }
            int stringGenre = (int)Enum.Parse(typeof(GenreEnum), UpdateBookModel.Genre);

            getBook.Title = UpdateBookModel.Title != default ? UpdateBookModel.Title : getBook.Title;
            getBook.GenreId = UpdateBookModel.Genre != default ? stringGenre : getBook.GenreId;
            getBook.PageCount = UpdateBookModel.PageCount != default ? UpdateBookModel.PageCount : getBook.PageCount;
            getBook.PublishDate = UpdateBookModel.PublishDate != default ? UpdateBookModel.PublishDate : getBook.PublishDate;
            
            dbcontext.SaveChanges();
            

        }
    }
    public class UpdateBookModel {
        
        
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
