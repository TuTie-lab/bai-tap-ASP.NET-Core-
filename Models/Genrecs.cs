using System.ComponentModel.DataAnnotations;

namespace Tu_day6_2.Models
{
    public class Genrecs
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200,MinimumLength =3)]
        public string Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
