using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>() {
            new Student() {
                Id = 1,
                Name = "Jony",
                Surname = "Doll",
                Phone = "123456"
            },
            new Student() {
                Id = 2,
                Name = "Mary",
                Surname = "Doll",
                Phone = "123456"
            },
            new Student() {
                Id = 3,
                Name = "Tony",
                Surname = "Doll",
                Phone = "123456"
            }
        };
        public StudentController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);

        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(stu => stu.Id == id);

            if (student == null) return BadRequest("Nothing here");

            return Ok(student);

        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = Students.FirstOrDefault(
                stu => stu.Name.Contains(name) && stu.Surname.Contains(surname)
            );

            if (student == null) return BadRequest("Nothing here");

            return Ok(student);

        }

        [HttpPost]

        public IActionResult Post(Student student)
        {
            student.Name = "Post";

            return Ok(student);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Student student)
        {
            student.Name = "Put";

            return Ok(student);
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Student student)
        {
            student.Name = "Patch";

            return Ok(student);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            return Ok("Delete OK");
        }
    }
}