using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sales
{
    public interface ISalesBusiness
    {
        BaseResponse<List<SalesResponse>> GetSales();
        Task<BaseResponse<bool>> SaveSale(SalesRequest sale);
        Task<BaseResponse<bool>> DeleteSale(int idSale);
    }
}
