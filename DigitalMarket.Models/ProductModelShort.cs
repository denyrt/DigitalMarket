using System;

namespace DigitalMarket.Models
{
    public class ProductModelShort
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public double Price { get; set; }
    }
}