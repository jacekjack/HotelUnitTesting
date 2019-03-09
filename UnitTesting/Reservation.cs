using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancel(User user)
        {
            if (user.Admin || MadeBy == user)
                return true;

            return false;
        }

        public bool RoomReservation(Room room, User user)
        {
            if (room.Vacant)
            {
                room.Roomate = user;
                return true;
            }
            return false;

        }
         
        public class User
        {
            public bool Admin { get; set; }
            public string Name { get; set; }
        }

        public class Room
        {
            public bool Vacant { get; set; }
            public int Number { get; set; }
            public User Roomate { get; set; }
        }
    }
}
