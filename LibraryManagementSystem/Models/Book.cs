/// <summary>
/// Represents a book in the library management system, containing bibliographic and inventory information.
/// </summary>
/// <remarks>The Book class encapsulates details such as title, author, publication, edition, and inventory
/// status. It is typically used to manage and track books within the library's collection.</remarks>

public class Book : LmsShared
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publication { get; set; }
    public string Category { get; set; }
    public string Edition { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string PublishedYear { get; set; }
    public string Isbn { get; set; }
    public int NoOfPages { get; set; }
    public string Status { get; set; }
}
