using System;

namespace Models.Entity
{   /// <summary>
    /// Borrow entity
    /// </summary>
    public class Borrow
    {   /// <summary>
        /// id of the loan
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// id of the friend
        /// </summary>
        public int FriendId { get; set; }
        
        /// <summary>
        /// id of the tape
        /// </summary>
        public int TapeId { get; set; }
        
        /// <summary>
        /// borrow date for the video tape
        /// </summary>
        public DateTime BorrowDate { get; set; }
        
        /// <summary>
        /// return date of the video tape
        /// </summary>
        public DateTime? ReturnDate { get; set; }
    }
}