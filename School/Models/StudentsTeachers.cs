using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class StudentsTeachers
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
