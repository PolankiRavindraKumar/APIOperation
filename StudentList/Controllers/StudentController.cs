using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentList.Models;
using StudentList.Repository;

namespace StudentList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentRepository repo = new StudentRepository();

        [HttpGet("GetStudents")]
        public List<StudentModel> GetStudents()
        {
            List<StudentModel> students = repo.GetAllStudents();
            return students;
        }

        [HttpGet]
        public StudentModel GetStudentById(int id)
        {
            StudentModel student = repo.GetStudentById(id);
            return student;
        }

        [HttpPost]
        public int AddStudent(StudentModel student)
        {
            int count = repo.AddStudent(student);
            return count;
        }

        [HttpPut]
        public int UpdateStudent(StudentModel student)
        {
            int count = repo.UpdateStudent(student);
            return count;
        }

        [HttpDelete]
        public int DeleteStudent(int id)
        {
            int count = repo.DeleteStudent(id);
            return count;
        }
    }
}
