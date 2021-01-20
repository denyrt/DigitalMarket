using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Models
{
    public class BasketChangeItemModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int? Count { get; set; }
    }
}
