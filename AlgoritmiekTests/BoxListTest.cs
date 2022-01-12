using Algoritmiek.Models;
using AlgoritmiekTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmiekTests
{
    [TestClass]
    public class BoxListTest
    {
        [TestMethod]
        public void ShouldGetAllBoxesWhenFunctionProvides()
        {
            //Arrange
            BoxMockup mockup = new();
            List<Box> boxesList;
            //Act
            boxesList = mockup.CreateBoxes();


            //Assert
            Assert.IsNotNull(boxesList);
            //Assert sub lists too

        }
    }
}
