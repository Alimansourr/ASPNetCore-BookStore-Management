using System.ComponentModel.DataAnnotations;

namespace Project_Advanced.Models
{
   public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pages must be greater than 0")]
        public int Pages { get; set; }

        [Required,
        DataType(DataType.Date)]
        public DateTime PublishYear { get; set; }

        [Required,
        DataType(DataType.Currency)]

        public int price { get; set; }

        [Display(Name = "Image URL")]
        public string ?ImageUrl { get; set; }


    }
}
