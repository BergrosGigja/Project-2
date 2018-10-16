using Newtonsoft.Json;

namespace Models.Exceptions
{/// <summary>
 /// Exception model
 /// </summary>
    public class ExceptionModel
    {   /// <summary>
        /// return status code for the exception
        /// </summary>
        public int StatusCode { get; set; }
        
        /// <summary>
        /// message for the exception
        /// </summary>
        public string ExceptionMessage { get; set; }
        
        /// <summary>
        /// Json string from the object
        /// </summary>
        /// <returns>json string</returns>
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}