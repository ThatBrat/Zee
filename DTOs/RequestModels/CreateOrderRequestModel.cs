namespace Zee.DTOs.RequestModels
{
    public class CreateOrderRequestModel 
    {
        public double TotalPrice {get; set;}
        public int SellerId {get; set;}
        public double[] Positions {get; set;}
        public double Distance {get; set;}
        public int RateValue {get; set;}
        public CreateAddressRequestModel Address {get; set;}
    }

     
}