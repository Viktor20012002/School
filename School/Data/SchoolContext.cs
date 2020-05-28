using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using School.Models;

namespace School.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentExam> StudentsExams { get; set; }
        public virtual DbSet<StudentSubject> StudentsSubjects { get; set; }
        public virtual DbSet<StudentsTeachers> StudentsTeachers { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public object Id { get; internal set; }
        public object Name { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=. \\SQLEXPRESS;Database=School;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Exams__SubjectId__38996AB5");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(10);
            });

            modelBuilder.Entity<StudentExam>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ExamId });

                entity.Property(e => e.Grade).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentsExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsExams_Exams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsExams)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsExams_Students");
            });

            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.Property(e => e.Grade).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsSubjects_Students");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentsSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsSubjects_Subjects");
            });

            modelBuilder.Entity<StudentsTeachers>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.TeacherId });

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsTeachers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsTeachers_Students");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentsTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsTeachers_Teachers");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Teachers__Subjec__6A30C649");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
