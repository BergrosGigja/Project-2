using System;
using System.ComponentModel.DataAnnotations;


namespace Models.Input
{/// <summary>
 /// Input model for a friend
 /// </summary>
    public class FriendInputModel
    {   /// <summary>
        /// name of friend
        /// </summary>
        [Required (ErrorMessage = "Name must be given", AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        /// <summary>
        /// email
        /// </summary>
        [Required]
        public string Email { get; set; }
        
        /// <summary>
        /// phone
        /// </summary>
        [Required]
        public string Phone { get; set; }
        
        /// <summary>
        /// address
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}