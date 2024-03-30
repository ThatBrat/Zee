namespace Zee.DTOs.ResponseModels
{
    public class OrderResponseModel : BaseResponse 
    {
        public OrderDto Data { get;set; }
    }

    public class OrdersResponseModel : BaseResponse
    {
        public List<OrderDto> Data { get; set; } = new List<OrderDto>();
    }
}