namespace Zee
{
    public class Order  : BaseEntity
    {
        public int CustomerId {get; set;}
        public Customer Customer {get; set;}
        public Payment Payment {get; set;}
        public int SellerId {get; set;}
        public Seller Seller {get; set;}
        public Address DeliveryAddress {get; set;}
        // public double[] Positions {get; set;}
        // public double Distance {get; set;}
        public int RateValue {get; set;}
        public bool DeliveryIsVerifiedByCustomer {get; set;}
        public bool DeliveryIsVerifiedBySeller {get; set;}
        public string RefNo {get; set;}
        // public double TotalPrice {get; set;}
        public List<CartItemOrder> CartItemOrders {get; set;}
        public Order()
        {
            // Positions = new double[4]; 
        }
    }
}