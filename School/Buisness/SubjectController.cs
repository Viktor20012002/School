using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
   public class SubjectController
    {
        private SchoolContext context;

        public SubjectController()
        {
            this.context = new SchoolContext();
        }
        public List<Subject> GetAll()
        {
            return context.Subjects.ToList();
        }
        public Subject Get(int id)
        {
            return this.context.Subjects.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Subject student)
        {
            this.context.Subjects.Add(student);
            this.context.SaveChanges();
        }

        public void Update(Subject student)
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
            this.context.Subjects.Remove(studentItem);
            this.context.SaveChanges();
        }
    }
}
