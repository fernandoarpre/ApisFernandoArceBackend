using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Responses
{
    public class SalesResponse : Sales
    {
        public CustomerResponse Customer { get; set; }
    }
}
