namespace SquareFish.Core.Exceptions
{
    public class InvalidInputException : AppException
    {
        public InvalidInputException(string message) : base(message)
        {
        }

        public override string Code { get; } = "invalid_input_exception";
    }
}
