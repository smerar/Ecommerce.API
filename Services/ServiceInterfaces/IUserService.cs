using Ecommerce.API.DataModels.ResponseModels.AdminResponseModels;
using Ecommerce.API.DataModels.ResponseModels.UserResponseModel;
using Ecommerce.API.DataModels.ViewModels.AdminViewModels;
using Ecommerce.API.DataModels.ViewModels.UserViewModels;

namespace Ecommerce.API.Services.ServiceInterfaces
{
    public interface IUserService
    {
   
        public List<ProductModel> GetProductByCategoryId(int categoryId);
        public RegistrationResponseModel Register(RegistrationModel registrationModel);
       // public UpdatePasswordResponseModel UpdatePassword(UpdatePasswordModel updatePassword);

      //  public ShippingAddressResponseModel AddShippingAddress(ShippingAddressModel shippingAddress);

       // public ShippingAddressResponseModel UpdateShippingAddress(ShippingAddressModel shippingAddress);
     //  public ShippingAddressResponseModel DeleteShippingAddress(ShippingAddressModel shippingAddress);
      // public List<ShippingAddressModel> ListAddress(string username);

   

      // public LoginResponseModel UserLogin(LoginModel loginModel);




    }
}
