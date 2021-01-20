using System;

namespace DigitalMarket.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }     
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public ProductTypeModel ProductType { get; set; }
    }
}
