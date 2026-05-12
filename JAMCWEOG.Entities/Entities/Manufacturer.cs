using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string? Name { get; set; }
    }
}
