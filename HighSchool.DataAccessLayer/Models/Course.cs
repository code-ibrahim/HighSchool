using System;
using System.Collections.Generic;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
            StudentGrade = new HashSet<StudentGrade>();
        }

        public long CourseId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
