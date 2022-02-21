using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}
