using Algoritmiek;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmiekTests
{
    [TestClass]
    public class BoxTest
    {
        [TestMethod]
        public void ShouldCountAllEmptySeatsInFirstRow()
        {
            //Arrange
            Event sortEvent = new();
            // For the amount of seats in the first row of the first box
            int count = sortEvent.boxList[0].rowList[0].seatList.Count;
            //Act
            int firstSeats = sortEvent.boxList[0].CountEmptyFirstSeats();
            //Assert
            Assert.AreEqual(firstSeats, count);
        }

        [TestMethod]
        public void ShouldCountAllOtherEmptySeats()
        {
            //Arrange
            Event sortEvent = new();
            int count = 0;
            for (int seatCount = 1; seatCount < sortEvent.boxList[0].rowList.Count; seatCount++)
            {
                //foreach amount of seats in the other rows. 
                count = count + sortEvent.boxList[0].rowList[seatCount].seatList.Count;
            }
            //Act
            int otherSeats = sortEvent.boxList[0].CountOtherEmptySeats();
            //Assert
            Assert.AreEqual(otherSeats, count);
        }
    }
}