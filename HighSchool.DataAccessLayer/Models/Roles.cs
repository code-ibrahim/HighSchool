using System;
using System.Collections.Generic;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Person = new HashSet<Person>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
