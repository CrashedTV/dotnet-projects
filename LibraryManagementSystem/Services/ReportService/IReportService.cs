public interface IReportService
{
    List<BorrowedReport> GetCurrentlyBorrowedBooksReport(BorrowedReportFilter borrowedReportFilter);
    List<DueDateReport> GetOverDueBooksReport(DateOnly currentDate);
    List<MemberHistoryReport> HistoryOfStudentReport(int memberId);
}
