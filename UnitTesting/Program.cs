using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnitTesting.Reservation;
using static UnitTesting.RoomNumber;

namespace UnitTesting
{
    class Program
    {
        public static int roomnb_min { get; set; } = 100;
        public static int roomnb_max { get; set; } = 130;

        static void Main(string[] args)
        {
            RoomNumber Rmnb = new RoomNumber();
            Console.WriteLine("Welcome to our Hotel, do you want to make a reservation? (Yes/No)");
            string answer = Console.ReadLine();
            
            if (answer.ToUpper().Equals("YES"))
            {
                Rmnb.GenRooms(roomnb_min, roomnb_max);
                Console.WriteLine("Wonderfull, what is your name?");
                User guest = new User { Admin = false, Name = Console.ReadLine() };

                bool IsNumber = false;
                int roomnb = Rmnb.GetNumber(roomnb_min, roomnb_max);
                while (!IsNumber)
                {
                    Console.WriteLine("Do you want a specified room? (pick a number from {0} to {1}, or No)", roomnb_min, roomnb_max);
                    answer = Console.ReadLine();
                    if (answer.ToUpper().Equals("NO")) break;
                        
                        try
                        {
                            roomnb = Int32.Parse(answer);
                            if (roomnb > roomnb_min && roomnb < roomnb_max) IsNumber = true;
                            else
                            {
                                Console.WriteLine("Sorry, we don't have that room, do you want to pick again? (Yes/No)");
                                answer = Console.ReadLine();
                                roomnb = Rmnb.GetNumber(roomnb_min, roomnb_max);
                                 if (!answer.ToUpper().Equals("YES")) break;
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Sorry, you don't tell a number, do you want to pick again? (Yes/No)");
                            answer = Console.ReadLine();
                            if (!answer.ToUpper().Equals("YES")) break;
                        }
                    
                }

                Console.WriteLine("So, your room is {0}. Here is the card. ", roomnb);
                Console.ReadLine();
            }
            else Console.WriteLine("That's bad. You know where the doors are!");
            Console.ReadLine();
        }
    }
}
