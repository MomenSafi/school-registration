using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public interface IRoomRepository
	{
		public List<Romm> GetAllRooms();

		public void CreateRoom(Romm room);

		public void DeleteRoom(int id);
	}
}
