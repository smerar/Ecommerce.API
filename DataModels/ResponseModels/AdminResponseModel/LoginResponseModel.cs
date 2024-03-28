using Ecommerce.DataModels.ResponseModels;

namespace Ecommerce.API.DataModels.ResponseModels.AdminResponseModels
{
    public class LoginResponseModel : ResponseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
