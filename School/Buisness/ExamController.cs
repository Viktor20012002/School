using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Buisness
{
    public class ExamController
    {
        private SchoolContext context;

        public ExamController()
        {
            this.context = new SchoolContext();
        }
        public List<Exam> GetAll()
        {
            return context.Exams.ToList();
        }
        public Exam Get(int id)
        {
            return this.context.Exams.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Exam exam)
        {
            this.context.Exams.Add(exam);
            this.context.SaveChanges();
        }

        public void Update(Exam exam)
        {
            var examItem = this.Get(exam.Id);
            if (examItem != null)
            {
                this.context.Entry(examItem).CurrentValues.SetValues(exam);
                this.context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var examItem = this.Get(id);
            this.context.Exams.Remove(examItem);
            this.context.SaveChanges();
        }
    }
}