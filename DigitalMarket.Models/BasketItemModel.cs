namespace DigitalMarket.Models
{
    public class BasketItemModel<T>
    {
        public T Item { get; set; }
        public int Count { get; set; }
    }
}
