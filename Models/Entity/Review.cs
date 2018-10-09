namespace Models.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public int TapeId { get; set; }
        public string ReviewInput { get; set; }
    }
}