using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.Dtos
{
    public class CategoryDto
    {
       
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
       

    }
}
