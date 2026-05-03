public class MemberHistoryReport
{
    public string MemberName { get; set; }
    public string MemberPhoneNumber{ get; set; }
    public DateOnly JoinedDate { get; set; }
    public string MemberEmail { get; set; }
    public string MembershipType { get; set; }
    public string MemberStatus { get; set; }
    public List<MemberBookHistory> MemberBookHistories { get; set; }
}

public class MemberBookHistory
{
    public string BookName { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnedDate { get; set; }
    public double LateFine { get; set; }
    public string Status { get; set; }
}