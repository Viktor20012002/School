using System;
using System.Collections.Generic;
using School.Buisness;

namespace School.Models
{
    public partial class Exam
    {
        public Exam()
        {
            StudentsExams = new HashSet<StudentExam>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<StudentExam> StudentsExams { get; set; }
        
    }
}
