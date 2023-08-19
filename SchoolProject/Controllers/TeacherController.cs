using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
	
	public class TeacherController : Controller
	{
		private readonly ITeacherRepository _teacherRepository;

		public TeacherController (ITeacherRepository teacherRepository)
		{
			_teacherRepository = teacherRepository;
		}
		[HttpGet]
		public ActionResult Index() 
		{
			List<Teacher> teachers = _teacherRepository.GetAllTeachers();
			return View(teachers);
		}
		[HttpGet]
		public ViewResult CreateTeacher()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateTeacher(Teacher teacher)
		{
			if (teacher != null)
			{
				_teacherRepository.CreateTeacher(teacher);
			}
			List<Teacher> teachers = _teacherRepository.GetAllTeachers();
			return View("Index" , teachers);
		}

		public ActionResult DeleteTeacher(int id) 
		{
			if (id > 0)
			{
				_teacherRepository.DeleteTeacher(id);
			}
			List<Teacher> teachers = _teacherRepository.GetAllTeachers();
			return View("Index", teachers);
		}

	}
}
