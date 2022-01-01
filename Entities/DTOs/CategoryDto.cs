using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
