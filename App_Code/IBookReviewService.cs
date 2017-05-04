using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookReviewService" in both code and config file together.
[ServiceContract]
public interface IBookReviewService
{
    [OperationContract]
    int Login(string user, string password);

    [OperationContract]
    bool RegisterReviewer(Reviewer r);

    [OperationContract]
    List<BookInfo> GetBooks();

    [OperationContract]
    BookInfo GetBooksByAuthor(string authorName);
   
}   

[DataContract]
public class BookInfo
{
    
    [DataMember]
    public string BookTitle { get; set; }

    [DataMember]
    public string BookEntryDate { get; set; }

    [DataMember]
    public string BookISBN { get; set; }

    [DataMember]
    public List<Author> BookAuthor { get; set; }

}