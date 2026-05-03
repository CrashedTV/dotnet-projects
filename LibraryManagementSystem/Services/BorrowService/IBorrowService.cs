public interface IBorrowService
{
    bool BorrowBook(int bookId, int memberId);
    void DueDateManagement(int bookId, int memberId, DateTime dueDate);
    double BorrowFine(int bookId, int memberId);
    void ReturnBook(int bookId, int memberId);
}
