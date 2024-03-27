namespace Ecommerce.API.Data
{
    public class Products
    {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public decimal ShippingCost { get; set; }
    public int NoOfDaysTillDelivery { get; set; }
   
    //Foriegn key
     public int CategoryId { get; set; }

    // Navigation properties
    public ProductCategory Category { get; set; }
    
}
}
