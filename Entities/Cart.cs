namespace Zee
{
    public class Cart : BaseEntity
    {
        public int CustomerId {get; set;}
        public Customer Customer { get; set; }
        public List<CartItem> Items { get; set; }
    }
}