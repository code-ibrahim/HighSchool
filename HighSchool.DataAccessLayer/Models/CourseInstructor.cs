using System;
using System.Collections.Generic;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class CourseInstructor
    {
        public long CourseId { get; set; }
        public long PersonId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
