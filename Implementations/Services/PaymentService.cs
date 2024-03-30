
// using Zee.DTOs;
// using Zee.DTOs.RequestModels;
// using Zee.DTOs.ResponseModels;
// using Zee.Interface.Repositories;
// using Zee.Interface.Services;

// namespace Zee.Implementation.Service
// {
//     public class PaymentService : IPaymentService
//     {

//         private readonly IPaymentRepository _paymentRepository;
//         public PaymentService(IPaymentRepository paymentRepository)
//         {
//             _paymentRepository = paymentRepository;
//         }

//         public Task<PaymentResponseModel> MakePayment(PaymentDto model, int customerId)
//         {
//             var order = new Order
//             {
//                 Positions = model.OrderDto.Positions,
//                 Distance = model.OrderDto.Distance,
//                 RateValue = model.OrderDto.RateValue,
//             }
//             var payment = new Payment
//             {
//                 OrderId = model.OrderDto.Id,
//                 Amount = model.Amount,
//                 Status = PaymentStatus.Completed,
//                 SenderId = customerId,
//                 ReceiverId = model.SellerDto.Id ,
//                 AdminId = model.AdminDto.Id,

//             };

//             _paymentRepository.AddPayment(payment);
//             return payment;
//         }


//     }
// }