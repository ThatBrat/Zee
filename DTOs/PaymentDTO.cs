namespace Zee.DTOs
{
    public class PaymentDto
    {
        public int Id {get; set;}
        public CustomerDto CustomerDto {get; set;}
        public SellerDto SellerDto {get; set;}
        public AdminDto AdminDto {get; set;}
        public double Amount {get; set;}
        public OrderDto OrderDto {get; set;}
        public PaymentStatus Status {get; set;}
    }
}