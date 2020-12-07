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
    public class TeacherController : ControllerBase
    {
        public IRepository _repo;
        private readonly IMapper _mapper;

        public TeacherController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var teachers = _repo.GetAllTeachers(true);
            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(teachers));
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null) BadRequest("Nothing found");

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return Ok(teacherDto);
        }

        [HttpPost]

        public IActionResult Post(TeacherRegisterDto model)
        {

            var teacher = _mapper.Map<Teacher>(model);

            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }

            return BadRequest("Something is wrong");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null) BadRequest("Nothing found");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }

            return BadRequest("Something is wrong");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null) BadRequest("Nothing found");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }

            return BadRequest("Something is wrong");
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetTeacherById(id, false);
            if (teacher == null) BadRequest("Nothing found");

            _repo.Delete(teacher);
            if (_repo.SaveChanges())
            {
                return Ok("Teacher deleted");
            }

            return BadRequest("Something is wrong");
        }
    }
}