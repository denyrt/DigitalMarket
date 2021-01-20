using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.DAL.Models
{
    public class ProductType
    {
        [Key]    
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}