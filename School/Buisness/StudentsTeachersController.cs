using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
   public class StudentsTeachersController
    {
        private SchoolContext context;

        public StudentsTeachersController()
        {
            this.context = new SchoolContext();
        }
        public List<StudentsTeachers> GetAll()
        {
            return context.StudentsTeachers.ToList();
        }
        public StudentsTeachers Get(int id)
        {
            return this.context.StudentsTeachers.FirstOrDefault(x => x.StudentId == id);
        }

        public void Add(StudentsTeachers student)
        {
            this.context.StudentsTeachers.Add(student);
            this.context.SaveChanges();
        }

        public void Update(StudentsTeachers student)
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
            this.context.StudentsTeachers.Remove(studentItem);
            this.context.SaveChanges();
        }
    }
}
