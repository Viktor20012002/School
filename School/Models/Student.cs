using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentsExams = new HashSet<StudentExam>();
            StudentsSubjects = new HashSet<StudentSubject>();
            StudentsTeachers = new HashSet<StudentsTeachers>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<StudentExam> StudentsExams { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        public virtual ICollection<StudentsTeachers> StudentsTeachers { get; set; }
       
    }
}
