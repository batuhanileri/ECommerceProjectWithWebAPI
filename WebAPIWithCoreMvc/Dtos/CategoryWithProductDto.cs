
using System.Collections.Generic;


namespace WebAPIWithCoreMvc.Dtos
{
    public class CategoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
