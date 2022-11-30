namespace ToyShopV2.Models
{
    public class OrderDetail
    {
        
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ToyId { get; set; }
        public string ToyName { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        

        public Order Order { get; set; } 
        

    }
}
