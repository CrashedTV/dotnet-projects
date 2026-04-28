public interface IBorrowServices
{
    //Borrow books
    void BorrowBooks(Borrow borrow);
    //Due Date Management
    void DueDate(Borrow borrow);
    //Fine of Books
    void Fine(Borrow borrow);
    //Return Books
    void ReturnBooks(Borrow borrow);
}
