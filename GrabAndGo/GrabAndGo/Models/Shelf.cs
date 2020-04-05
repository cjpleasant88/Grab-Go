using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrabAndGo.Models
{
    public class Shelf
    {
        public int StoreID { get; set; }
        public int AisleID { get; set; }
        public int ShelfID { get; set; }
        public int SectionID { get; set; }

    }
}
