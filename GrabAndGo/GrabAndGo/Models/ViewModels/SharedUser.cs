using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrabAndGo.Models.ViewModels
{
    public class SharedUser
    {
        [Required(ErrorMessage = "Please enter and email")]
        [EmailAddress]
        public string SharedUserEmail { get; set; }
    }
}
