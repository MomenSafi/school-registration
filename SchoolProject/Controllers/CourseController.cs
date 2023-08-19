using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
	public class CourseController : Controller
	{
		private readonly ICourseRepository _courseRepository;
		private readonly ITeacherRepository _teacherRepository;

		public CourseController(ICourseRepository courseRepository ,ITeacherRepository teacherRepository)
		{
			_courseRepository = courseRepository;
			_teacherRepository = teacherRepository;
		}
		[HttpGet]
		public ActionResult Index()
		{
			List<Course> courses = _courseRepository.GetAllCourses();
			return View();
		}
		[HttpGet]
		public ViewResult CreateCourse()
		{
			List<Teacher> teachers = _teacherRepository.GetAllTeachers();
			return View(teachers);
		}

		[HttpPost]
		public ActionResult CreateCourse(Course course)
		{
			if (course != null)
			{
				_courseRepository.CreateCourse(course);
			}
			List<Course> courses = _courseRepository.GetAllCourses();
			return View("Index", courses);
		}

		public ActionResult DeleteCourse(int id)
		{
			if (id > 0)
			{
				_courseRepository.DeleteCourse(id);
			}
			List<Course> courses = _courseRepository.GetAllCourses();
			return View("Index", courses);
		}
	}
}
