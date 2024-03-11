using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAppTv.Models
{
    public class Subscription
    {

        public int Id { get; set; }

        public string? CustomerSerial { get; set; }


        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }


        public float? Amount { get; set; }


        public string? PaymentMethod { get; set; }


        public string? PaymentStatus { get; set; }
    }

}
