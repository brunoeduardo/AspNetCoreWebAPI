using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Course
    {
        public Course() { }

        public Course(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}