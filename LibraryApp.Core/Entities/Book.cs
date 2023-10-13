using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string FilePath { get; set; }
        public bool IsInLibrary { get; set; }
        public string? Borrower { get; set; } // nullable
        public DateTime? FinishDate { get; set; } // nullable
    }
}
