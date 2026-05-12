using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del rol")]
        public string? Name { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
    }
}
