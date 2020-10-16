using Common.Requests;
using Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Sales
{
    public interface ISalesRepository
    {
        BaseResponse<List<SalesResponse>> getSales();
        Task<bool> SaveSale(SalesRequest sale);
        Task<bool> DeleteSale(int idSale);
    }
}
