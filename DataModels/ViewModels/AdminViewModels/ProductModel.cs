using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.DataModels.ViewModels.AdminViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product name is required ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product price is required ")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Product stock is required ")]
        public int Stock { get; set; }
        [Required(ErrorMessage ="Product Category is required")]
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public string ImageUrl { get; set; }
        //public string fileName { get;set; }
       // public byte[] fileContent { get; set; }
        public bool CartFlag { get; set; }//Identify whether this particular product is added to a cart or not.Can be used in front end

    }
}
