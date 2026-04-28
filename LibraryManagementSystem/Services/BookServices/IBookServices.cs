public interface IBookServices
{
    void AddBooks(Book books);
    void RemoveBooks(Book books);
    void UpdateBooks(Book books);
    void DeleteBooks(int BookId);
    List<Book> SearchBooks(string keyword);
    List<Book> ListBooks();

}
