using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.DAL.Models
{
    public class Product
    {
        [Key]        
        public Guid Id { get; set; }

        [Required]
        public Guid ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        [Range(0d, double.MaxValue, ErrorMessage = "Incorrect price. Value cannot be lesser than 0.")]
        public double Price { get; set; }

        [Required]
        public DateTime CreateDateUtc { get; set; }
    }
}