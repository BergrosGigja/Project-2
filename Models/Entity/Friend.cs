using System;
using System.Collections.Generic;

namespace Models.Entity
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
        //db specifics
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        
    }
}