using System;
using System.Linq;
using System.Collections.Generic;

namespace DigitalMarket.Models
{
    public class Basket
    {
        public List<BasketItemModel<Guid>> Items { get; private set; } = new List<BasketItemModel<Guid>>();

        public int this[Guid id]
        {
            get
            {
                var item = Items.FirstOrDefault(entry => entry.Item == id);
                return item == null ? -1 : item.Count;
            }
            set
            {
                var item = Items.FirstOrDefault(entry => entry.Item == id);
                item.Count = value;
            }
        }

        public bool TryAddItem(Guid id, int count = 1) 
        {
            if (count < 1)
            {
                return false;
            }

            var item = Items.FirstOrDefault(entry => entry.Item == id);
            if (item != null)
            {
                item.Count += count;                
            }
            else
            {
                Items.Add(new BasketItemModel<Guid> { Item = id, Count = count });
            }

            return true;
        }

        public bool TryRemoveItem(Guid id)
        {
            var item = Items.FirstOrDefault(entry => entry.Item == id);
            if (item?.Item == id)
            {
                Items.Remove(item);
                return true;
            }

            return false;
        }

        public bool TryRemoveItem(Guid id, int count = 1)
        {
            if (count < 1)
            {
                return false;
            }

            var item = Items.FirstOrDefault(entry => entry.Item == id);
            if (item?.Item == id)
            {                
                item.Count -= count;

                if (item.Count < 1)
                {
                    Items.Remove(item);
                }                
                
                return true;
            }

            return false;
        }
    }
}