using SchoolProject.context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public class CourseRepository : ICourseRepository
	{
		private readonly MyDbContext _myDbConnection;

		public CourseRepository(MyDbContext myDbContext)
		{
			_myDbConnection = myDbContext;
		}
		public void CreateCourse(Course course)
		{
			_myDbConnection.Courses.Add(course);
			_myDbConnection.SaveChanges();

		}

		public void DeleteCourse(int id)
		{
			Course course = (from courseObj in _myDbConnection.Courses
							 where courseObj.CourseId == id
							   select courseObj).FirstOrDefault();
			_myDbConnection.Courses.Remove(course);
			_myDbConnection.SaveChanges();	
		}

		public List<Course> GetAllCourses()
		{
            try
            {
                List<Course> Courses = (from courseObj in _myDbConnection.Courses
                                        select courseObj).ToList();
                return Courses;

            }
            catch (Exception ex)
            {
                return null;
            }
           

		}
	}
}
