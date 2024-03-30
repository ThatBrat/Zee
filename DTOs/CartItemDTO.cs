using Zee.DTOs.RequestModels;

namespace Zee.DTOs
{
    public class CartItemDto
    {
        public int Id {get; set;}
        public double Price {get; set;}
        public string ImageUrl {get; set;}
        public string ProductName {get; set;}
        public int Quantity {get; set;}
        public int CartId {get; set;}
        public CartDto Cart {get; set;}
         public CreateOrderRequestModel Order {get; set;}
        public int OrderId {get; set;}
        public bool IsCheckedOut {get; set;}
        public int SellerId {get; set;}
    }

    
}