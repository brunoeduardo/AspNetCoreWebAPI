using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly SmartContext context;

        public TeacherController(SmartContext context)
        {
            this.context = context;

        }


        [HttpGet]

        public IActionResult Get()
        {
            return Ok(this.context.Teachers);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var teacher = this.context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) BadRequest("Nothing found");

            return Ok(teacher);
        }

        [HttpGet("ByName")]

        public IActionResult GetByName(string name)
        {
            var teacher = this.context.Teachers.FirstOrDefault(t => t.Name.Contains(name));
            if (teacher == null) BadRequest("Nothing found");

            return Ok(teacher);
        }

        [HttpPost]

        public IActionResult Post(Teacher teacher)
        {
            this.context.Add(teacher);
            this.context.SaveChanges();
            return Ok(teacher);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Teacher teacher)
        {
            var _teacher = this.context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (_teacher == null) BadRequest("Nothing found");

            this.context.Update(teacher);
            this.context.SaveChanges();

            return Ok(teacher);
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Teacher teacher)
        {

            var _teacher = this.context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (_teacher == null) BadRequest("Nothing found");

            this.context.Update(teacher);
            this.context.SaveChanges();

            return Ok(teacher);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var _teacher = this.context.Teachers.FirstOrDefault(t => t.Id == id);
            if (_teacher == null) BadRequest("Nothing found");

            this.context.Remove(_teacher);
            this.context.SaveChanges();
            return Ok("Teacher deleted");
        }
    }
}