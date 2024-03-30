namespace Zee.DTOs.RequestModels
{
    public class CreateProductRequestModel
    {
        public double Price {get; set;}
        public string ImageUrl {get; set;}
        public int InitialQuantity {get; set;} 
        public int Quantity {get; set;}
        public string ProductName {get; set;}
    }

    public class UpdateProductRequestModel
    {
        public double Price {get; set;}
        public string ImageUrl {get; set;}
        public int InitialQuantity {get; set;} 
        public int Quantity {get; set;} 
        public string ProductName {get; set;}
    }
}