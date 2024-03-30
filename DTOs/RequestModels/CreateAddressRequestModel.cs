namespace Zee.DTOs.RequestModels
{
    public class CreateAddressRequestModel 
    {
        public string HouseNumber {get; set;}
        public string StreetName {get; set;}
        public string LGA {get; set;}
        public string Town {get; set;}
        public string State {get; set;}
        public string Country {get; set;}  
    }

     public class UpdateAddressRequestModel 
    {
        public string HouseNumber {get; set;}
        public string StreetName {get; set;}
        public string LGA {get; set;}
        public string Town {get; set;}
        public string State {get; set;}
        public string Country {get; set;}  
    }
}