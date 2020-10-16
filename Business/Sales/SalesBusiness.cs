using Common.Requests;
using Common.Responses;
using Data.Repository.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Sales
{
    public class SalesBusiness : ISalesBusiness
    {
        private readonly ISalesRepository _salesRepository;
        public SalesBusiness(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public BaseResponse<List<SalesResponse>> GetSales()
        {
            return _salesRepository.getSales();
        }
        public async Task<BaseResponse<bool>> SaveSale(SalesRequest sale)
        {
            BaseResponse<bool> res = new BaseResponse<bool>();
            res.response = await _salesRepository.SaveSale(sale);
            res.msg = "Se guardó la venta con exito!";
            if (!res.response)
                res.msg = "Error al intentar guardar el cliente";

            return res;
        }

        public async Task<BaseResponse<bool>> DeleteSale(int idSale)
        {
            BaseResponse<bool> res = new BaseResponse<bool>();
            res.response = await _salesRepository.DeleteSale(idSale);
            res.msg = "Se eliminó la venta con exito!";
            return res;
        }
    }
}
