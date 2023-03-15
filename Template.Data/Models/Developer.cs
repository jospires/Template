using System;
using System.Collections.Generic;

namespace Template.Data.Models
{
    public partial class Developer
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
