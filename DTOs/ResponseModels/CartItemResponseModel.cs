namespace Zee.DTOs.ResponseModels
{
    public class CartItemResponseModel : BaseResponse 
    {
        public CartItemDto Data { get;set; }
    }

    public class CartItemsResponseModel : BaseResponse
    {
        public List<CartItemDto> Data { get; set; } = new List<CartItemDto>();
    }
}