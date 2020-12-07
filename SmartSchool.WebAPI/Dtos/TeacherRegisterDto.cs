using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class TeacherRegisterDto
    {
        public int Id { get; set; }

        public int Registration { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public DateTime DateInit { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; } = null;

        public bool Active { get; set; } = true;
    }
}