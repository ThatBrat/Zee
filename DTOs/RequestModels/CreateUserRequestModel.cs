namespace Zee.DTOs.RequestModels
{
    public class CreateUserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        

       

        


    }

    public class UpdateUserRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
       
       
    }

}