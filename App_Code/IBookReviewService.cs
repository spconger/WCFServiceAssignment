using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

/// <summary>
/// An interface is a list of method signatures
/// a class that implements the interface
/// must have these methods.
/// the service sends these method signatures
/// to the client
/// </summary>
[ServiceContract]
public interface IBookReviewService
{
    //a method must be marked
    //as an operation contract
    //to be used in the Web client later
    [OperationContract]
    int Login(string user, string password);

    [OperationContract]
    bool RegisterReviewer(Reviewer r);

    [OperationContract]
    List<BookInfo> GetBooks();

    [OperationContract]
    List<Book> GetBooksByAuthor(string authorName);
   
}   

/// <summary>
/// a Data contract is a class you design
/// you can use it like one of the classes
/// created by the Data Entities wizard
/// </summary>
[DataContract]
public class BookInfo
{
    
    //a field must be marked
    //as a DataMember to be seen
    //by the client later
    [DataMember]
    public string BookTitle { get; set; }

    [DataMember]
    public string BookEntryDate { get; set; }

    [DataMember]
    public string BookISBN { get; set; }

    [DataMember]
    public List<Author> BookAuthor { get; set; }

}