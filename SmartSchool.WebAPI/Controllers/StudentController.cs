using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;
        public StudentController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _repo.GetAllStudents(true);

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null) return BadRequest("Nothing here");

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);

        }

        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {
            var student = _mapper.Map<Student>(model);

            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Something is wrong");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null) return BadRequest("Student not found");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Something is wrong");
        }



        [HttpPatch("{id}")]

        public IActionResult Patch(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null) return BadRequest("Student not found");

            _mapper.Map(model, student);

            _repo.Update(student);

            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
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