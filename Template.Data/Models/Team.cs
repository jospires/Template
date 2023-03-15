using System;
using System.Collections.Generic;

namespace Template.Data.Models
{
    public partial class Team
    {
        public Team()
        {
            Developers = new HashSet<Developer>();
            Projects = new HashSet<Project>();
        }

        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Developer> Developers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
