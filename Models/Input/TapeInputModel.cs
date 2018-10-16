using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Input
{/// <summary>
 /// Input model for a video tape
 /// </summary>
    public class TapeInputModel
    {   /// <summary>
        /// title for the video tape
        /// </summary>
        [Required (ErrorMessage = "Title must be given", AllowEmptyStrings = false)]
        public string Title { get; set; }
        
        /// <summary>
        /// director name
        /// </summary>
        [Required (ErrorMessage = "Director Name must be given", AllowEmptyStrings = false)]
        public string DirectorName { get; set; }
        
        /// <summary>
        /// type of the video tape
        /// </summary>
        [Required (ErrorMessage =
            "Invalid type, must be VHS or Betamax")]
        [RegularExpression("(VHS)|(Betamax)")]
        public string Type { get; set; }
        
        /// <summary>
        /// release date for the video tape
        /// </summary>
        [Required]
        //[DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        /// Eidr number for the video tape
        /// </summary>
        [Required]
        public string Eidr { get; set; }
        
    }
}