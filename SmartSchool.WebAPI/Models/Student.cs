using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Student
    {
        public Student() { }


        public Student(int id, int registration, string name, string surname, string phone, DateTime birth)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Surname = surname;
            this.Phone = phone;
            this.Birth = birth;
        }
        public int Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public DateTime Birth { get; set; }

        public DateTime DateInit { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; } = null;

        public bool Active { get; set; } = true;

        public IEnumerable<StudentDiscipline> StudentsDisciplines { get; set; }
    }
}