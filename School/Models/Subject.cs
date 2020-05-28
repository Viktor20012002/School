using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Exams = new HashSet<Exam>();
            StudentsSubjects = new HashSet<StudentSubject>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Lessons { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
