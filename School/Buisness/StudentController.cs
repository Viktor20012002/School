using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
    public class StudentController
    {
        private SchoolContext context;

        public StudentController()
        {
            this.context = new SchoolContext();
        }
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public Student Get(int id)
        {
            return this.context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Student student)
        {
            this.context.Students.Add(student);
            this.context.SaveChanges();
        }

        public void Update(Student student)
        {
            var studentItem = this.Get(student.Id);
            if (studentItem != null)
            {
                this.context.Entry(studentItem).CurrentValues.SetValues(student);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var studentItem = this.Get(id);
            this.context.Students.Remove(studentItem);
            this.context.SaveChanges();
        }
    }
}