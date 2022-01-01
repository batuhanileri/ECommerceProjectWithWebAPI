using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{

    public class ProductDto
    {
        public int ProductId { get; set; }

       // [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string ProductName { get; set; }

  //      [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public int UnitsInStock { get; set; }

    //    [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
