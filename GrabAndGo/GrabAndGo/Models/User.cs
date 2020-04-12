using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrabAndGo.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public int ListID { get; set; }
        public int StorePref { get; set; }
    }
}
