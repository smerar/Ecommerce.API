using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.DataModels.ViewModels.AdminViewModels

{
    public class CategoryModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage="Category name required ")]
        public string Name { get; set; }
    }
}
