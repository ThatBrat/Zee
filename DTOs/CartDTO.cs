namespace Zee.DTOs
{
    public class CartDto
    {
        public int Id {get; set;}
        public CustomerDto Customer {get; set;}
        public List<CartItemDto> Items {get; set;}
    }
}