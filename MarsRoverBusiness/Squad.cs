using System;
using System.Collections.Generic;

namespace MarsRoverBusiness
{
    public class Squad
    {
        public List<Rover> rovers;

        /// <summary>
        /// Initializing rovers property of Squad class inside constructor
        /// </summary>
        public Squad()
        {
            rovers = new List<Rover>();
        }

        /// <summary>
        /// It adds rover to the rovers property of squad
        /// </summary>
        /// <param name="rover"></param>
        public void Add(Rover rover)
        {
            rovers.Add(rover);
        }

        /// <summary>
        /// It calculates all the movements of the rovers which are inside squad. 
        /// It takes two parameters. considerBoundaryAndCrash paramter is for being able to ignore border pass and crash cases.
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="considerBoundaryAndCrash"></param>
        /// <returns>"Result"</returns>
        public Result Move(Plateau plateau = null, bool considerBoundaryAndCrash = false)
        {
            Result result = new Result();
            foreach (var rover in rovers)
            {
                result = rover.MakeTheRoverMove(this, plateau, considerBoundaryAndCrash);
                if (result.Success == false)
                {
                    break;
                }
            }
            return result;
        }
    }
}
