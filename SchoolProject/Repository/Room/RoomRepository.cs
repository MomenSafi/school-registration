using SchoolProject.context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
	public class RoomRepository : IRoomRepository
	{
		private readonly MyDbContext _myDbConnection;

		public RoomRepository(MyDbContext myDbContext)
		{
			_myDbConnection = myDbContext;
		}
		public void CreateRoom(Romm room)
		{
			_myDbConnection.Rooms.Add(room);
			_myDbConnection.SaveChanges();

		}

		public void DeleteRoom(int id)
		{
			Romm room = (from roomObj in _myDbConnection.Rooms
							   where roomObj.RoomId == id
							   select roomObj).FirstOrDefault();
			_myDbConnection.Rooms.Remove(room);
			_myDbConnection.SaveChanges();
		}

		public List<Romm> GetAllRooms()
		{
            try
            {
                List<Romm> rooms = (from roomObj in _myDbConnection.Rooms
                                    select roomObj).ToList();
                return rooms;

            }
            catch (Exception ex)
            {
                return null;
            }
           

		}
	}
}
