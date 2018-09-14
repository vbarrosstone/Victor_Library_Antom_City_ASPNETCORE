using System.Collections.Generic;
using System.Linq;
using Victor_Library_Antom_City_ASPNETCORE.Models;

namespace Victor_Library_Antom_City_ASPNETCORE
{
    public static class Repository
    {
        // This class works like a repository of classes.
        public static List<Author> Authors = new List<Author>();
        public static List<Book> Books = new List<Book>();
        public static List<PublishingCompany> Publishers = new List<PublishingCompany>();

        /// <summary>
        /// Verify if already exist in the Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>

        public static int Check(string authorName, List<Author> list)
        {
            if (!Authors.Any()) { return -1; }
            else
            {
                foreach (Author author in list)
                {
                    if (author.Name.Equals(authorName)) { return (int)author.Id; }
                }
                return -1;
            }
        }

        /// <summary>
        /// Verify if already exist in the Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="publichingCompanyName"></param>
        /// <returns></returns>
        public static int Check(string publichingCompanyName, List<PublishingCompany> list)
        {
            if (!Publishers.Any()) { return -1; }
            else
            {
                foreach (PublishingCompany publisher in list)
                {
                    if (publisher.Name.Equals(publichingCompanyName)) { return (int)publisher.Id; }
                }
                return -1;
            }
        }

        /// <summary>
        /// Verify if already exist in the Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public static int Check(string bookName, List<Book> list)
        {
            if (!Books.Any()) { return -1; }
            else
            {
                foreach (Book book in list)
                {
                    if (book.Title.Equals(bookName)) { return (int)book.Id; }
                }
                return -1;
            }
        }
        
        /// <summary>
        /// Post the new Author to the Repository.
        /// </summary>
        /// <param name="author"></param>
        public static void Insert(Author author, List<Author> list)
        {
            if (!string.IsNullOrEmpty(author.Name)) { };
            if (Check(author.Name, list) == -1)
            {
                author.Id = Author.Count;
                Author.Count++;
                author.NumberOfBooks++;
                Authors.Add(author);
            }
        }

        /// <summary>
        /// Post the new Publisher to the Repository.
        /// </summary>
        /// <param name="publishingCompany"></param>
        public static void Insert(PublishingCompany publishingCompany, List<PublishingCompany> list)
        {
            if (!string.IsNullOrEmpty(publishingCompany.Name)) { };
            if (Check(publishingCompany.Name, list) == -1)
            {
                publishingCompany.Id = PublishingCompany.Count;
                PublishingCompany.Count++;
                publishingCompany.NumberOfBooks++;
                Publishers.Add(publishingCompany);
            }
        }

        /// <summary>
        /// Post to the Repository.
        /// </summary>
        /// <param name="publishingCompany"></param>
        public static void Insert(Book book, List<Book> list)
        {
            if (!string.IsNullOrEmpty(book.Title)) { };

            int indexBook = Check(book.Title, Books);
            if (indexBook == -1)
            {
                book.Id = Book.Count;
                Book.Count++;
                int indexAuthor = Check(book.author.Name, Authors);
                if (indexAuthor == -1)
                {
                    Insert(book.author, Authors);
                }
                else
                {
                    book.author = Authors[indexAuthor - 1];
                    book.author.NumberOfBooks++;
                }

                int indexPublishingCompany = Check(book.publishingCompany.Name, Publishers);
                if (indexPublishingCompany == -1)
                {
                    Insert(book.publishingCompany, Publishers);
                }
                else
                {
                    book.publishingCompany = Publishers[indexPublishingCompany - 1];
                    book.publishingCompany.NumberOfBooks++;
                }
                Books.Add(book);
            }
        }

        /// <summary>
        /// Return to the list of all books written by the Author.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<Book> GetBooksByAuthorName(string input)
        {
            string name = input.ToUpper();
            var BooksByAuthor = new List<Book>();
            Books.ForEach(book =>
            {
                string nameCompare = book.author.Name.ToUpper();
                if (nameCompare.Contains(name)) { BooksByAuthor.Add(book); }
            });
            return BooksByAuthor;
        }

        /// <summary>
        /// Return to the list of all books published by the company.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<Book> GetBooksByPublisherName(string input)
        {
            string name = input.ToUpper();
            var BooksByPublishingCompany = new List<Book>();
            Books.ForEach(book =>
            {
                string nameCompare = book.publishingCompany.Name.ToUpper();
                if (nameCompare.Contains(name)) { BooksByPublishingCompany.Add(book); }
            });
            return BooksByPublishingCompany;
        }

        /// <summary>
        /// Data base default in the repository.
        /// </summary>
        public static void PostDataBase()
        {
            Book book1 = new Book
            {
                Title = "Winning",
                author = new Author { Name = "Jack Welch" },
                publishingCompany = new PublishingCompany { Name = "Harper Collins" }
            };
            Insert(book1, Books);

            Book book2 = new Book
            {
                Title = "Divergent",
                author = new Author { Name = "Veronica Roth" },
                publishingCompany = book1.publishingCompany
            };
            Insert(book2, Books);

            Book book3 = new Book
            {
                Title = "Murder on the Orient Express",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            Insert(book3, Books);

            Book book4 = new Book
            {
                Title = "The Hollow: A Hercule Poirot Mystery",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            Insert(book4, Books);

            Book book5 = new Book
            {
                Title = "And Then There Were None",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "Turtleback Books" }
            };
            Insert(book5, Books);

            Book book6 = new Book
            {
                Title = "Extreme Ownership",
                author = new Author { Name = "Jocko Willink" },
                publishingCompany = new PublishingCompany { Name = "St. Martin's Press" }
            };
            Insert(book6, Books);
        }
    }
}
