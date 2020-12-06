using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SmartContext context;
        public StudentController(SmartContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Students);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = this.context.Students.FirstOrDefault(stu => stu.Id == id);

            if (student == null) return BadRequest("Nothing here");

            return Ok(student);

        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string surname)
        {
            var student = this.context.Students.FirstOrDefault(
                stu => stu.Name.Contains(name) && stu.Surname.Contains(surname)
            );

            if (student == null) return BadRequest("Nothing here");

            return Ok(student);

        }

        [HttpPost]

        public IActionResult Post(Student student)
        {
            this.context.Add(student);
            this.context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Student student)
        {
            var st = this.context.Students.AsNoTracking().FirstOrDefault(stu => stu.Id == id);
            if (st == null) return BadRequest("Student not found");

            this.context.Update(student);
            this.context.SaveChanges();
            return Ok(student);
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Student student)
        {
            var st = this.context.Students.AsNoTracking().FirstOrDefault(stu => stu.Id == id);
            if (st == null) return BadRequest("Student not found");

            this.context.Update(student);
            this.context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var student = this.context.Students.FirstOrDefault(stu => stu.Id == id);
            if (student == null) return BadRequest("Student not found");

            this.context.Remove(student);
            this.context.SaveChanges();

            return Ok("Delete OK");
        }
    }
}