using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Victor_Library_Antom_City_ASPNETCORE.Models
{
    public class PublishingCompany
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public static int Count = 1;
        public int NumberOfBooks = 0;
    }
}
