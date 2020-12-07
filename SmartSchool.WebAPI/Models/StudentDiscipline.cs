using System;

namespace SmartSchool.WebAPI.Models
{
    public class StudentDiscipline
    {
        public StudentDiscipline() { }

        public StudentDiscipline(int studentId, int disciplineId)
        {
            this.StudentId = studentId;
            this.DisciplineId = disciplineId;
        }

        public DateTime DateInit { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; }
     
        public int? Grade { get; set; } = null;

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

    }
}