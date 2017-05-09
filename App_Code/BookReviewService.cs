using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookReviewService" in code, svc and config file together.
public class BookReviewService : IBookReviewService
{
    //make a connection to the data entities
    BookReviewDbEntities1 db = new BookReviewDbEntities1();
    public List<BookInfo> GetBooks()
    {
        //this method returns all the books
        var bks = from b in db.Books
                  select b;
                  
        List<BookInfo> books = new List<BookInfo>();
        //we loop through the results
        //and write each field to the BookInfo
        //class
        foreach(Book bk in bks)
        {
            BookInfo book1 = new BookInfo();
            book1.BookTitle = bk.BookTitle;
            book1.BookEntryDate = bk.BookEntryDate.ToShortDateString();
            book1.BookISBN = bk.BookISBN;

            book1.BookAuthor = new List<Author> ();
            //do the same for authors
            foreach(Author a in bk.Authors)
            {
                Author au = new Author();
                au.AuthorName = a.AuthorName;
                book1.BookAuthor.Add(au);
            }
            //add it to the list
            books.Add(book1);
        }
        //return the list
        return books;
    }

    public List<Book> GetBooksByAuthor(string authorName)
    {
        //this has the same structure as the previous
        //method except we limit it to a particular author
        var bks = from b in db.Books
                  from a in b.Authors
                  where a.AuthorName.Equals(authorName)
                  select b;
        List<Book> books = new List<Book> ();

        foreach(var bk in bks)
        {
            Book bo = new Book();
            bo.BookTitle = bk.BookTitle;
            bo.BookEntryDate = bk.BookEntryDate;
            bo.BookISBN = bk.BookISBN;
            
            books.Add(bo);
        }
        return books;
    }

    public int Login(string user, string password)
    {
        //just like the login we did in the last assignment
        int key = 0;
        int result = db.usp_ReviewerLogin(user, password);
        if (result != -1)
        {
            var userKey = (from k in db.Reviewers
                           where k.ReviewerUserName.Equals(user)
                           select k.ReviewerKey).FirstOrDefault();
            key = (int)userKey;
        }

        return key;
    }

    public bool RegisterReviewer(Reviewer r)
    {
        //register using the stored procedure
        bool result = true;
        int rev = db.usp_NewReviewer(r.ReviewerUserName,
            r.ReviewerFirstName, r.ReviewerLastName,
            r.ReviewerEmail, r.ReviewPlainPassword);

        return result;
    }
}
