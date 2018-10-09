using System;

namespace Models.Entity
{
    public class Tape
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Eidr { get; set; }
        public double Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}