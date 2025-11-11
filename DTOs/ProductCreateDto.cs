using System.ComponentModel.DataAnnotations;

namespace EfCorePracticeApiNet10.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 999999)]
        public decimal Price { get; set; }

        [Range(0, 9999)]
        public int Stock { get; set; }
    }
}
