using System;
using System.Collections.Generic;

namespace Models.Entity
{   /// <summary>
    /// Friend Entity
    /// </summary>
    public class Friend
    {   /// <summary>
        /// id of the friend
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// name of the friend
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// email for the friend
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// phone for the friend
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// address for the friend
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// database specific. Create date for the friend
        /// </summary>
        public DateTime DateCreated { get; set; }
        
        /// <summary>
        /// database specific. Modified date for the friend
        /// </summary>
        public DateTime DateModified { get; set; }
        
    }
}