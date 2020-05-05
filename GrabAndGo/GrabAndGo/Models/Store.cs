using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrabAndGo.Models
{
    public class Store
    {
        [Key]
        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Please enter a street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public string State { get; set; }

        public int ZipCode { get; set; }

        //Creates a list of aisles that are a part of this store
        //private List<Aisle> aisles = new List<Aisle>();

        //allows the ability to iterate through the aisles of this store
        //public virtual IEnumerable<Aisle> Ailes => aisles;
    }
}
