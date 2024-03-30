namespace Zee.DTOs.ResponseModels
{
    public class ProductResponseModel : BaseResponse 
    {
        public ProductDto Data { get;set; }
    }

    public class ProductsResponseModel : BaseResponse
    {
        public List<ProductDto> Data { get; set; } = new List<ProductDto>();
    }
}