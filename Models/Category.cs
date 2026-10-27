using Microsoft.EntityFrameworkCore;

namespace Bai_3.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbSet<Pooduct> Pooducts { get; set; } = null;
    }
}
