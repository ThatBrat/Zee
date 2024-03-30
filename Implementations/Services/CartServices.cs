

using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class CartService : ICartService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public CartService(ICustomerRepository customerRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;

        }

        public async Task<BaseResponse> AddToCart(CreateCartItemRequestModel model, int customerId, int productId)
        {
            var cart = await _cartRepository.GetAsync(x => x.CustomerId == customerId);
            var product = await _productRepository.GetProductById(productId);

            if (cart != null)
            {
                
                var getCartItem = await _cartItemRepository.GetAsync(x => x.CartId == cart.Id && x.ProductName == model.ProductName);

                if (getCartItem != null)
                {
                    getCartItem.Quantity = model.Quantity;
                    var result = await _cartItemRepository.UpdateAsync(getCartItem);
                }
                else
                {
                    var addCartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductName = model.ProductName,
                        Price = model.Price,
                        ImageUrl = model.ImageUrl,
                        Quantity = model.Quantity,
                        IsCheckedOut = false,
                        SellerId = product.Seller.Id,

                    };
                    var result = await _cartItemRepository.CreateAsync(addCartItem);

                }
                return new BaseResponse
                {
                    Message = "Cart Item Added Successfully",
                    Success = true,
                };

            }
            else
            {
                var addCart = new Cart
                {
                    CustomerId = customerId,
                };
                var result = await _cartRepository.CreateAsync(addCart);
                var addCartItem = new CartItem
                {
                    CartId = result.Id,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    ImageUrl = model.ImageUrl,
                    Quantity = model.Quantity,
                    IsCheckedOut = false,
                    SellerId = product.Seller.Id,

                };
                await _cartItemRepository.CreateAsync(addCartItem);
                return new BaseResponse
                {
                    Message = "Cart item Created Successfully",
                    Success = true,
                };
            }
        }


        public async Task<CartResponseModel> GetAllItems(int customerId)
        {
            var cart = await _cartRepository.GetCart(customerId);
            if (cart == null)
            {
                return new CartResponseModel
                {

                    Message = "No cart yet",
                    Success = false,
                };
            }
            return new CartResponseModel
            {
                Message = "Cart found",
                Success = true,
                Data = new CartDto()
                {
                    Id = cart.Id,
                    Items = cart.Items.Select(x => new CartItemDto()
                    {
                        Id = x.Id,
                        Price = x.Price,
                        ProductName = x.ProductName,
                        Quantity = x.Quantity,
                        ImageUrl = x.ImageUrl,
                        CartId = x.CartId,
                        IsCheckedOut = x.IsCheckedOut,
                        SellerId = x.SellerId,

                    }).ToList(),
                }

            };

        }



    }
}