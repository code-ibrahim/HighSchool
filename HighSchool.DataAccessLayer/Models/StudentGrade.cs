using System;
using System.Collections.Generic;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class StudentGrade
    {
        public long PersonId { get; set; }
        public long CourseId { get; set; }
        public byte[] Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
