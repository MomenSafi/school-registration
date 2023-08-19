using SchoolProject.context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public class TeacherRepository : ITeacherRepository
	{
		private readonly MyDbContext _myDbConnection;

		public TeacherRepository(MyDbContext myDbContext)
		{
			_myDbConnection = myDbContext;
		}
		public void CreateTeacher(Teacher teacher)
		{
			_myDbConnection.Teachers.Add(teacher);
			_myDbConnection.SaveChanges();
				
		}

		public void DeleteTeacher(int id)
		{
			Teacher teacher = (from teacherObj in _myDbConnection.Teachers
							   where teacherObj.TeacherId == id
							   select teacherObj).FirstOrDefault();
			_myDbConnection.Teachers.Remove(teacher);
			_myDbConnection.SaveChanges();
		}

		public List<Teacher> GetAllTeachers()
		{
			try
			{
                List<Teacher> teachers = (from teacherObj in _myDbConnection.Teachers
                                          select teacherObj).ToList();
                return teachers;

            }
			catch (Exception)
			{
				return null;
			}


        }
	}
}
