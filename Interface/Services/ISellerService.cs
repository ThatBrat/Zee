using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface ISellerService
    {
        Task<BaseResponse> Register(CreateSellerRequestModel model);
        Task<SellerResponseModel> GetById(int id);
        Task<BaseResponse> UpdateSellerAsync(UpdateSellerRequestModel updatedSeller, int id);
        Task<BaseResponse> DeleteSellerAsync(int sellerId);
        Task<BaseResponse> VerifySellerAsync(int sellerId);
        Task<SellersResponseModel> GetSellers(); 



    }
}