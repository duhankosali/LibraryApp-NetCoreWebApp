using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.DTOs
{
    public class BorrowBookDto
    {
        public string BorrowName { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsInLibrary { get; set; } = false;
    }
}
