using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime DateInit { get; set; }

        public bool Active { get; set; }
    }
}