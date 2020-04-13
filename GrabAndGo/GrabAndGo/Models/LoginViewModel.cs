using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GrabAndGo.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter and email")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
