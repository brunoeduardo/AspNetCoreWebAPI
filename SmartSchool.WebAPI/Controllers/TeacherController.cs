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
        public IRepository _repo;

        public TeacherController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _repo.GetAllTeachers(true);
            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null) BadRequest("Nothing found");

            return Ok(teacher);
        }

        [HttpPost]

        public IActionResult Post(Teacher teacher)
        {
            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }

            return BadRequest("Something is wrong");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Teacher teacher)
        {
            var _teacher = _repo.GetTeacherById(id, false);
            if (_teacher == null) BadRequest("Nothing found");

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }

            return BadRequest("Something is wrong");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Teacher teacher)
        {

            var _teacher = _repo.GetTeacherById(id, false);
            if (_teacher == null) BadRequest("Nothing found");

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }

            return BadRequest("Something is wrong");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var _teacher = _repo.GetTeacherById(id, false);
            if (_teacher == null) BadRequest("Nothing found");

             _repo.Delete(_teacher);
            if (_repo.SaveChanges())
            {
                return Ok("Teacher deleted");
            }

            return BadRequest("Something is wrong");
        }
    }
}