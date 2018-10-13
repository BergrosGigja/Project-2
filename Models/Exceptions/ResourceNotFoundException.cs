using System;

namespace Models.Exceptions
{/// <summary>
 /// Exception class to throw is resource is not found
 /// </summary>
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("This Resource Was Not Found")
        {
        }
        
        public ResourceNotFoundException(string msg) : base(msg)
        {
        }

        public ResourceNotFoundException(string msg, Exception inner) : base(msg, inner)
        {
        }
        
    }
}