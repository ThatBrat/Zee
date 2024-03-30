namespace Zee.DTOs.ResponseModels
{
    public class ReviewResponseModel : BaseResponse 
    {
        public ReviewDto Data { get;set; }
    }

    public class ReviewsResponseModel : BaseResponse
    {
        public List<ReviewDto> Data { get; set; } = new List<ReviewDto>();
    }
}