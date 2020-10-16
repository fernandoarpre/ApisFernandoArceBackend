using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Home
{
    public interface IHomeRepository
    {
        DashboardResponse GetDashboard();
        List<ChartResponse> GetChart(int idCustomer);
    }
}
