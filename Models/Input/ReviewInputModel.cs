using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Input
{/// <summary>
 /// review input model
 /// </summary>
    public class ReviewInputModel
    {   /// <summary>
        /// id of friend
        /// </summary>
        [Required]
        public int FriendId { get; set; }

        /// <summary>
        /// id of the tape
        /// </summary>
        [Required]
        public int TapeId { get; set; }

        /// <summary>
        /// written review of the tape
        /// </summary>
        public string ReviewInput { get; set; }

        /// <summary>
        /// rating from 1-5
        /// </summary>
        [Required (ErrorMessage = "Choose a rating between 1 and 5")]
        [RegularExpression("(1|2|3|4|5)")]
        public int? Rating { get; set; }
    }
}