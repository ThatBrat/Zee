namespace Zee.DTOs.RequestModels
{
    public class CreateReviewRequestModel
    {
        public string Message { get; set; }
        public int NoOfStars { get; set; }
        public CreateCustomerRequestModel Customer {get; set;}
        public CreateProductRequestModel Product {get; set;}


    }
}