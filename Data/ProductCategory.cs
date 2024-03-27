namespace Ecommerce.API.Data
{
    public class ProductCategory
    {
        public int CatId { get; set; }
        public string CatName { get; set; }

        // Navigation property for products
        public ICollection<Products> Products { get; set; }
    }
}
