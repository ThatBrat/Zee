namespace Zee.DTOs.ResponseModels
{
    public class PaymentResponseModel : BaseResponse 
    {
        public PaymentDto Data { get;set; }
    }

    public class PaymentsResponseModel : BaseResponse
    {
        public List<PaymentDto> Data { get; set; } = new List<PaymentDto>();
    }
}