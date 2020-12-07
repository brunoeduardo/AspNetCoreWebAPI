using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {

        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines)
                .ThenInclude(sd => sd.Discipline)
                .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return query.ToArray();

        }

        public Student[] GetAllStudentsByDisciplineId(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines)
                .ThenInclude(sd => sd.Discipline)
                .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(student => student.Id == studentId);

            return query.ToArray();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDisciplines)
                .ThenInclude(sd => sd.Discipline)
                .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(stu => stu.Id == studentId);

            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(d => d.Discipline)
                .ThenInclude(sd => sd.StudentsDisciplines)
                .ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return query.ToArray();
        }

        public Teacher[] GetAllTeachersByDisciplineId(int disciplineId, bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(d => d.Discipline)
                .ThenInclude(sd => sd.StudentsDisciplines)
                .ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(s => s.Discipline.Any(
                d => d.StudentsDisciplines.Any(
                    ad => ad.DisciplineId == disciplineId)
            ));

            return query.ToArray();
        }

        public Teacher GetTeacherById(int teacherId, bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(d => d.Discipline)
                .ThenInclude(sd => sd.StudentsDisciplines)
                .ThenInclude(s => s.Student);
            }

            query = query.AsNoTracking()
            .OrderBy(s => s.Id)
            .Where(teacher => teacher.Id == teacherId);

            return query.FirstOrDefault();
        }
    }
}