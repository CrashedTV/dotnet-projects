public class MainApplication : IMainApplication
{
    private readonly IBookService _bookService;
    private readonly IMemberService _memberService;
    private readonly IBorrowService _borrowService;
    private readonly IReportService _reportService;

    public MainApplication(IBookService bookService, IMemberService memberService, IBorrowService borrowService, IReportService reportService)
    {
        _bookService = bookService;
        _memberService = memberService;
        _borrowService = borrowService;
        _reportService = reportService;
    }

    public void Run()
    {
        bool exit = true;

        while (exit)
        {
            ShowMenu();
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ShowBookOperation();
                    break;

                case "2":
                    ShowMemberOperation(); ;
                    break;

                case "3":
                    ShowBorrowOperation(); ;
                    break;

                case "4":
                    ShowReportOperation(); ;
                    break;

                case "0":
                    exit = false;
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("  LIBRARY MANAGEMENT SYSTEM");
        Console.WriteLine("  ────────────────────────────────────");
        Console.WriteLine("  1.  Manage Books");
        Console.WriteLine("  2.  Manage Members");
        Console.WriteLine("  3.  Manage Borrowing");
        Console.WriteLine("  4.  Generate Reports");
        Console.WriteLine("  0.  Exit");
        Console.WriteLine("  ────────────────────────────────────");
        Console.Write("\n  Select an option: ");
    }

    private void ShowBookOperation()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("  MANAGE BOOKS");
            Console.WriteLine("  ────────────────────────────────────");
            Console.WriteLine("  1.  Add Book");
            Console.WriteLine("  2.  Edit Book");
            Console.WriteLine("  3.  Delete Book");
            Console.WriteLine("  4.  Search Books");
            Console.WriteLine("  5.  View All Books");
            Console.WriteLine("  0.  Back to Main Menu");
            Console.WriteLine("  ────────────────────────────────────");
            Console.Write("\n  Select an option: ");

            var bookOption = Console.ReadLine();

            switch (bookOption)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("  ADD BOOK");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    Console.Write("  Book Name   : ");
                    var bookName = Console.ReadLine();

                    if (string.IsNullOrEmpty(bookName))
                    {
                        Console.WriteLine("\n  Book name cannot be empty.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("  Author Name : ");
                    var authorName = Console.ReadLine();

                    var newBook = new Book { Name = bookName, Author = authorName };
                    _bookService.AddBook(newBook);
                    Console.WriteLine("\n  Book added successfully!");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("  EDIT BOOK");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter BookId : ");
                    var editId = Console.ReadLine();
                    Console.WriteLine("Enter Book Name: ");
                    var editBookName = Console.ReadLine();

                    var updateBookDetails = new Book
                    {
                        BookId = Convert.ToInt32(editId),
                        Name = editBookName
                    };
                    var hasBeenEdited = _bookService.EditBook(updateBookDetails);
                    if (!hasBeenEdited)
                    {
                        Console.WriteLine("\n  Book not found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                    }

                    Console.WriteLine("Book updated successfully!");
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("  DELETE BOOK");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter BookId : ");
                    var deleteBookId = Console.ReadLine();

                    var hasBeenDeleted = _bookService.DeleteBook(Convert.ToInt32(deleteBookId));


                    if (!hasBeenDeleted)
                    {
                        Console.WriteLine("\n  Book not found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("\n  Book deleted successfully!");
                    Console.WriteLine("  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("  SEARCH BOOKS");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter book name to search : ");
                    var keyword = Console.ReadLine();

                    List<Book> searchResult = _bookService.SearchBooks(keyword);
                    if (!searchResult.Any())
                    {
                        Console.WriteLine("\n  No books found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"\n  {"ID",-5} {"Name",-25} {"Author",-20}");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    foreach (var book in searchResult)
                    {
                        Console.WriteLine($"  {book.BookId,-5} {book.Name,-25} {book.Author,-20}");
                    }
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("  ALL BOOKS");
                    Console.WriteLine("  ────────────────────────────────────");
                    var bookList = _bookService.ViewAllBooks();

                    if (!bookList.Any())
                    {
                        Console.WriteLine("\n  No books found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"\n  {"ID",-5} {"Name",-25} {"Author",-20}");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    foreach (var book in bookList)
                    {
                        Console.WriteLine($"  {book.BookId,-5} {book.Name,-25} {book.Author,-20}");
                    }
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.WriteLine("\n  Returning to main menu...");
                    return;

                default:
                    Console.WriteLine("\n  Invalid option. Please try again.");
                    Console.WriteLine("  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowMemberOperation()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("  MANAGE BOOKS");
            Console.WriteLine("  ────────────────────────────────────");
            Console.WriteLine("  1.  Add Member");
            Console.WriteLine("  2.  Edit Member");
            Console.WriteLine("  3.  Delete Member");
            Console.WriteLine("  4.  Search Members");
            Console.WriteLine("  5.  View All Members");
            Console.WriteLine("  6.  Renew Membership");
            Console.WriteLine("  0.  Back to Main Menu");
            Console.WriteLine("  ────────────────────────────────────");
            Console.Write("\n  Select an option: ");

            var bookOption = Console.ReadLine();

            switch (bookOption)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("  ADD MEMBER");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    Console.Write("  Member Name   : ");
                    var memberName = Console.ReadLine();

                    if (string.IsNullOrEmpty(memberName))
                    {
                        Console.WriteLine("\n  Member name cannot be empty.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("  Member's Phone Number : ");
                    var phoneNumber= Console.ReadLine();

                    var newMember = new Member { MemberName = memberName, Phone = phoneNumber };
                    _memberService.AddMember(newMember);
                    Console.WriteLine("\n  Member added successfully!");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("  EDIT MEMBER");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter MemberId : ");
                    var editMemberId = Console.ReadLine();
                    Console.WriteLine("Enter Member Name: ");
                    var editMemberName = Console.ReadLine();

                    var updateMemberDetails = new Member
                    {
                        MemberId = Convert.ToInt32(editMemberId),
                        MemberName = editMemberName
                    };
                    var hasMemberBeenEdited = _memberService.EditMember(updateMemberDetails);
                    if (!hasMemberBeenEdited)
                    {
                        Console.WriteLine("\n  Member not found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                    }

                    Console.WriteLine("Member updated successfully!");
                    Console.WriteLine("  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("  DELETE BOOK");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter BookId : ");
                    var deleteMemberId = Console.ReadLine();

                    var hasMemberBeenDeleted = _memberService.DeleteMember(Convert.ToInt32(deleteMemberId));


                    if (!hasMemberBeenDeleted)
                    {
                        Console.WriteLine("\n  Member not found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("\n  Member deleted successfully!");
                    Console.WriteLine("  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("  SEARCH MEMBERS");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter member name to search : ");
                    var searchMemberName = Console.ReadLine();

                    var searchMemberResult = _memberService.SearchMembers(searchMemberName);
                    if (!searchMemberResult.Any())
                    {
                        Console.WriteLine("\n  No members found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"\n  {"ID",-5} {"Name",-25} {"Phone",-20}");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    foreach (var member in searchMemberResult)
                    {
                        Console.WriteLine($"  {member.MemberId,-5} {member.MemberName,-25} {member.Phone,-20}");
                    }
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("  ALL MEMBERS");
                    Console.WriteLine("  ────────────────────────────────────");
                    var memberList = _memberService.ViewAllMembers();

                    if (!memberList.Any())
                    {
                        Console.WriteLine("\n  No members found.");
                        Console.WriteLine("  Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine($"\n  {"ID",-5} {"Name",-25} {"Phone",-20}");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    foreach (var member in memberList)
                    {
                        Console.WriteLine($"  {member.MemberId,-5} {member.MemberName,-25} {member.Phone,-20}");
                    }
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("  RENEW MEMBERSHIP");
                    Console.WriteLine("  ────────────────────────────────────");

                    Console.WriteLine("Enter membership id to renew: ");
                    var renewMemberId = Console.ReadLine();
                    Member renewMember = new Member
                    {
                        MemberId = Convert.ToInt32(renewMemberId)
                    };
                    _memberService.RenewMembership(renewMember);
                    Console.Clear();
                    Console.WriteLine("Membership renewed successfully!");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.WriteLine("\n  Returning to main menu...");
                    return;

                default:
                    Console.WriteLine("\n  Invalid option. Please try again.");
                    Console.WriteLine("  Press any key to continue...");
                    Console.ReadKey();
                    break;

            }

        }

    }

    // To be updated
    private void ShowBorrowOperation()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("  MANAGE BORROW");
            Console.WriteLine("  ────────────────────────────────────");
            Console.WriteLine("  1. Borrow Book");
            Console.WriteLine("  2. DueDate Management");
            Console.WriteLine("  3. Borrow Fine");
            Console.WriteLine("  4. Return Books");
            Console.WriteLine("  0.  Back to Main Menu");
            Console.WriteLine("  ────────────────────────────────────");
            Console.Write("\n  Select an option: ");

            var bookOption = Console.ReadLine();
            switch(bookOption)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("  BORROW BOOK");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    Console.WriteLine("Enter Membership Id : ");
                    var membershipId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Book Id : ");
                    var bookId = Convert.ToInt32(Console.ReadLine());
                    var hasBeenEdited = _borrowService.BorrowBook(bookId, membershipId);
                    Console.Clear();
                    if (hasBeenEdited)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Book borrowed successfully!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The Book requested for the member with the id is not found! or book is not available at the moment!");
                    }
                    Console.ResetColor();
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":


                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("  BORROW FINE");
                    Console.WriteLine("  ────────────────────────────────────────────────────");
                    Console.WriteLine("Enter Membership Id : ");
                    var membershipIdForFine = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Book Id : ");
                    var bookIdForFine = Convert.ToInt32(Console.ReadLine());
                    var fineAmount = _borrowService.BorrowFine(bookIdForFine, membershipIdForFine);
                    Console.Clear();
                    Console.WriteLine($"Fine amount is {fineAmount}");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("  RETURN BOOK");
                    Console.WriteLine("  ────────────────────────────────────");
                    Console.Write("  Enter Member Id : ");
                    var memberIdForReturn = Convert.ToInt32(Console.ReadLine());
                    Console.Write("  Enter Book Id   : ");
                    var bookIdForReturn = Convert.ToInt32(Console.ReadLine());

                    _borrowService.ReturnBook(bookIdForReturn, memberIdForReturn);
                    Console.WriteLine("\n  Book returned successfully!");
                    Console.WriteLine("\n  Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("Exiting Book Operations...\n\n\n");
                    return;
                default:
                    Console.WriteLine("Invalid sub menu!");
                    break;
            }
        }
    }

    // To be updated
    private void ShowReportOperation()
    {

    }



}




