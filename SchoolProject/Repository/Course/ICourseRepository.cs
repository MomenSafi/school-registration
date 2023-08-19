using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public interface ICourseRepository
	{
		List<Course> GetAllCourses();
		public void CreateCourse(Course course);

		public void DeleteCourse(int id);
	}
}
