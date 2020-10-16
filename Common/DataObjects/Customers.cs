using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.DataObjects
{
    public class Customers
    {
        [Key]
        public int? idCustomer {get; set;}
        public string DocumentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Cellphone { get; set; }
        public int? idUserNew { get; set; }
        public int? idUserUpdate { get; set; }
        public DateTime? DateTimeNew { get; set; }
        public DateTime? DateTimeUpdate { get; set; }
    }
}
