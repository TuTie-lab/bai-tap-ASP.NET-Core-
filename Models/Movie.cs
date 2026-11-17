using System.ComponentModel.DataAnnotations;

namespace Tu_day6_2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "title musst ")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime RealeaseDate { get; set; }

        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public Genrecs? Genre {get;set;}
    }
}
