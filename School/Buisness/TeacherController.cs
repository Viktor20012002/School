using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
   public class TeacherController
    {
        private SchoolContext context;

        public TeacherController()
        {
            this.context = new SchoolContext();
        }
        public List<Teacher> GetAll()
        {
            return context.Teachers.ToList();
        }
        public Teacher Get(int id)
        {
            return this.context.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Teacher student)
        {
            this.context.Teachers.Add(student);
            this.context.SaveChanges();
        }

        public void Update(Teacher student)
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
            this.context.Teachers.Remove(studentItem);
            this.context.SaveChanges();
        }
    }
}
