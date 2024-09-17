using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Review
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Message { get; set; } 
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PersonId { get; set; }
        public string PersonName {get;set;} 
        public string PersonLastName {get;set;} 
        public string PersonUrlAvatar {get;set;} 

    }
}