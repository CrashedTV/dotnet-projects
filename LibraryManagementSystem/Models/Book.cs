public class Book : LmsShared
{
    public int BookId { get; set; } 
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publication { get; set; }
    public string Category { get; set; }
    public int Edition { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string PublishedYear { get; set; }
    public string ISBN { get; set; }
    public int NoOfPages { get; set; }
    public string Status { get; set; }
}