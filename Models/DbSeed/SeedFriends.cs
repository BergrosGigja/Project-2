using System.Collections.Generic;

namespace Models.DbSeed
{
    public class SeedFriends
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public List<SeedBorrowedTapes> tapes { get; set; }
    }
}