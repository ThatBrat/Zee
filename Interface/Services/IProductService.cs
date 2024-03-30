using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IProductService
    {   
        Task<BaseResponse> CreateProductAsync(CreateProductRequestModel model , int id);
        Task<ProductResponseModel> GetById(int id, int sellerId);
        Task<ProductResponseModel> GetByProductName(string productName, int sellerId);
        Task<ProductResponseModel> GetProductByProductName(string productName);
        Task<ProductResponseModel> GetProductById(int productId);
        Task<ProductsResponseModel> GetBySellerId(int id);
        Task<ProductsResponseModel> GetAllProducts();
        Task<BaseResponse> UpdateProduct(UpdateProductRequestModel updatedProduct, string productName, int sellerId);   
        // Task<BaseResponse> DeleteProductAsync(int id); 

    }
}