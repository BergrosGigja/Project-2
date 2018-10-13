using System;

namespace Models.Exceptions
{/// <summary>
 /// exception class to throw if the input model is invalid
 /// </summary>
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