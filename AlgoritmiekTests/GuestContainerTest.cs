using Algoritmiek.Containers;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmiekTests
{
    [TestClass]
    public class GuestContainerTest
    {
        [TestMethod]
        public void ShouldReturnGuestListWhenCalled()
        {
            //Arrange
            GuestContainer guestContainer = new();
            List<Guest> guestList;
            //Act
            guestList = guestContainer.CreateGuestList();
            //Assert
            Assert.IsNotNull(guestList);
        }

        [TestMethod]
        public void ShouldReturnProperGuestWhenCalled()
        {
            //Arrange
            GuestContainer guestContainer = new();
            List<Guest> guestList;
            //Act
            guestList = guestContainer.CreateGuestList();
            //Assert
            Assert.AreEqual(0, guestList[0].group_id);
        }

        [TestMethod]
        public void ShouldNotReturnOnTimeFalse()
        {
            GuestContainer guestContainer = new();
            List<Guest> guestList;
            //Act
            guestList = guestContainer.CreateGuestList();
            //Assert
            Assert.AreNotEqual(false, guestList[0].OnTime);
        }
    }
}
