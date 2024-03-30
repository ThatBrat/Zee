using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;

namespace Zee.Interface.Services
{
    public interface ICartItemService
    {
        // Task<BaseResponse> CreateCartItemAsync(CreateCartItemRequestModel model);
        Task<CartItemsResponseModel> GetCartItemsByCustomerIdAsync(int CustomerId);
        Task<CartItemResponseModel> GetCartItemByCartItemIdAsync(int id);
        Task<BaseResponse> ChangeCartItemQuantityAsync(UpdateCartItemRequestModel updatedCartItem, int id);
        Task<BaseResponse> DeleteCartItemByIdAsync(int id);
        Task<BaseResponse> UpdateCartItemStatusAsync( int id);
        


    }
}