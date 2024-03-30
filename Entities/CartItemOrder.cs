namespace Zee
{
    public class CartItemOrder : BaseEntity
    {
         public int OrderId {get; set;}
        public Order Order {get; set;}
        public int CartItemId {get; set;}
        public CartItem Item {get;set;}
    }
}