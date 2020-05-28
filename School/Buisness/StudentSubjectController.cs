using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
  public  class StudentSubjectController
    {
        private SchoolContext context;

        public StudentSubjectController()
        {
            this.context = new SchoolContext();
        }
        public List<StudentSubject> GetAll()
        {
            return context.StudentsSubjects.ToList();
        }
        public StudentSubject Get(int id)
        {
            return this.context.StudentsSubjects.FirstOrDefault(x => x.StudentId == id);
        }

        public void Add(StudentSubject student)
        {
            this.context.StudentsSubjects.Add(student);
            this.context.SaveChanges();
        }

        public void Update(StudentSubject student)
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
            this.context.StudentsSubjects.Remove(studentItem);
            this.context.SaveChanges();
        }
    }
}
