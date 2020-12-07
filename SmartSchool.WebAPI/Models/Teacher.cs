using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, int registration, string name, string surname)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Surname = surname;
        }

        public int Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public DateTime DateInit { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; } = null;

        public bool Active { get; set; } = true;
        public IEnumerable<Discipline> Discipline { get; set; }
    }
}