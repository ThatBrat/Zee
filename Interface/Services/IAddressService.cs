using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface IAddressService
    {
        Task<BaseResponse> CreateAddressAsync(CreateAddressRequestModel model);
        
    }
}