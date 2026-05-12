using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Display(Name = "Nombre del Usuario")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Contraseña")]
        public string PasswordHash { get; set; } = string.Empty;

    }
}