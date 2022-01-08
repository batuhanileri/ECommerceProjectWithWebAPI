using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        
        //public int? RoleId { get; set; }
        //public virtual RoleAdmin AdminRole { get; set; }

      
    }
}
