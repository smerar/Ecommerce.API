using Ecommerce.DataModels.ResponseModels;
using System.Drawing;

namespace Ecommerce.API.DataModels.ResponseModels.UserResponseModel
{
    public class RegistrationResponseModel : BaseResponseModel
    {

        public string Email { get; set; }
        public string Username { get; set; }

    }
}
