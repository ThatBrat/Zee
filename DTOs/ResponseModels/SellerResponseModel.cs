namespace Zee.DTOs.ResponseModels
{
    public class SellerResponseModel : BaseResponse 
    {
        public SellerDto Data { get;set; }
    }

    public class SellersResponseModel : BaseResponse
    {
        public List<SellerDto> Data { get; set; } = new List<SellerDto>();
    }
}