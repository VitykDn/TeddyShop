namespace ToyShopV2.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}

