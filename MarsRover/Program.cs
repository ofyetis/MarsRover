using MarsRoverBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Taking plateau's upper-right co-ordinates
            var plateau = getUpperRightCoordinates();
            var squad = new Squad();
            while (true)
            {
                //Taking a rover information from the user
                var rover = getRover(plateau, squad);
                //Adding rover to the squad
                squad.Add(rover);
                ConsoleKey response;
                do
                {
                    Console.Write("Do you want to enter another rover information?(Y/N): ");
                    response = Console.ReadKey(true).Key;
                    if (response != ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                if (response == ConsoleKey.Y)
                {
                    continue;
                }
                else
                {
                    Result result = squad.Move(plateau, false);
                    if (result.Success == true)
                    {
                        foreach (var item in squad.rovers)
                        {
                            Console.WriteLine(item.CoordinateX + " " + item.CoordinateY + " " + item.Direction);
                        }
                    }
                    else
                    {
                        Console.WriteLine(result.ErrorMessage);
                    }
                    break;
                }

            }
            Console.ReadKey();
        }

        /// <summary>
        /// Taking upper-right co-ordinates of the plateau
        /// </summary>
        /// <returns></returns>
        private static Plateau getUpperRightCoordinates()
        {
            //creating a new Plateau instance
            Plateau plateau = new Plateau();
            while (true)
            {
                Console.Write("Write the upper-right co-ordinates in a format like '{x point} {y point}' (e.g. '5 6' ): ");
                string _val = Console.ReadLine();
                //displaying an error message if coordinates that is entered, has invalid format
                if (!plateau.IsPointHasValidFormat(_val))
                {
                    Console.WriteLine("Write in the correct format!");
                    continue;
                }
                //Getting rid of space
                string[] upperRightCoordinates = _val.Split(" ");
                //Assigning plateau's coordinates
                plateau.UpperRightX = Convert.ToInt32(upperRightCoordinates[0]);
                plateau.UpperRightY = Convert.ToInt32(upperRightCoordinates[1]);
                return plateau;
            }
        }
        private static Rover getRover(Plateau plateau, Squad squad)
        {
            //creating a new Rover instance
            Rover rover = new Rover();
            while (true)
            {
                Console.WriteLine("Write the start point of the rover in a format like '{x point} {y point} {direction}' (e.g. '1 2 N' ): ");
                string stringCoordinates = Console.ReadLine();
                //displaying an error message if coordinates that is entered, has invalid format
                if (!rover.IsPointHasValidFormat(stringCoordinates))
                {
                    Console.WriteLine("Write in the correct format!");
                    continue;
                };
                //Getting rid of space
                string[] roverInformations = stringCoordinates.Split(" ");
                //Assigning rover's coordinates and direction
                rover.CoordinateX = Convert.ToInt32(roverInformations[0]);
                rover.CoordinateY = Convert.ToInt32(roverInformations[1]);
                rover.Direction = roverInformations[2];
                //displaying an error message if coordinates that is entered, is out of border
                if (!rover.IsRoverPointWithinBorder(plateau))
                {
                    Console.WriteLine("The coordinate that you entered is out of border.");
                    continue;
                }
                //displaying an error message if coordinates that is entered, is belongs to another rover which is placed before.
                if (squad.rovers.Count > 0 && squad.rovers.FindIndex(x => x.CoordinateX == rover.CoordinateX && x.CoordinateY == rover.CoordinateY) > -1)
                {
                    Console.WriteLine("There is another rover at this point.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Write the movement command letters which are 'L', 'R', 'M', without any space between them: ");
                string movementLetters = Console.ReadLine();
                //displaying an error message if movement commands that is entered, has invalid format
                if (!rover.IsMovementHasValidFormat(movementLetters))
                {
                    Console.WriteLine("Write in the correct format!");
                    continue;
                };
                rover.Movement = movementLetters.ToCharArray();
                break;
            }
            return rover;
        }
    }
}
