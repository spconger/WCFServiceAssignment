using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookReviewService" in code, svc and config file together.
public class BookReviewService : IBookReviewService
{
    BookReviewDbEntities1 db = new BookReviewDbEntities1();
    public List<BookInfo> GetBooks()
    {
        var bks = from b in db.Books
                  select b;
                  
        List<BookInfo> books = new List<BookInfo>();
        foreach(Book bk in bks)
        {
            BookInfo book1 = new BookInfo();
            book1.BookTitle = bk.BookTitle;
            book1.BookEntryDate = bk.BookEntryDate.ToShortDateString();
            book1.BookISBN = bk.BookISBN;

            book1.BookAuthor = new List<Author> ();
            foreach(Author a in bk.Authors)
            {
                Author au = new Author();
                au.AuthorName = a.AuthorName;
                book1.BookAuthor.Add(au);
            }
            books.Add(book1);
        }
        return books;
    }

    public BookInfo GetBooksByAuthor(string authorName)
    {
        throw new NotImplementedException();
    }

    public int Login(string user, string password)
    {
        throw new NotImplementedException();
    }

    public bool RegisterReviewer(Reviewer r)
    {
        throw new NotImplementedException();
    }
}
