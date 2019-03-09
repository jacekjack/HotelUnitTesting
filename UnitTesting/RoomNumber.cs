using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnitTesting.Reservation;

namespace UnitTesting
{
    public class RoomNumber
    {

        public int GetNumber(int roomnb_min, int roomnb_max)
        {
            Random rnd_int = new Random();
            int nmb = rnd_int.Next(roomnb_min, roomnb_max);
            return nmb;
        }

        public void GenRooms(int roomnb_min, int roomnb_max)
        {
            List<Room> RoomList = new List<Room>();
            for (int x = roomnb_min; x < roomnb_max; x++)
            {
                RoomList.Add(new Room { Number = x, Roomate = null, Vacant = true });
            }
        }
    }
}
