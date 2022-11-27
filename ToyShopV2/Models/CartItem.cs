using MessagePack;

namespace ToyShopV2.Models
{
    public class CartItem
    {
        
        public int ToyId { get; set; }
        public string ToyName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
        public string Image { get; set; }
        public CartItem()
        {
                
        }
        public CartItem(Toy toy)
        {
            ToyId = toy.Id;
            ToyName = toy.Name;
            Price = toy.Price;
            Quantity = 1;
            Image = toy.Image;
        }
    }
}
