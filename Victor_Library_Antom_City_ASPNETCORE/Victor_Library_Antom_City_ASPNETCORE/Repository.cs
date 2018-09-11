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

        public static int VerifyAuthorInRepository(string input)
        {
            if (Authors.Any() == false) { return -1; }
            else
            {
                foreach (Author author in Authors)
                {
                    if (author.Name.Equals(input)) { return author.Id; }
                }
                return -1;
            }
        }

        public static void PostAuthorToRepository(Author author)
        {
            if (!string.IsNullOrEmpty(author.Name)) { };
            if (VerifyAuthorInRepository(author.Name) == -1)
            {
                author.Id = Author.Count;
                Author.Count++;
                author.NumberOfBooks++;
                Authors.Add(author);
            }
        }

        public static int VerifyPublishingCompany(string input)
        {
            if (Publishers.Any() == false) { return -1; }
            else
            {
                foreach (PublishingCompany publisher in Publishers)
                {
                    if (publisher.Name.Equals(input)) { return publisher.Id; }
                }
                return -1;
            }
        }
        public static void PostPublishingCompanyToRepository(PublishingCompany publishingCompany)
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

        public static int VerifyBookInRepository(string input)
        {
            if (Books.Any() == false) { return -1; }
            else
            {
                foreach (Book book in Books)
                {
                    if (book.Title.Equals(input)) { return book.Id; }
                }
                return -1;
            }
        }
        public static void PostBookToRepository(Book book)
        {
            if (!string.IsNullOrEmpty(book.Title)) { };

            int indexBook = VerifyBookInRepository(book.Title);
            if (indexBook == -1)
            {
                book.Id = Book.Count;
                Book.Count++;
                int indexAuthor = VerifyAuthorInRepository(book.author.Name);
                if (indexAuthor == -1)
                {
                    PostAuthorToRepository(book.author);
                }
                else
                {
                    book.author = Authors[indexAuthor - 1];
                    book.author.NumberOfBooks++;
                }

                int indexPublishingCompany = VerifyPublishingCompany(book.publishingCompany.Name);
                if (indexPublishingCompany == -1)
                {
                    PostPublishingCompanyToRepository(book.publishingCompany);
                }
                else
                {
                    book.publishingCompany = Publishers[indexPublishingCompany - 1];
                    book.publishingCompany.NumberOfBooks++;
                }
                Books.Add(book);
            }
        }
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

        public static void PostDataBase()
        {
            Book book1 = new Book
            {
                Title = "Winning",
                author = new Author { Name = "Jack Welch" },
                publishingCompany = new PublishingCompany { Name = "Harper Collins" }
            };
            PostBookToRepository(book1);

            Book book2 = new Book
            {
                Title = "Divergent",
                author = new Author { Name = "Veronica Roth" },
                publishingCompany = book1.publishingCompany
            };
            PostBookToRepository(book2);

            Book book3 = new Book
            {
                Title = "Murder on the Orient Express",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            PostBookToRepository(book3);

            Book book4 = new Book
            {
                Title = "The Hollow: A Hercule Poirot Mystery",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "William Morrow & Co" }
            };
            PostBookToRepository(book4);

            Book book5 = new Book
            {
                Title = "And Then There Were None",
                author = new Author { Name = "Agatha Christie" },
                publishingCompany = new PublishingCompany { Name = "Turtleback Books" }
            };
            PostBookToRepository(book5);

            Book book6 = new Book
            {
                Title = "Extreme Ownership",
                author = new Author { Name = "Jocko Willink" },
                publishingCompany = new PublishingCompany { Name = "St. Martin's Press" }
            };
            PostBookToRepository(book6);
        }
    }
}
