using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            StudentsTeachers = new HashSet<StudentsTeachers>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<StudentsTeachers> StudentsTeachers { get; set; }
    }
}
