public interface IBookServices
{
    void AddBooks(Books books);
    void RemoveBooks(Books books);
    void UpdateBooks();
    void DeleteBooks();
    List<Books> SearchBooks();
    List<Books> ListBooks();

}
