using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRoverBusiness
{
    public class Rover
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Direction { get; set; }
        public char[] Movement { get; set; }

        /// <summary>
        /// It calculates the new last position's coordinates and direction.
        /// It takes three parameter: squad, plateau and considerBoundaryAndCrash
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="plateau"></param>
        /// <param name="considerBoundaryAndCrash"></param>
        /// <returns></returns>
        public Result MakeTheRoverMove(Squad squad = null, Plateau plateau = null, bool considerBoundaryAndCrash = false)
        {
            int coordinateX = CoordinateX;
            int coordinateY = CoordinateY;
            //Find the rover index in squad to compare it later.
            int roverIndex = -1;
            int idx = -1;
            if (squad != null && squad.rovers.Count > 0)
            {
                roverIndex = squad.rovers.FindIndex(x => x.CoordinateX == coordinateX && x.CoordinateY == coordinateY);
            };
            foreach (var movement in Movement)
            {
                //switch the movement letter
                switch (movement)
                {
                    case 'M':
                        switch (Direction) //If direction is "E" or "W" the rover will move on the X axis else it will move on Y axis
                        {
                            case "E":
                                coordinateX += 1;
                                break;
                            case "N":
                                coordinateY += 1;
                                break;
                            case "W":
                                coordinateX -= 1;
                                break;
                            case "S":
                                coordinateY -= 1;
                                break;
                            default:
                                break;
                        }
                        //Controlling if the calculated point is out of border or not.
                        if (considerBoundaryAndCrash && (coordinateX > plateau.UpperRightX || coordinateY > plateau.UpperRightY))
                        {
                            return new Result()
                            {
                                Success = false,
                                ErrorMessage = "The route is not within the boundaries!"
                            };
                        }
                        if (considerBoundaryAndCrash)
                        {
                            //Finding the index of rover that is at the same point with this rover.
                            if (squad != null && squad.rovers.Count > 0)
                            {
                                idx = squad.rovers.FindIndex(x => x.CoordinateX == coordinateX && x.CoordinateY == coordinateY);
                            }
                            //if there is rover at the corresponding point and this is an another rover, return error message
                            if (idx > -1 && idx != roverIndex)
                            {
                                return new Result()
                                {
                                    Success = false,
                                    ErrorMessage = "The rover will crash with another rover with this route. Please change the route!"
                                };
                            }
                        }
                        break;
                    case 'L':
                        switch (Direction)
                        {
                            case "E":
                                Direction = "N";
                                break;
                            case "N":
                                Direction = "W";
                                break;
                            case "W":
                                Direction = "S";
                                break;
                            case "S":
                                Direction = "E";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 'R':
                        switch (Direction)
                        {
                            case "E":
                                Direction = "S";
                                break;
                            case "N":
                                Direction = "E";
                                break;
                            case "W":
                                Direction = "N";
                                break;
                            case "S":
                                Direction = "W";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            return new Result()
            {
                Success = true,
                ErrorMessage = ""
            }; ;
        }

        /// <summary>
        /// It checks the string co-ordinate value of the rover, if it matches with the format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsPointHasValidFormat(string value)
        {
            Regex regex = new Regex(@"^(\d+)\s(\d+)\s([NWSE])$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It checks the string movement commands value of the rover, if it matches with the format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsMovementHasValidFormat(string value)
        {
            Regex regex = new Regex(@"^([LMR])+$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It checks if the rovers co-ordinate is within the boundaries.
        /// It takes the plateau as parameter.
        /// </summary>
        /// <param name="plateau"></param>
        /// <returns></returns>
        public bool IsRoverPointWithinBorder(Plateau plateau)
        {
            if ((CoordinateX < 0 || CoordinateX > plateau.UpperRightX) ||
                    (CoordinateY < 0 || CoordinateY > plateau.UpperRightY))
            {
                return false;
            }
            return true;
        }

    }
}
