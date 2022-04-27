using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.DeleteBook {
    public class DeleteBookCommand {

        private readonly BookStoreDbContext dbcontext;
        

        public int BookId { get; set; }

        public DeleteBookCommand (BookStoreDbContext dbcontext) {
            this.dbcontext = dbcontext;
        }

        public void Handle () {
            var book = dbcontext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null) {
                throw new InvalidOperationException("Silinecek kitap bulunamadı");
            }

            dbcontext.Books.Remove(book);
            dbcontext.SaveChanges();
            
        }

    }
}
