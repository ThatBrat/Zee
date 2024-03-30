namespace Zee.DTOs.RequestModels
{
    public class CreateCartItemRequestModel
    {
       public double Price {get; set;}
        public string ImageUrl {get; set;}
        public int Quantity {get; set;}
        public string ProductName {get; set;}
        public CartDto Cart {get; set;}
           
    }

     public class UpdateCartItemRequestModel
    {
        public int Quantity {get; set;}
        public bool IsCheckedOut {get; set;}
    }
}