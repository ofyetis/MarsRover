using MarsRoverBusiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMarsRover
{
    [TestClass]
    public class RoverTest
    {
        #region IsPointHasValidFormat
        [TestMethod]
        public void IsPointHasValidFormat_CorrectFormatGiven_ReturnsTrue()
        {
            //Arrange
            string value = "1 2 N";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_CorrectFormatGiven_ReturnsTrue_2()
        {
            //Arrange
            string value = "1 2 W";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_CorrectFormatGiven_ReturnsTrue_3()
        {
            //Arrange
            string value = "1 2 S";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_CorrectFormatGiven_ReturnsTrue_4()
        {
            //Arrange
            string value = "1 2 E";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse()
        {
            //Arrange
            string value = "12 E";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse_2()
        {
            //Arrange
            string value = "1 2 F";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse_3()
        {
            //Arrange
            string value = "12N";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse_4()
        {
            //Arrange
            string value = "1 2";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse_5()
        {
            //Arrange
            string value = "1 2F";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsPointHasValidFormat_WrongFormatGiven_ReturnsFalse_6()
        {
            //Arrange
            string value = "N 1 3";
            Rover rover = new Rover();

            //Act
            var result = rover.IsPointHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }
        #endregion

        #region IsMovementHasValidFormat
        [TestMethod]
        public void IsMovementHasValidFormat_CorrectFormatGiven_ReturnsTrue()
        {
            //Arrange
            string value = "LMLMRRMRMMLM";
            Rover rover = new Rover();

            //Act
            var result = rover.IsMovementHasValidFormat(value);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsMovementHasValidFormat_WrongFormatGiven_ReturnsFalse()
        {
            //Arrange
            string value = "L M LM";
            Rover rover = new Rover();

            //Act
            var result = rover.IsMovementHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsMovementHasValidFormat_WrongFormatGiven_ReturnsFalse_2()
        {
            //Arrange
            string value = "lmlm";
            Rover rover = new Rover();

            //Act
            var result = rover.IsMovementHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsMovementHasValidFormat_WrongFormatGiven_ReturnsFalse_3()
        {
            //Arrange
            string value = "LMLM ";
            Rover rover = new Rover();

            //Act
            var result = rover.IsMovementHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsMovementHasValidFormat_WrongFormatGiven_ReturnsFalse_4()
        {
            //Arrange
            string value = " LMLM";
            Rover rover = new Rover();

            //Act
            var result = rover.IsMovementHasValidFormat(value);

            //Assert
            Assert.AreEqual(false, result);
        }

        #endregion

        #region IsRoverPointWithinBorder
        [TestMethod]
        public void IsRoverPointWithinBorder_PlateauModelGiven_ReturnsTrue()
        {
            //Arrange
            Rover rover = new Rover() { 
                CoordinateX = 1,
                CoordinateY = 2
            };
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };

            //Act
            var result = rover.IsRoverPointWithinBorder(plateau);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsRoverPointWithinBorder_PlateauModelGiven_ReturnsFalse()
        {
            //Arrange
            Rover rover = new Rover()
            {
                CoordinateX = 6,
                CoordinateY = 2
            };
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };

            //Act
            var result = rover.IsRoverPointWithinBorder(plateau);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsRoverPointWithinBorder_PlateauModelGiven_ReturnsFalse_2()
        {
            //Arrange
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 6
            };
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };

            //Act
            var result = rover.IsRoverPointWithinBorder(plateau);

            //Assert
            Assert.AreEqual(false, result);
        }
        #endregion

        #region MakeTheRoverMove
        [TestMethod]
        public void MakeTheRoverMove_RoversPlateauConsiderBoundaryAndCrashGiven_ReturnsTrue()
        {
            //Arrange
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = "N",
                Movement = "LMLMLMLMM".ToCharArray()
            };

            //Act
            var result = rover.MakeTheRoverMove(null, null, false);
            Result expectedResult = new Result();

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void MakeTheRoverMove_RoversPlateauConsiderBoundaryAndCrashGiven_ReturnsTrue_2()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = "N",
                Movement = "LMLMLMLMM".ToCharArray()
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = "E",
                Movement = "MMM".ToCharArray()
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);

            //Act
            var result = rover2.MakeTheRoverMove(squad, plateau, false);
            Result expectedResult = new Result();

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void MakeTheRoverMove_RoversPlateauConsiderBoundaryAndCrashGiven_ReturnsFalse()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = "N",
                Movement = "LMLMLMLMM".ToCharArray()
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 6,
                CoordinateY = 3,
                Direction = "E",
                Movement = "MMM".ToCharArray()
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);

            //Act
            var result = rover2.MakeTheRoverMove(squad, plateau, true);

            //Assert
            Result expectedResult = new Result()
            {
                Success = false,
                ErrorMessage = "The route is not within the boundaries!"
            };
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void MakeTheRoverMove_RoversPlateauConsiderBoundaryAndCrashGiven_ReturnsFalse_2()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = "N",
                Movement = "LMLMLMLMM".ToCharArray()
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 2,
                CoordinateY = 2,
                Direction = "W",
                Movement = "MMM".ToCharArray()
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);

            //Act
            var result = rover2.MakeTheRoverMove(squad, plateau, true);
            Result expectedResult = new Result()
            {
                Success = false,
                ErrorMessage = "The rover will crash with another rover with this route. Please change the route!"
            };

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        #endregion
    }
}
