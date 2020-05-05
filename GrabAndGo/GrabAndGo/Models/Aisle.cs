using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GrabAndGo.Models
{
    public class Aisle
    {
        [Key]
        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AisleID {get; set;}

        public int StoreID { get; set; }

        public int AisleNumber { get; set; }

        public int CategoryID { get; set; }
    }
}
 