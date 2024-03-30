

using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository, ICartRepository cartRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
        }

        public async Task<BaseResponse> Register(CreateCustomerRequestModel model)
        {
            var customer = await _customerRepository.GetAsync(customer => customer.User.Email == model.Email);
            if (customer != null)
            {
                return new BaseResponse()
                {
                    Message = "Email Already Exist",
                    Success = false,
                };
            }

            var user = new User
            {
                Email = model.Email,
                Password = model.Password,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = Role.Customer,
                PhoneNumber = model.PhoneNumber,

            };
            var adduser = await _userRepository.CreateAsync(user);
            var cart = new Cart
            {
               
            };
            var newCustomer = new Customer()
            {

                UserId = adduser.Id,
            };

            var addCustomer = await _customerRepository.CreateAsync(newCustomer);
            if (addCustomer == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register Customer",
                    Success = false,
                };
            }
            else
            {

                return new BaseResponse()
                {
                    Message = "Successfully Registered",
                    Success = true,
                };
            }
        }

        public async Task<CustomerResponseModel> GetById(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return new CustomerResponseModel
                {
                    Message = "Customer not found",
                    Success = false,
                };
            }

            return new CustomerResponseModel
            {
                Message = "Customer Retrived Successfully",
                Success = true,
                Data = new CustomerDto
                {
                    UserDto = new UserDto
                    {
                        FirstName = customer.User.FirstName,
                        LastName = customer.User.LastName,
                        Email = customer.User.Email,
                        PhoneNumber = customer.User.PhoneNumber,
                        Role = customer.User.Role,
                    },
                    Id = customer.Id


                }
            };
        }
        public async Task<BaseResponse> UpdateCustomer(UpdateCustomerRequestModel updatedCustomer, int id)
        {
            var customer = await _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Message = "Customer Not Found",
                    Success = false,
                };
            }
            customer.User.FirstName = updatedCustomer.FirstName ?? customer.User.FirstName;
            customer.User.LastName = updatedCustomer.LastName ?? customer.User.LastName;
            customer.User.PhoneNumber = updatedCustomer.PhoneNumber ?? customer.User.PhoneNumber;


            await _customerRepository.UpdateAsync(customer);
            return new BaseResponse
            {
                Message = "Customer updated successfully",
                Success = true,
            };
        }
    }
}