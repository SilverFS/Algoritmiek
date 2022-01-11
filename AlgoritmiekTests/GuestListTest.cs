using Algoritmiek.Models;
using AlgoritmiekTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmiekTests
{
    [TestClass]
    public class GuestListTest
    {
        [TestMethod]
        public void ShouldGetAllUsersWhenFunctionProvides()
        {
            //Arrange
            GuestMockup mockup = new();
            List<Guest> list;
            //Act
            list = mockup.CreateGuests();
            //Assert
            Assert.IsNotNull(list);
            Assert.AreNotEqual(1, list.Count);
            Assert.AreEqual(mockup.guestCount, list.Count);

        }
    }
}
