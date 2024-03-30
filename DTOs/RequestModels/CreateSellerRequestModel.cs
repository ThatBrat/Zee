namespace Zee.DTOs.RequestModels
{
    public class CreateSellerRequestModel : CreateUserRequestModel
    {
       
       public string AccountNumber {get; set;}
        public string Logo {get; set;}
        public string StoreName {get; set;} 
        public CreateAddressRequestModel Address {get; set;} 
    }


    public class UpdateSellerRequestModel : UpdateUserRequestModel
    {
        
       public string AccountNumber {get; set;}
        public string Logo {get; set;}
        public string StoreName {get; set;}
        public UpdateAddressRequestModel Address {get; set;} 
    }

    public class RegisterDispatchRequestModel
    {
       public string Email { get; set; }
       public string FirstName {get; set;}
       public string LastName {get; set;}
      
        
    }

   
}