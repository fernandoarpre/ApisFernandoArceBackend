using Common.Responses;
using Data.Repository.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Home
{
    public class HomeBusiness : IHomeBusiness
    {
        private readonly IHomeRepository _homeRespository;

        public HomeBusiness(IHomeRepository homeRepository)
        {
            _homeRespository = homeRepository;
        }
        public BaseResponse<DashboardResponse> GetDashboard()
        {
            BaseResponse<DashboardResponse> res = new BaseResponse<DashboardResponse>();
            res.response =  _homeRespository.GetDashboard();
            return res;
        }

        public BaseResponse<List<ChartResponse>> GetChart(int idCustomer)
        {
            BaseResponse<List<ChartResponse>> res = new BaseResponse<List<ChartResponse>>();
            res.response = _homeRespository.GetChart(idCustomer);
            return res;
        }
    }
}
