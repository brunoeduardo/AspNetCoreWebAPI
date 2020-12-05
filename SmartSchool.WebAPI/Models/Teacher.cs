using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Discipline> Discipline { get; set; }   
    }
}