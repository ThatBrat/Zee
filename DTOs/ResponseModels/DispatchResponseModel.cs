namespace Zee.DTOs.ResponseModels
{
    public class DispatchResponseModel : BaseResponse 
    {
        public DispatchDto Data { get;set; }
    }

    public class DispatchesResponseModel : BaseResponse
    {
        public List<DispatchDto> Data { get; set; } = new List<DispatchDto>();
    }
}