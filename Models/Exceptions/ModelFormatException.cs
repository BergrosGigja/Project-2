using System;

namespace Models.Exceptions
{
    public class ModelFormatException : Exception
    {
        public ModelFormatException() : base("The Model Is Formatted Incorrectly")
        {
        }
        
        public ModelFormatException(string msg) : base(msg) 
        {
        }

        public ModelFormatException(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}