namespace Models.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public int TapeId { get; set; }
        public string ReviewInput { get; set; }
        public int? Rating { get; set; }
    }
}