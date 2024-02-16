﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet_Ricardo.Campos.Data.Entities
{
    public class BankCard
    {
        [Key]
        public Guid ID { get; private set; }
        [ForeignKey("Customer")]
        [Required]
        public Guid CustomerID { get; set; }
        [Required]
        [StringLength(16,MinimumLength = 16,ErrorMessage = "Card number must be 16 digits")]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }

        public BankCard()
        {
            ID = Guid.NewGuid();
        }
    }
}
