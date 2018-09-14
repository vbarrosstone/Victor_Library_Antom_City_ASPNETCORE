using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Victor_Library_Antom_City_ASPNETCORE.Models
{
    public class Author
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public static uint Count = 1;
        public uint NumberOfBooks = 0;
    }
}
