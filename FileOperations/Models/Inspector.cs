using System;

using System.Linq;

namespace FileOperationsNS.Models
{
    public class Inspector
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ID { get; set; }

        public string? Password { get; set; } // NEW

        public bool IsAdmin { get; set; } // NEW
    }
}
