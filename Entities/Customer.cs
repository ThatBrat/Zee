namespace Zee
{
    public class Customer : BaseEntity
    {
        public int UserId {get; set;}
        public User User {get; set;}
        public Cart Cart {get; set;}
        public List<Order> Orders {get; set;}
        public List<Review> Reviews {get; set;}
        public List<Payment> Payments {get; set;}
        
    }
}