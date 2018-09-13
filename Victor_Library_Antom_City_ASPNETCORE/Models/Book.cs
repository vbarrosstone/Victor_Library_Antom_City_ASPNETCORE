using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Victor_Library_Antom_City_ASPNETCORE.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public static int Count = 1;
        public Author author { get; set; }
        public PublishingCompany publishingCompany { get; set; }
    }
}
