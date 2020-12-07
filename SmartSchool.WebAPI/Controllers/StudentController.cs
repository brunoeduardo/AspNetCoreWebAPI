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
        public readonly IRepository _repo;
        public StudentController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllStudents(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false); 
            if (student == null) return BadRequest("Nothing here");

            return Ok(student);

        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }

            return BadRequest("Something is wrong");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Student student)
        {
            var st = _repo.GetStudentById(id, false);
            if (st == null) return BadRequest("Student not found");

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }

            return BadRequest("Something is wrong");
        }



        [HttpPatch("{id}")]

        public IActionResult Patch(int id, Student student)
        {
            var st = _repo.GetStudentById(id, false);
            if (st == null) return BadRequest("Student not found");

            _repo.Update(student);

            if (_repo.SaveChanges())
            {
                return Ok(student);
            }

            return BadRequest("Something is wrong");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null) return BadRequest("Student not found");

            _repo.Delete(student);
            if (_repo.SaveChanges())
            {
                return Ok("Student deleted");
            }

            return BadRequest("Something is wrong");
        }
    }
}