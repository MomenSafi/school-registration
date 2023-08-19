using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.viewModels;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller

	{
		private readonly IStudentRepository _studentRepository;

		private readonly ICourseRepository _courseRepository;
		public StudentController (IStudentRepository studentRepository , ICourseRepository courseRepository)
		{
			_studentRepository = studentRepository;
			_courseRepository = courseRepository;
		}
		[HttpGet]
		public ActionResult Index() 
		{
			List<Student> stdLst = _studentRepository.GetAllStudents();
			return View(stdLst);
		}
		[HttpGet]
		public ViewResult CreateStudent() 
		{
			return View();
		}
		[HttpPost]
		public ActionResult CreateStudent(Student student)
		{
			_studentRepository.CreateStudent(student);
            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View("Index" , stdLst);
		}

		public ViewResult DeleteStudent(int id)
		{
			_studentRepository.DeleteStudent(id);
            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View("Index", stdLst);
        }
        [HttpGet]
		public ActionResult RegisterStudent()
		{
			StudentCourseVM data = new StudentCourseVM();
			data.Courses = _courseRepository.GetAllCourses();
			data.Students = _studentRepository.GetAllStudents();
			return View(data);
		}
		[HttpPost]
		public ActionResult RegisterStudent(int studentId , int courseId) 
		{
			_studentRepository.RegisterStudent(studentId, courseId);
			return RedirectToAction("RegisterStudent");
		}
	}
}
