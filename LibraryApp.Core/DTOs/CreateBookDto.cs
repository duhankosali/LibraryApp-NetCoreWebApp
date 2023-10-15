using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryApp.Core.DTOs
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string FilePath { get; set; }
        public bool IsInLibrary { get; set; } = true;
    }
}
