namespace Zee.DTOs.RequestModels
{
    public class CreateCustomerRequestModel : CreateUserRequestModel
    {
       public CartDto Cart {get; set;} 
    }

    public class UpdateCustomerRequestModel : UpdateUserRequestModel
    {
        
    }

}