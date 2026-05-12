using System;
using System.Collections.Generic;
using System.Text;

namespace JAMCWEOG.Entities.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

    }
}