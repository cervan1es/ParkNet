﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PARKNET.Data.Entities
{
    public class ParkingSpace
    {
        [Key]
        public Guid ParkingSpaceID { get; private set; }

        [Required]
        [ForeignKey("Park")]
        public Guid ParkID { get; set; }

        [Required]
        public string Coordinate { get; set; }

        public char? VehicleType { get; set; }

        [Required]
        public bool IsOccupied { get; set; } = false;


        public ParkingSpace()
        {
            ParkingSpaceID = Guid.NewGuid();
        }
    }
}
