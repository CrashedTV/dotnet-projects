/// <summary>
/// Defines the contract for managing a collection of books, including operations to add, remove, update, delete,
/// search, and list books.
/// </summary>
/// <remarks>Implementations of this interface should ensure thread safety if accessed concurrently. The interface
/// abstracts book management operations and does not specify persistence or storage details.</remarks>
public interface IBookService
{
    /// <summary>
    /// Adds the specified book to the collection.
    /// </summary>
    /// <param name="book">The book to add to the collection. Cannot be null.</param>
    void AddBook(Book book);
    bool EditBook(Book book);
    bool DeleteBook(int id);
    List<Book> ViewAllBooks();
    List<Book> SearchBooks(string searchParam);
}
