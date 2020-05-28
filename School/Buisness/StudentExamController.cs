using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
    class StudentExamController
    {
        private SchoolContext context;

        public StudentExamController()
        {
            this.context = new SchoolContext();
        }
        public List<StudentExam> GetAll()
        {
            return context.StudentsExams.ToList();
        }
        public StudentExam Get(int id)
        {
            return this.context.StudentsExams.FirstOrDefault(x => x.StudentId == id);
        }

        public void Add(StudentExam student)
        {
            this.context.StudentsExams.Add(student);
            this.context.SaveChanges();
        }

        public void Update(StudentExam student)
        {
            var studentItem = this.Get(student.StudentId);
            if (studentItem != null)
            {
                this.context.Entry(studentItem).CurrentValues.SetValues(student);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var studentItem = this.Get(id);
            this.context.StudentsExams.Remove(studentItem);
            this.context.SaveChanges();
        }

        internal void Add(Student newstudent)
        {
            throw new NotImplementedException();
        }
    }
}
