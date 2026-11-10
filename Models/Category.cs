using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bai_3.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required")]
        [StringLength(100,MinimumLength=2,ErrorMessage ="name can not be loger than 100 Charaters")]
        public string Name { get; set; }
        public List <Pooduct> Pooducts { get; set; } = new List<Pooduct>();
    }
}
