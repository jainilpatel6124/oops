using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Class representing a book in the library
    public class Book
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool IsCheckedOut { get; set; }

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            IsCheckedOut = false;
        }
    }

    // Class representing a library member
    public class Member
    {
        public string MemberID { get; private set; }
        public string Name { get; private set; }

        public Member(string memberId, string name)
        {
            MemberID = memberId;
            Name = name;
        }
    }

    // Class representing the library
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

        public void RegisterMember(Member member)
        {
            members.Add(member);
            Console.WriteLine($"Member '{member.Name}' registered to the library.");
        }

        public void CheckoutBook(string isbn, string memberId)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            var member = members.FirstOrDefault(m => m.MemberID == memberId);

            if (book == null)
            {
                Console.WriteLine("Book not found in the library.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Member not registered in the library.");
                return;
            }

            if (book.IsCheckedOut)
            {
                Console.WriteLine($"Book '{book.Title}' is already checked out.");
                return;
            }

            book.IsCheckedOut = true;
            Console.WriteLine($"Book '{book.Title}' checked out by member '{member.Name}'.");
        }

        public void ReturnBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found in the library.");
                return;
            }

            if (!book.IsCheckedOut)
            {
                Console.WriteLine($"Book '{book.Title}' was not checked out.");
                return;
            }

            book.IsCheckedOut = false;
            Console.WriteLine($"Book '{book.Title}' has been returned.");
        }

        public void DisplayAvailableBooks()
        {
            var availableBooks = books.Where(b => !b.IsCheckedOut).ToList();

            if (availableBooks.Count == 0)
            {
                Console.WriteLine("No books are currently available.");
                return;
            }

            Console.WriteLine("Available books:");
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a library
            Library library = new Library();

            // Add books to the library
            library.AddBook(new Book("123456789", "The Great Gatsby", "F. Scott Fitzgerald"));
            library.AddBook(new Book("987654321", "1984", "George Orwell"));
            library.AddBook(new Book("111111111", "To Kill a Mockingbird", "Harper Lee"));

            // Register members
            library.RegisterMember(new Member("M001", "Alice"));
            library.RegisterMember(new Member("M002", "Bob"));

            // Display available books
            library.DisplayAvailableBooks();

            // Checkout books
            library.CheckoutBook("123456789", "M001");
            library.CheckoutBook("987654321", "M002");

            // Display available books after checkout
            library.DisplayAvailableBooks();

            // Return a book
            library.ReturnBook("123456789");

            // Display available books after return
            library.DisplayAvailableBooks();

            Console.ReadLine();
        }
    }
}
