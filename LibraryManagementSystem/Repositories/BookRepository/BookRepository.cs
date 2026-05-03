using System.Text.Json;
using System.Text.Json.Nodes;

public class BookRepository : IBookRepository
{
    public readonly string _connectionString = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\Projects\\LibraryManagementSystem\\Data\\book.json";  
    public void AddBook(Book book)
    {
        var bookDetails = GetAllBooksForOperation();
        
        int bookMaxId = bookDetails.Max(b => b.BookId);
        book.BookId = bookMaxId + 1;

        bookDetails.Add(book);
        var updatedBookDetails = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_connectionString, updatedBookDetails);
    }

    public bool DeleteBook(int id)
    {
        var bookDetails = GetAllBooksForOperation(); 
        var bookToDelete = bookDetails.FirstOrDefault(b => b.BookId == id);

        if (bookToDelete == null)
        {
            return false;
        }
        
        bookDetails.RemoveAll(b => b.BookId == id);
        var bookString = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_connectionString, bookString);
        return true;
    }

    public bool EditBook(Book book)
    {
        var bookDetails = GetAllBooksForOperation();
        var bookToEdit = bookDetails.FirstOrDefault(b => b.BookId == book.BookId);
        if (bookToEdit == null)
        {
            return false;
        }
        else
        {
            bookToEdit.Name = book.Name;
            bookToEdit.ModifiedDate = book.ModifiedDate;
            bookToEdit.ModifiedBy = book.ModifiedBy;
            var bookStringUpdated = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookStringUpdated);
            return true;
        }
    }

    public List<Book> SearchBooks(string searchParam)
    {
        var searchBooks = GetAllBooksForOperation();
        var filteredBooks = searchBooks.Where(b => b.Name.Contains(searchParam, StringComparison.OrdinalIgnoreCase)).ToList();
        return filteredBooks;
    }

    public List<Book> ViewAllBooks()
    {
        return GetAllBooksForOperation();
    }

    private List<Book> GetAllBooksForOperation()
    {
        var bookFromTable = File.ReadAllText(_connectionString);
        var bookDetails = JsonSerializer.Deserialize<List<Book>>(bookFromTable);

        return bookDetails ?? new List<Book>();
    }

    public bool UpdateBookCount(Book book)
    {
        var bookDetails = GetAllBooksForOperation();
        var bookToEdit = bookDetails.FirstOrDefault(b => b.BookId == book.BookId);
        if (bookToEdit == null)
        {
            return false;
        }
        else
        {
            bookToEdit.AvailableCopies = book.AvailableCopies;
            bookToEdit.ModifiedDate = book.ModifiedDate;
            bookToEdit.ModifiedBy = book.ModifiedBy;
            var bookStringUpdated = JsonSerializer.Serialize(bookDetails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_connectionString, bookStringUpdated);
            return true;
        }
    }
}
