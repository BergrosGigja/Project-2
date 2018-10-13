using System;
using System.Collections.Generic;
using Models.Dtos;

namespace Models.Entity
{/// <summary>
 /// Video Tape Entity
 /// </summary>
    public class Tape
    {
        /// <summary>
        /// id of the video tape
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// title of the video tape
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Director of the video tape
        /// </summary>
        public string DirectorName { get; set; }
        
        /// <summary>
        /// type of the video tape
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// release date for the video tape
        /// </summary>
        public DateTime ReleaseDate { get; set; }
        
        /// <summary>
        /// eidr number for the video tape
        /// </summary>
        public string Eidr { get; set; }
        
        /// <summary>
        /// rating for the video tape
        /// </summary>
        public double? AverageRating { get; set; }
        
        /// <summary>
        /// database specific. Creation date of the video tape
        /// </summary>
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// database specific. Modified date for the video tape
        /// </summary>
        public DateTime DateModified { get; set; }
    }
}