using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AdminLoginDto
    {
        public int AdminId { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
