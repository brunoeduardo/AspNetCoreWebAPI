using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentDiscipline> StudentsDiscipline { get; set; }
        public DbSet<Course> Courses {get; set;}
        public DbSet<Discipline> Diciplines { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentDiscipline>()
            .HasKey(SD => new { SD.StudentId, SD.DisciplineId });

            builder.Entity<StudentCourse>()
            .HasKey(SD => new { SD.StudentId, SD.CourseId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "Michael", "Doll"),
                    new Teacher(2, 2, "Jacob", "Smith"),
                    new Teacher(3, 3, "Tina", "Kent"),
                    new Teacher(4, 4, "Karen", "Harper"),
                    new Teacher(5, 5, "Susan", "Lee"),
                });

            builder.Entity<Course>()
                .HasData(new List<Course>() {
                    new Course(1, "Technologies for Business"),
                    new Course(2, "Information systems"),
                    new Course(3, "Computer science")
                });

            builder.Entity<Discipline>()
                .HasData(new List<Discipline>{
                    new Discipline(1, "Math", 1, 1),
                    new Discipline(2, "Math", 1, 3),
                    new Discipline(3, "Physics", 2, 3),
                    new Discipline(4, "Portuguese", 3, 1),
                    new Discipline(5, "English", 4, 1),
                    new Discipline(6, "English", 4, 2),
                    new Discipline(7, "English", 4, 3),
                    new Discipline(8, "Programming", 5, 1),
                    new Discipline(9, "Programming", 5, 2),
                    new Discipline(10, "Programming", 5, 3)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Kevin", "Hart", "33225555", DateTime.Parse("05/28/2005")),
                    new Student(2, 2, "Will", "Smith", "3354288", DateTime.Parse("05/28/2005")),
                    new Student(3, 3, "Ice", "Cube", "55668899", DateTime.Parse("05/28/2005")),
                    new Student(4, 4, "Jack", "Black", "6565659", DateTime.Parse("05/28/2005")),
                    new Student(5, 5, "Karen", "Gilian", "565685415", DateTime.Parse("05/28/2005")),
                    new Student(6, 6, "Katy", "Perry", "456454545", DateTime.Parse("05/28/2005")),
                    new Student(7, 7, "Stefani", "Joanne", "9874512", DateTime.Parse("05/28/2005"))
                });

            builder.Entity<StudentDiscipline>()
                .HasData(new List<StudentDiscipline>() {
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 5, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 5, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 5 }
                });
        }
    }
}


