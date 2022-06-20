﻿using System.ComponentModel.DataAnnotations;
namespace Railway_Reservationsystem_WebAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        public string? CardOwnerName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? SecurityCode { get; set; }
    }
}
