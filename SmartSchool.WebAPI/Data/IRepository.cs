using System.Threading.Tasks;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        Task<Student[]> GetAllStudentsAsync(bool includeTeacher = false);

        Student[] GetAllStudentsByDisciplineId(int studentId, bool includeTeacher = false);

        Student GetStudentById(int disciplineId, bool includeTeacher = false);

        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent = false);

        Teacher[] GetAllTeachersByDisciplineId(int disciplineId, bool includeStudent = false);

        Teacher GetTeacherById(int teacherId, bool includeStudent = false);

    }
}