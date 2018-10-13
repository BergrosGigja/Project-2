using System;
using System.Collections.Generic;

namespace Models.Dtos
{
    public class TapeDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Eidr { get; set; }
        public double? AverageRating { get; set; }
        public List<BorrowDto> BorrowHistory { get; set; }
        public List<ReviewDto> ReviewHistory { get; set; }
    }
}