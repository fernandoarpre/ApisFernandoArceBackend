using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace Common.DataObjects
{
    public class Sales
    {
        [Key]
        public int? idSale { get; set; }
        public string Period { get; set; }
        public Double Quantity { get; set; }
        public decimal Value { get; set; }
        public int idCustomer { get; set; }
    }
}
