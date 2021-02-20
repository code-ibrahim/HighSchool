using System;
using System.Collections.Generic;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class Person
    {
        public Person()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
            StudentGrade = new HashSet<StudentGrade>();
        }

        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }
        public long? RoleId { get; set; }
        public string Gender { get; set; }
        public byte[] DateOfBirth { get; set; }
        public string Address { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
