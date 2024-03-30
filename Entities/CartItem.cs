namespace Zee
{
    public class CartItem : BaseEntity
    {
        public double Price {get; set;}
        public string ImageUrl {get; set;}
        public string ProductName {get; set;}
        public int Quantity {get; set;}
        public int CartId {get; set;}
        public int SellerId {get; set;}
        public Cart Cart {get; set;}
        public List<CartItemOrder> CartItemOrders {get; set;}
        
        public bool IsCheckedOut {get; set;}
       
    }
}