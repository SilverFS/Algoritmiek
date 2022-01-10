using Algoritmiek;
using AlgoritmiekTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmiekTests
{
    [TestClass]
    public class GuestListTest
    {
        [TestMethod]
        public void ShouldGetAllUsersWhenFunctionProvides()
        {
            //Arrange
            GuestMockup mockup = new GuestMockup();
            List<Guest> list;
            //Act
            list = mockup.CreateGuests();
            //Assert
            Assert.IsNotNull(list);
            Assert.AreNotEqual(1, list.Count);
            Assert.AreEqual(mockup.guestCount, list.Count);

        }

        [TestMethod]
        public void ShouldGetAllBoxesWhenFunctionProvides()
        {
            //Arrange
            GuestMockup mockup = new GuestMockup();
            List<Box> boxesList;
            //Act
            boxesList = mockup.CreateBoxes();


            //Assert
            Assert.IsNotNull(boxesList);
            //Assert sub lists too

        }
    }
}
