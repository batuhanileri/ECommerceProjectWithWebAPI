using Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
