using System;

namespace Specflow.Roslyn
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            :base(message)
        {
            
        }
    }
}