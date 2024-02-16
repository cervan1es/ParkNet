﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class Ticket
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Vehicle")]
        [Required]
        public Guid VehicleID { get; set; }
        [ForeignKey("ParkingSpace")]
        [Required]
        public Guid ParkingSpaceID { get; set; }
        [ForeignKey("TicketTariff")]
        [Required]  
        public Guid TicketTariffID { get; set;}
        [Required]
        public DateTime CheckIn { get; set; } = DateTime.Now;
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public decimal Price { get; set; }
        

        public Ticket()
        {
            ID = Guid.NewGuid();
        }
    }
}
