namespace MarsRoverBusiness
{
    public class Result
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Assigning initial values to the Success and ErrorMessage properties
        /// </summary>
        public Result()
        {
            Success = true;
            ErrorMessage = "";
        }
    }
}
