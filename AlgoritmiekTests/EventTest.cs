using Algoritmiek;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
