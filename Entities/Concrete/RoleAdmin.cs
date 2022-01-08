using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class RoleAdmin
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
