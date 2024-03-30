namespace Ecommerce.API.DataModels.ViewModels.CartViewModels
{
    public class CartProductsModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImage { get;set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
