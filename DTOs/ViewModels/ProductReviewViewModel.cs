using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.DTOs.ViewModels
{
    public class ProductReviewViewModel
    {
        public ProductResponseModel product { get; set; }
        public ReviewsResponseModel Reviews { get; set; }
    }

    public class ProductCartItemViewModel
    {
        public ProductResponseModel Product { get; set; }
        public CreateCartItemRequestModel CartItem { get; set; }
    }
}
