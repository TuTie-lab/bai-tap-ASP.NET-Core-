namespace Bai_3.Models
{
    public class Pooduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = String.Empty;
        public int CategroryId { get; set; }
        public Category Category { get; set; } = null;
    }
}
