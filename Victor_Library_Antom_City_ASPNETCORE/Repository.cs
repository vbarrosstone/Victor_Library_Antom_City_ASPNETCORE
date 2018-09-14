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
        /// Verify if the Author already exist in the Author Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int VerifyAuthor(string input)
        {
            if (!Authors.Any()) { return -1; }
            else
            {
                //var Query = 
                //    from author in Authors
                //    where author.Name.Equals(input)
                //    select (int) author.Id;

                foreach (Author author in Authors)
                {
                    if (author.Name.Equals(input)) { return (int) author.Id; }
                }
                return -1;
            }
        }

        /// <summary>
        /// Post the new Author to the Repository.
        /// </summary>
        /// <param name="author"></param>
        public static void InsertAuthor(Author author)
        {
            if (!string.IsNullOrEmpty(author.Name)) { };
            if (VerifyAuthor(author.Name) == -1)
            {
                author.Id = Author.Count;
                Author.Count++;
                author.NumberOfBooks++;
                Authors.Add(author);
            }
        }

        /// <summary>
        /// Verify if the Publisher already exist in the Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int VerifyPublishingCompany(string input)
        {
            if (!Publishers.Any()) { return -1; }
            else
            {
                foreach (PublishingCompany publisher in Publishers)
                {
                    if (publisher.Name.Equals(input)) { return (int) publisher.Id; }
                }
                return -1;
            }
        }
        /// <summary>
        /// Post the new Publisher to the Repository.
        /// </summary>
        /// <param name="publishingCompany"></param>
        public static void InsertPublishingCompany(PublishingCompany publishingCompany)
        {
            if (!string.IsNullOrEmpty(publishingCompany.Name)) { };
            if (VerifyPublishingCompany(publishingCompany.Name) == -1)
            {
                publishingCompany.Id = PublishingCompany.Count;
                PublishingCompany.Count++;
                publishingCompany.NumberOfBooks++;
                Publishers.Add(publishingCompany);
            }
        }

        /// <summary>
        /// Verify if already exist in the Repository.
        /// If doesn't exist, the method returns -1.
        /// Else return the ID.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int VerifyBook(string input)
        {
            if (!Books.Any()) { return -1; }
            else
            {
                foreach (Book book in Books)
                {
                    if (book.Title.Equals(input)) { return (int) book.Id; }
                }
                return -1;
            }
        }
        /// <summary>
        /// Post to the Repository.
        /// </summary>
        /// <param name="publishingCompany"></param>
        public static void InsertBook(Book book)
        {
            if (!string.IsNullOrEmpty(book.Title)) { };

            int indexBook = VerifyBook(book.Title);
            if (indexBook == -1)
            {
                book.Id = Book.Count;
                Book.Count++;
                int indexAuthor = VerifyAuthor(book.author.Name);
                if (indexAuthor == -1)
                {
                    InsertAuthor(book.author);
                }
                else
                {
                    book.author = Authors[indexAuthor - 1];
                    book.author.NumberOfBooks++;
                }

                int indexPublishingCompany = VerifyPublishingCompany(book.publishingCompany.Name);
                if (indexPublishingCompany == -1)
                {
                    InsertPublishingCompany(book.publishingCompany);
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
            InsertBook(book1);

            Book book2 = new Book
            {
                Title = "Divergent",
                author = new Author { Name = "Veronica Roth" },
                publishingCompany = book1.publishingCompany
            };
            InsertBook(book2);

            Book book3 = new Book
            {
                Title = "Murder on the Orient Express",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            InsertBook(book3);

            Book book4 = new Book
            {
                Title = "The Hollow: A Hercule Poirot Mystery",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            InsertBook(book4);

            Book book5 = new Book
            {
                Title = "And Then There Were None",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "Turtleback Books" }
            };
            InsertBook(book5);

            Book book6 = new Book
            {
                Title = "Extreme Ownership",
                author = new Author { Name = "Jocko Willink" },
                publishingCompany = new PublishingCompany { Name = "St. Martin's Press" }
            };
            InsertBook(book6);
        }
    }
}
