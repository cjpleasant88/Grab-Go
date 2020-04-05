using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrabAndGo.Models
{
    public class Aisle
    {
        public int StoreID { get; set; }
        public int AisleID { get; set; }
        public int CategoryType { get; set; }
    }
}
