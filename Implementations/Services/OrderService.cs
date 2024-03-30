
// using Zee.DTOs.RequestModels;
// using Zee.DTOs.ResponseModels;
// using Zee.Interface.Repositories;
// using Zee.Interface.Services;

// namespace Zee.Implementation.Service
// {
//     public class OrderService : IOrderService
//     {
//         private readonly IUserRepository _userRepository;
//         private readonly IOrderRepository _orderRepository;
//         private readonly ICartRepository _cartRepository;
//         private readonly ICartItemRepository _cartItemRepository;
//         public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository)
//         {
//             _userRepository = userRepository;
//             _orderRepository = orderRepository;
//             _cartRepository = cartRepository;
//             _cartItemRepository = cartItemRepository;

//         }

//         public async Task<BaseResponse> CreateOrderAsync(CreateOrderRequestModel model, int cartId)
//         {
//             var cart = await _cartRepository.GetAsync(cartId);

//             var order = new Order
//             {
//                 DeliveryAddress = new Address
//                 {
//                     HouseNumber = model.Address.HouseNumber,
//                     StreetName = model.Address.StreetName,
//                     LGA = model.Address.LGA,
//                     Town = model.Address.Town,
//                     State = model.Address.State,
//                     Country = model.Address.Country,
//                 },
//                 DeliveryIsVerifiedByCustomer = false,
//                 DeliveryIsVerifiedBySeller = false,
//                 RefNo = $"ORD{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}",
//                 TotalPrice = model.TotalPrice,
//                 Positions = model.Positions,
//                 RateValue = model.RateValue,
//                 Distance = model.Distance,
//                 CustomerId = cart.CustomerId,
//                 SellerId = model.SellerId,
//             };

//             var result = await _orderRepository.CreateAsync(order);
//             return new BaseResponse
//             {
//                 Message = "order Created Successfully",
//                 Success = true,
//             };
//         }

//         public async Task<OrderResponseModel> GetByRefNo(string refNo)
//         {
//             var order = await _orderRepository.GetOrder(refNo);
//             if (order == null)
//             {
//                 return new OrderResponseModel
//                 {
//                     Message = "Order not found",
//                     Success = false,
//                 };
//             }

//             return new OrderResponseModel
//             {
//                 Message = "Order Retrived Successfully",
//                 Success = true,
//                 Data = new OrderDto
//                 {
//                     CustomerDto = new CustomerDto
//                     {
//                         Id = order.CustomerDto.Id,
//                         UserDto = new UserDto
//                         {
//                             Id = seller.User.Id,
//                             FirstName = seller.User.FirstName,
//                             LastName = seller.User.LastName,
//                             Email = seller.User.Email,
//                             PhoneNumber = seller.User.PhoneNumber,
//                             Role = seller.User.Role,
//                         },
                    

//                     },
//                     Logo = seller.Logo,
//                     StoreName = seller.StoreName,
//                     AccountNumber = seller.AccountNumber,
//                     Id = seller.Id,
//                     IsVerified = seller.IsVerified,
//                     Address = new AddressDto
//                     {
//                         HouseNumber = seller.Address.HouseNumber,
//                         StreetName = seller.Address.StreetName,
//                         LGA = seller.Address.LGA,
//                         Town = seller.Address.Town,
//                         State = seller.Address.State,
//                         Country = seller.Address.Country
//                     }

//                 }
//             };
//         }



//     }
// }