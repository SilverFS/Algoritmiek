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
            Event sortEvent = new();
            //create a box with all the content for one box
            // For the amount of boxes
            int count = sortEvent.boxList[0].rowList[0].seatList.Count;
            //Act
            int bruh = sortEvent.boxList[0].CountEmptyFirstSeats();
            //Assert
            Assert.AreEqual(bruh, count);
        }
    }
}