namespace ToyShopV2.Models
{
    public class ToyColor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Toy Toy { get; set; }    
    }
}
