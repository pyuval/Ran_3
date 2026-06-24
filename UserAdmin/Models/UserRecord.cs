using System;
using System.Linq;

namespace UserAdmin
{
    // --------------------------------------------------------- DATA MODELS ---------------------------------------------------------
    public class UserRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
    }
}
