using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Reserve
{
    public class ReserveGetDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonName {get;set;}
        public string PersonLastName {get;set;}
        public string RoomName { get; set; }
        public string RoomType { get; set; }   
        public decimal RoomPrice { get; set; }
        public string HotelName {get;set;}
        public string FoodDescription { get; set; }
        public decimal FoodPrice { get; set; }        
        public string FlightName { get; set; }
        public string FlightDuration {get;set;}
        public decimal FlightPrice {get;set;}
        public string TourName { get; set; }
        public decimal TourPrice {get;set;}
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int PeopleCuantity { get; set; }
        public decimal Total { get; set; }
    }
}