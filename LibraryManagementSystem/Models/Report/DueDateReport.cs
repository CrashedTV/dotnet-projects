public class DueDateReport
{
    public string BookName { get; set; }
    public string MemberName { get; set; }
    public string MemberPhoneNumber { get; set; }
    public DateOnly IssuedDate { get; set; }
    public int DueDays { get; set; }
    public double TotalFine { get; set; }
}
