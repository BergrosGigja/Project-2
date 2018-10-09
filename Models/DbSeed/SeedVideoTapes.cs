using System;

namespace Models.DbSeed
{
    public class SeedVideoTapes
    {
        public int id { get; set; }
        public string title { get; set; }
        public string director_first_name { get; set; }
        public string director_last_name { get; set; }
        public string type { get; set; }
        public DateTime release_date { get; set; }
        public string eidr { get; set; }
    }
}