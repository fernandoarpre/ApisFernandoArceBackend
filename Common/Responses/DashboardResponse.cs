using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Responses
{
    public class DashboardResponse
    {
        public int TotalUsers {get; set;}
        public int TotalCustomers {get; set;}
        public int TotalSales { get; set; }
    }
}
