    using SchoolProject.context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;
        public StudentRepository(MyDbContext myDbContext)
        {
            _myDbConnection = myDbContext;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _myDbConnection.Students
                                          select stdsObj).ToList();
                return students; 

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void CreateStudent(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }

        public void DeleteStudent(int idStudent)
        {

            Student student = (from stdObj in _myDbConnection.Students
                               where stdObj.StudentId == idStudent
                               select stdObj).FirstOrDefault();
            _myDbConnection.Students.Remove(student);
            _myDbConnection.SaveChanges();

        }
        public void RegisterStudent(int studentId, int courseId)
        {
			StudentCourse obj = new()
			{
				CourseId = courseId,
				StudentId = studentId
			};
			_myDbConnection.StudentCourses.Add(obj);
            _myDbConnection.SaveChanges();

        }
    }
}
