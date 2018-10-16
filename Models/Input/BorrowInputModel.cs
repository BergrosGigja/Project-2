using System;

namespace Models.Input
{
    public class BorrowInputModel
    {
        public int FriendId { get; set; }
        public int TapeId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}