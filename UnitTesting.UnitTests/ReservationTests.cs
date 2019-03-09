using System;
using NUnit.Framework;
using static UnitTesting.Reservation;
using static UnitTesting.RoomNumber;


namespace UnitTesting.UnitTests
{
    [TestFixture]
    public class ReservationTest
    {
        [Test]
        public void CanBeCancel_UserAdmin_ReturnsTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancel(new User { Admin = true });

            Assert.That(result, Is.True);

        }
        [Test]
        public void GetNumber_GeneratingBetween()
        {
            var roomnumber = new RoomNumber();

            var result = roomnumber.GetNumber(100, 130);

            bool between = false;
            if (result > 100 && result < 130) between = true;
            Assert.That(between);
        }
        [Test]
        public void CanBeCancel_SameUserCancel_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancel(user);

            Assert.That(result, Is.True);

        }
        [Test]
        public void CanBeCancel_AnotherUserCancel_ReturnsFalse()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancel(new User { Admin = false });

            Assert.That(result, Is.False);

        }
        [Test]
        public void RoomReservation_RoomVacant_ReturnsTrue()
        {
            var reservation = new Reservation();

            var result = reservation.RoomReservation(new Room { Vacant = true, Number = 100, Roomate = null }, new User { Admin = false } );

            Assert.That(result, Is.True);
        }
        [Test]
        public void RoomReservation_RoomNotVacant_ReturnsFalse()
        {
            var reservation = new Reservation();

            var result = reservation.RoomReservation(new Room { Vacant = false, Number = 100, Roomate = null }, new User { Admin = false });

            Assert.That(result, Is.False);
        }
    }
}
