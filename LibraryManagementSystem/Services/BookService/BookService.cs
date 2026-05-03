
public class BookService : IBookService
{

    public readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public void AddBook(Book book)
    {       
        book.CreatedDate = DateTime.Now;
        book.CreatedBy = "admin";
        _bookRepository.AddBook(book);
    }

    public bool DeleteBook(int id)
    {
        return _bookRepository.DeleteBook(id);
    }

    public bool EditBook(Book book)
    {
        book.ModifiedBy = "admin";
        book.ModifiedDate = DateTime.Now;
        return _bookRepository.EditBook(book);
    }

    public List<Book> SearchBooks(string searchParam)
    {
        return _bookRepository.SearchBooks(searchParam);
    }

    public List<Book> ViewAllBooks()
    {
        var bookDetails = _bookRepository.ViewAllBooks();
        return bookDetails;
    }    
}