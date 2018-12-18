using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.ViewModel
{
    class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsBusinessAccount { get; set; }

        public string BusinessName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string LinkWebsite { get; set; }
        public string Picture { get; set; }
    }
}
