using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish.Core.Exceptions
{
    public class InvalidAppOperationException : AppException
    {
        public InvalidAppOperationException(string message) : base(message)
        {
        }

        public override string Code { get; } = "invalid_operation_exception";

    }
}
