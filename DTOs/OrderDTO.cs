namespace Zee.DTOs
{
    public class OrderDto
    {
        public int Id {get; set;}
        public CustomerDto CustomerDto {get; set;}
        public PaymentDto PaymentDto {get; set;}
        public SellerDto SellerDto {get; set;}
         public double[] Positions {get; set;}
        public double Distance {get; set;}
        public int RateValue {get; set;}
        public bool DeliveryIsVerifiedByCustomer {get; set;}
        public bool DeliveryIsVerifiedBySeller {get; set;}
        public string RefNo {get; set;}
        public double TotalPrice {get; set;}
        public List<CartItemDto> ItemDtos {get; set;}
        public AddressDto Address { get; set; }

        public List<CartItemOrderDto> CartItemOrderDtos {get; set;}
    
    }
}