using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GrabAndGo.Models
{
    public class Section
    {
        [Key]
        public int SectionID { get; set; }
        public string SectionName { get; set; }
    }   
}
