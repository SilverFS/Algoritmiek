using Algoritmiek;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmiekTests
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void ShouldReturnCountAllSeatsWhenCalled()
        {
            //Arrange
            Event sortEvent = new();
            int seatNumber = 0;
            foreach (Box box in sortEvent.boxList)
            {
                foreach (Row row in box.rowList)
                {
                    foreach (Seat seat in row.seatList)
                    {
                        seatNumber++;
                    }
                }
            }
            //Act
            int seatCount = sortEvent.CountAllSeats();
            //Assert
            Assert.AreEqual(seatNumber, seatCount);
        }

        [TestMethod]
        public void ShouldReturnBoolEnoughSeatsForGuests()
        {
            //Arrange
            Event sortEvent = new();
            int seatCount = sortEvent.CountAllSeats();
            int guestCount = sortEvent.guestList.Count;
            bool notEnoughSeats = true;
            if (guestCount > seatCount)
            {
                notEnoughSeats = false;
            }
            //Act
            bool allSeats = sortEvent.CheckRoomSeats();
            //Assert
            Assert.AreEqual(allSeats, notEnoughSeats);
        }

        //Checks if group is placed or not
        private bool GroupPlacedInBox(List<Box> boxList, Group oneGroup)
        {
            int guestsInGroup = 0;
            foreach (Box box in boxList)
            {
                for (int i = 0; i < box.rowList.Count; i++)
                {
                    foreach (Seat seat in box.rowList[i].seatList)
                    {
                        //if seat is occupied and group_id of guests equals group_id of group:
                        if (seat.guest != null && seat.guest.group_id == oneGroup.group_id)
                        {
                            guestsInGroup++;
                        }
                    }
                }
            }
            int total = oneGroup.children.Count + oneGroup.adults.Count;
            if (guestsInGroup == total)
            {
                return true;
            }
            return false;
        }


        [TestMethod]
        public void ShouldPlaceGroupInBox()
        {
            //Arrange
            Event sortEvent = new();
            //Act
            sortEvent.PlaceGroupsInBox();
            //Assert
            //check if a minimum of one group is placed
            Group singleGroupPlaced = sortEvent.groupList.Where(x => x.isPlaced == true).ToList()[0];
            //Assert.IsTrue(singleGroupPlaced > 0);
            //
            Assert.IsTrue(GroupPlacedInBox(sortEvent.boxList, singleGroupPlaced));
        }

        [TestMethod]
        public void ShouldPlaceSingleGuestInBox()
        {
            //Arrange
            Event sortEvent = new();
            //Act
            sortEvent.PlaceGroupsInBox();
            //Assert           
            Assert.IsTrue(sortEvent.singleGuests[0].isPlaced);
        }
    }
}
