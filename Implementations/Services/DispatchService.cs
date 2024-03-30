

using Zee.DTOs;
using Zee.DTOs.RequestModels;
using Zee.DTOs.ResponseModels;
using Zee.Interface.Repositories;
using Zee.Interface.Services;

namespace Zee.Implementation.Service
{
    public class DispatchService : IDispatchService
    {
        private readonly IDispatchRepository _dispatchRepository;
        private readonly IUserRepository _userRepository;
       
        public DispatchService(IDispatchRepository dispatchRepository, IUserRepository userRepository)
        {
            _dispatchRepository = dispatchRepository;
            _userRepository = userRepository;
            
        }

        
        public async Task<BaseResponse> CompleteRegisteration(CreateDispatchRequestModel model)
        {
            var dispatch = await _dispatchRepository.GetAsync(dispatch => dispatch.User.Email == model.Email);
            if (dispatch != null)
            {
                return new BaseResponse()
                {
                    Message = "Continue Registration",
                    Success = false,
                };
            }

            var user = new User
            {
               
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                
            };
            var adduser = await _userRepository.CreateAsync(user);
            var newDispatch = new Dispatch()
            {

                UserId = adduser.Id,
                 
            };

            var addDispatch = await _dispatchRepository.CreateAsync(newDispatch);
            if (addDispatch == null)
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


        public async Task<BaseResponse> RegisterDispatch(RegisterDispatchRequestModel model, int sellerId)
        {
            var dispatch = await _dispatchRepository.GetAsync(dispatch => dispatch.User.Email == model.Email);
            if (dispatch != null)
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
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = Role.Dispatch,
            };
            var adduser = await _userRepository.CreateAsync(user);
             var newDispatch= new Dispatch()
            {

                UserId = adduser.Id,
                
            };
            var addDispatch = await _dispatchRepository.CreateAsync(newDispatch);
            if (addDispatch == null)
            {
                return new BaseResponse()
                {
                    Message = "Unable To Register Seller",
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
    
        public async Task<DispatchesResponseModel> GetDispatchesBySellerId(int id)
        {
            var dispatches = await _dispatchRepository.GetDispatches(id);
            if (dispatches == null)
            {
                return new DispatchesResponseModel()
                {
                    Message = "No dispatch yet",
                    Success = false,
                };
            }
            return new DispatchesResponseModel()
            {
                Message = "Dispatch(es) found",
                Success = true,
                Data = dispatches.Select(x => new DispatchDto()
                {
                    Id = x.Id,
                    UserDto = new UserDto
                    {
                        Id = x.User.Id,
                        Email = x.User.Email,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        PhoneNumber = x.User.PhoneNumber,
                        Role = x.User.Role,
                    },

                }).ToList(),

            };

        }
    
         public async Task<BaseResponse> DeleteDispatchAsync(string email)
        {
            var dispatch = await _dispatchRepository.GetDispatch(email);
            if (dispatch == null)
            {
                return new BaseResponse
                {
                    Message = "Dispatch not found",
                    Success = false,
                };
            }
            await _dispatchRepository.DeleteAsync(dispatch);
            return new BaseResponse
            {
                Message = "Dispatch deleted",
                Success = true,
            };
        }
        public async Task<DispatchResponseModel> GetById(int id)
        {
            var dispatch = await _dispatchRepository.GetDispatch(id);
            if (dispatch == null)
            {
                return new DispatchResponseModel
                {
                    Message = "Dispatch not found",
                    Success = false,
                };
            }

            return new DispatchResponseModel
            {
                Message = "Dispatch Retrived Successfully",
                Success = true,
                Data = new DispatchDto
                {
                    UserDto = new UserDto
                    {
                        Id = dispatch.User.Id,
                        FirstName = dispatch.User.FirstName,
                        LastName = dispatch.User.LastName,
                        Email = dispatch.User.Email,  
                        PhoneNumber = dispatch.User.PhoneNumber,
                        Role = dispatch.User.Role,
                    },
                    Id = dispatch.Id

                }
            };
        }

        public async Task<DispatchResponseModel> GetByEmail(string email)
        {
            var dispatch = await _dispatchRepository.GetDispatch(email);
            if (dispatch == null)
            {
                return new DispatchResponseModel
                {
                    Message = "Dispatch not found",
                    Success = false,
                };
            }

            return new DispatchResponseModel
            {
                Message = "Dispatch Retrived Successfully",
                Success = true,
                Data = new DispatchDto
                {
                    UserDto = new UserDto
                    {
                        Id = dispatch.User.Id,
                        FirstName = dispatch.User.FirstName,
                        LastName = dispatch.User.LastName,
                        Email = dispatch.User.Email,  
                        PhoneNumber = dispatch.User.PhoneNumber,
                        Role = dispatch.User.Role,
                    },
                    Id = dispatch.Id

                }
            };
        }
        public async Task<BaseResponse> UpdateDispatch(UpdateDispatchRequestModel updatedDispatch, int id)
        {
            var dispatch = await _dispatchRepository.GetDispatch(id);
            if (dispatch == null)
            {
                return new BaseResponse
                {
                    Message = "Dispatch Not Found",
                    Success = false,
                };
            }
            dispatch.User.FirstName = updatedDispatch.FirstName ?? dispatch.User.FirstName;
            dispatch.User.LastName = updatedDispatch.LastName ?? dispatch.User.LastName;
            dispatch.User.PhoneNumber = updatedDispatch.PhoneNumber ?? dispatch.User.PhoneNumber;
           
            await _dispatchRepository.UpdateAsync(dispatch);
            return new BaseResponse
            {
                Message = "Dispatch updated successfully",
                Success = true,
            };
        }
    }
}