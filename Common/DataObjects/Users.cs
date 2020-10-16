using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.DataObjects
{
    public class Users
    {
        [Key]
        public int? idUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
