using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void CreateStudent(Student student);
        public void DeleteStudent(int idStudent);
        public void RegisterStudent(int studentId, int courseId);
    }
}
