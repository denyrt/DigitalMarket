using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.Models
{
    public class BasketModel<T>
    {        
        public int Count => Items.Select(entry => entry.Count).Sum();

        public double Price { get; set; }

        public List<BasketItemModel<T>> Items { get; set; }
    }
}