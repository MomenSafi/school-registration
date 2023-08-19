using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public interface ITeacherRepository
	{
		public List<Teacher> GetAllTeachers();

		public void CreateTeacher(Teacher teacher);

		public void DeleteTeacher(int id);

	}
}
