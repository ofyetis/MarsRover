using System.Text.RegularExpressions;

namespace MarsRoverBusiness
{
    public class Plateau
    {
        public int UpperRightX { get; set; }
        public int UpperRightY { get; set; }

        /// <summary>
        /// It checks the string upper-right co-ordinate value of the plateau, if it matches with the format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsPointHasValidFormat(string value)
        {
            Regex regex = new Regex(@"^(\d+)\s(\d+)$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }
    }
}
