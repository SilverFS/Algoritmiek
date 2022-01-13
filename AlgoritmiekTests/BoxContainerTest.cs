using Algoritmiek.Containers;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmiekTests
{
    [TestClass]
    public class BoxContainerTest
    {
        [TestMethod]
        public void ShouldReturnBoxListWhenCalled()
        {
            //Arrange
            BoxContainer boxContainer = new();
            List<Box> boxList;
            //Act
            boxList = boxContainer.CreateBoxes();
            //Assert
            Assert.IsNotNull(boxList);
        }

        [TestMethod]
        public void ShouldReturnProperBoxWhenCalled()
        {
            //Arrange
            BoxContainer boxContainer = new();
            List<Box> boxList;
            //Act
            boxList = boxContainer.CreateBoxes();
            //Assert
            Assert.AreEqual(1, boxList[0].box_id);
        }

        [TestMethod]
        public void ShouldReturnSeatFromBoxList()
        {
            //Arrange
            BoxContainer boxContainer = new();
            List<Box> boxList;
            //Act
            boxList = boxContainer.CreateBoxes();
            //Assert
            Assert.AreEqual(1, boxList[0].rowList[0].seatList[0].seat_id);
        }

        [TestMethod]
        public void ShouldReturnBoxListWithEmptySeatsInMind()
        {
            //Arrange
            BoxContainer boxContainer = new();
            List<Box> boxList;
            List<Box> sortedBoxList;
            boxList = boxContainer.CreateBoxes();
            //Act
            sortedBoxList = boxContainer.boxOrderList(boxList);
            //Assert
            Assert.AreEqual(boxList.Max(x => x.CountEmptyFirstSeats()), sortedBoxList[0].CountEmptyFirstSeats());
        }

        [TestMethod]
        public void ShouldReturnCountOfAllSeatsOfAllFirstRowsInBoxes()
        {
            //Arrange
            BoxContainer boxContainer = new();
            List<Box> boxList;
            List<Box> sortedBoxList;
            boxList = boxContainer.CreateBoxes();
            sortedBoxList = boxContainer.boxOrderList(boxList);
            int count = 0;
            foreach (Box box in sortedBoxList)
            {
                foreach (Seat seat in box.rowList[0].seatList)
                {
                    count++;
                }
            }
            //Act
            int seatCount = boxContainer.CountFirstRow(boxList);
            //Assert
            Assert.AreEqual(count, seatCount);
        }
    }
}
