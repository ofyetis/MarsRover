using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMarsRover
{
    [TestClass]
    public class PlateauTest
    {
        [TestMethod]
        public void IsPointHasValidFormatPlateau_CorrectFormatGiven_ReturnsTrue()
        {
            //Arrange
            string value = "5 5";

            //Act
            MarsRoverBusiness.Plateau plateau = new MarsRoverBusiness.Plateau();
            var result = plateau.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPointHasValidFormatPlateau_WrongFormatGiven_ReturnsFalse()
        {
            //Arrange
            string value = "55";

            //Act
            MarsRoverBusiness.Plateau plateau = new MarsRoverBusiness.Plateau();
            var result = plateau.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormatPlateau_WrongFormatGiven_ReturnsFalse_2()
        {
            //Arrange
            string value = "55 b";

            //Act
            MarsRoverBusiness.Plateau plateau = new MarsRoverBusiness.Plateau();
            var result = plateau.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormatPlateau_WrongFormatGiven_ReturnsFalse_3()
        {
            //Arrange
            string value = "5 5 ";

            //Act
            MarsRoverBusiness.Plateau plateau = new MarsRoverBusiness.Plateau();
            var result = plateau.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}
