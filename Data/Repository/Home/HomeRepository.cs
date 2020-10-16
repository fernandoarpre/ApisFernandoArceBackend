using Common.Responses;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApiVentasContext _context;

        public HomeRepository(ApiVentasContext context)
        {
            _context = context;
        }

        public List<ChartResponse> GetChart(int idCustomer)
        {
            List<ChartResponse> charts = new List<ChartResponse>();
            var datos = (from dto in _context.Sales
                         where dto.idCustomer == idCustomer
                         group dto by new { dto.Period } into g
                         select new ChartResponse { Period = g.Key.Period, Total = g.Sum(r => r.Value) }
                         ).ToList();
            charts.AddRange((List<ChartResponse>)datos);
            return charts;
        }

        public DashboardResponse GetDashboard()
        {
			DashboardResponse response = new DashboardResponse();
            response.TotalCustomers =   _context.Customers.Count();
            response.TotalUsers =  _context.Users.Count();
            response.TotalSales =  _context.Sales.Count();

            return response;
		}
    }
}
