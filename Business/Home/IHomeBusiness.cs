using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Home
{
    public interface IHomeBusiness
    {
        BaseResponse<DashboardResponse> GetDashboard();
        BaseResponse<List<ChartResponse>> GetChart(int idCustomer);
    }
}
