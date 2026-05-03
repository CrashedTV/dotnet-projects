public class ReportService : IReportService
{
    public List<BorrowedReport> GetCurrentlyBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter)
    {
        throw new NotImplementedException();
    }
    public List<DueDateReport> GetOverDueBooksReport(DateOnly currentDate)
    {
        throw new NotImplementedException();
    }

    public List<MemberHistoryReport> HistoryOfStudentReport(int memberId)
    {
        throw new NotImplementedException();
    }
}

