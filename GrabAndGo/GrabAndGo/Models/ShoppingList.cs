using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrabAndGo.Models
{
    public class ShoppingList
    {
        [Key]
        public int ListID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ListName { get; set; }
    }
}
