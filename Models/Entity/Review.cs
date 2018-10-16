using System;

namespace Models.Entity
{/// <summary>
 /// Review Entity
 /// </summary>
    public class Review
    {   /// <summary>
        /// id of the review
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// id of the friend
        /// </summary>
        public int FriendId { get; set; }
        
        /// <summary>
        /// id of the video tape
        /// </summary>
        public int TapeId { get; set; }
        
        /// <summary>
        /// review text
        /// </summary>
        public string ReviewInput { get; set; }
        
        /// <summary>
        /// rating for the video tape
        /// </summary>
        public int? Rating { get; set; }
        
        /// <summary>
        /// database specific. Modified date of the review
        /// </summary>
        public DateTime DateModified { get; set; }
        
        /// <summary>
        /// database specific.  Creation date for the review
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}