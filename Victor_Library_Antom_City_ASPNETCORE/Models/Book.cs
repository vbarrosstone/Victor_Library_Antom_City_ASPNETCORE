

namespace Victor_Library_Antom_City_ASPNETCORE.Models
{
    public class Book
    {
        public string Title { get; set; }
        public uint Id { get; set; }
        public static uint Count = 1;
        public Author author { get; set; }
        public PublishingCompany publishingCompany { get; set; }
    }
}
