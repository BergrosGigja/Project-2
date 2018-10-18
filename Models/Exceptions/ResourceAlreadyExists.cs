using System;

namespace Models.Exceptions
{
    public class ResourceAlreadyExists : Exception
    {
        public ResourceAlreadyExists() : base("This Resource Already Exists")
        {
        }
        
        public ResourceAlreadyExists(string msg) : base(msg) 
        {
        }

        public ResourceAlreadyExists(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}