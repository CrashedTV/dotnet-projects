/// <summary>
/// Represents a report containing information about a library member and the books they have borrowed.
/// </summary>
/// <remarks>This class is typically used to aggregate member details with their current borrowing activity for
/// reporting or display purposes. It combines personal information with a list of borrowed books to provide a
/// comprehensive overview of a member's borrowing status.</remarks>

public class BorrowedReport
{
    public string MemberName { get; set; }
    public string MemberPhoneNumber { get; set; }
    public string MembershipType { get; set; }

    public List<BorrowedBooksDetails> BorrowedBooksDetails { get; set; }

}

public class BorrowedBooksDetails 
{
    public string BookName { get; set; }
    public string BookIsbn { get; set; }

    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public int DueDays { get; set; }
    public double DueFine { get; set; }
}
