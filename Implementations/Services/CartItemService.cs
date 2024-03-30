using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemService(ICustomerRepository customerRepository, ICartItemRepository cartItemRepository)
        {
            _customerRepository = customerRepository;
            _cartItemRepository = cartItemRepository;

        }

        // public async Task<BaseResponse> CreateCartItemAsync(CreateCartItemRequestModel model)
        // {

        //     var cartItem = new CartItem
        //     {
        //         Price = model.Price,
        //         ImageUrl = model.ImageUrl,
        //         ProductName = model.ProductName,
        //         Quantity = model.Quantity,
        //         IsCheckedOut = false,
        //     };

        //     var result = await _cartItemRepository.CreateAsync(cartItem);
        //     return new BaseResponse
        //     {
        //         Message = "Cart Item Created Successfully",
        //         Success = true,
        //     };

        // }

        public async Task<CartItemsResponseModel> GetCartItemsByCustomerIdAsync(int CustomerId)
        {
            var cartItem = await _cartItemRepository.GetCartItemsAsync(CustomerId);
            if (cartItem == null)
            {
                return new CartItemsResponseModel()
                {
                    Message = "Cart Item(s) not found",
                    Success = false,
                };
            }
            return new CartItemsResponseModel()
            {
                Message = "Cart Item(s) found",
                Success = true,
                Data = cartItem.Select(x => new CartItemDto()
                {
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    IsCheckedOut = x.IsCheckedOut,
                }).ToList(),

            };

        }

        public async Task<CartItemResponseModel> GetCartItemByCartItemIdAsync(int id)
    {
        var cartItem = await _cartItemRepository.GetCartItemAsync(id);
        return new CartItemResponseModel
        {
            Data = new CartItemDto
            {
                Id = cartItem.Id,
                Price = cartItem.Price,
                ImageUrl = cartItem.ImageUrl,
                ProductName = cartItem.ProductName,
                Quantity = cartItem.Quantity,
                IsCheckedOut = cartItem.IsCheckedOut,
            },
            Message = "Cart Item Retreived Successfully",
            Success = true
        };

    }

        public async Task<BaseResponse> ChangeCartItemQuantityAsync(UpdateCartItemRequestModel updatedCartItem, int id)
        {
            var cartItem = await _cartItemRepository.GetAsync(x => x.Id == id);
            if (cartItem == null)
            {
                return new BaseResponse()
                {
                    Message = "Cart item not found",
                    Success = false,
                };
            }
            cartItem.Quantity = updatedCartItem.Quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
            return new BaseResponse()
            {
                Message = "Quantity updated  successfully",
                Success = true,
            };

        }

        public async Task<BaseResponse> UpdateCartItemStatusAsync( int id)
        {
            var cartItem = await _cartItemRepository.GetAsync(x => x.Id == id);
            if (cartItem == null)
            {
                return new BaseResponse()
                {
                    Message = "Cart item not found",
                    Success = false,
                };
            }
            cartItem.IsCheckedOut = true;
            await _cartItemRepository.UpdateAsync(cartItem);
            return new BaseResponse()
            {
                Message = "Item status changed  successfully",
                Success = true,
            };

        }
        public async Task<BaseResponse> DeleteCartItemByIdAsync(int id)
        {
            var cartItem = await _cartItemRepository.GetAsync(x => x.Id == id);
            if (cartItem == null)
            {
                return new BaseResponse
                {
                    Message = "Cart item not found",
                    Success = false,
                };
            }
            await _cartItemRepository.DeleteAsync(cartItem);
            return new BaseResponse
            {
                Message = "Cart Item deleted",
                Success = true,
            };
        }

    }   
}