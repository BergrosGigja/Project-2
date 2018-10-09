using System;

namespace Models.Dtos
{
    public class TapeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Eidr { get; set; }
    }
}