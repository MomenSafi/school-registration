using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
	public class RoomController : Controller
	{
		private readonly IRoomRepository _RoomRepository;

		public RoomController(IRoomRepository roomRepository)
		{
			_RoomRepository = roomRepository;
		}
		[HttpGet]
		public ActionResult Index()
		{
			List<Romm> romms = _RoomRepository.GetAllRooms();
			return View();
		}
		[HttpGet]
		public ViewResult CreateRoom()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateRoom(Romm room)
		{
			if (room != null)
			{
				_RoomRepository.CreateRoom(room);
			}
			List<Romm> romms = _RoomRepository.GetAllRooms();
			return View("Index", romms);
		}

		public ActionResult DeleteRoom(int id)
		{
			if (id > 0)
			{
				_RoomRepository.DeleteRoom(id);
			}
			List<Romm> romms = _RoomRepository.GetAllRooms();
			return View("Index", romms);
		}

	}
}
