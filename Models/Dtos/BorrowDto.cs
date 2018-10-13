using System;

namespace Models.Dtos
{
    public class BorrowDto
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public int TapeId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}