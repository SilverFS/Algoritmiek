using Algoritmiek.Containers;
using Algoritmiek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmiekTests
{
    [TestClass]
    public class GroupContainerTest
    {
        [TestMethod]
        public void ShouldReturnGroupListWhenCalled()
        {
            //Arrange
            GroupContainer groupContainer = new();
            GuestContainer guestContainer = new();
            List<Group> groupList;
            List<Guest> guestList;
            guestList = guestContainer.CreateGuestList();
            //Act
            groupList = groupContainer.FormGroups(guestList);
            //Assert
            Assert.IsNotNull(groupList);
        }

        [TestMethod]
        public void ShouldReturnProperGroupWhenCalled()
        {
            //Arrange
            GroupContainer groupContainer = new();
            GuestContainer guestContainer = new();
            List<Group> groupList;
            List<Guest> guestList;
            guestList = guestContainer.CreateGuestList();
            groupList = groupContainer.FormGroups(guestList);
            int count = 0;
            foreach (Group group in groupList)
            {
                count++;
            }
            //Act
            //
            //Assert
            Assert.AreEqual(count, groupList.Count);
        }
    }
}
