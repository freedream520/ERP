using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IOrderHeader
    {
        string GetMaxSlipNumber(string companyCode, string slipType);

        bool Exists(string slipNumber);

        DataSet GetDelivery(string customer_code);

        string Add(CZZD.ERP.Model.BllOrderHeaderTable model);

        int Update(CZZD.ERP.Model.BllOrderHeaderTable model);

        bool Delete(string slipNumber);

        CZZD.ERP.Model.BllOrderHeaderTable GetModel(string slipNumber);

        System.Data.DataSet GetList(string strWhere);

        DataSet GetPrintList(string strwhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        bool UpdateVerify(string slipNumber, int verifyFlag);

        CZZD.ERP.Model.BllHistoryOrderHeaderTable GetHistoryModel(string historySlipNumber);

        System.Data.DataSet GetHistoryOrderList(string orderSlipNumber);


        bool IsMechanicalBaseOrder(string slipNubmer);

        int AddOrderService(CZZD.ERP.Model.BllOrderServiceTable model);

        int UpdateOrderService(CZZD.ERP.Model.BllOrderServiceTable model);

        int DeleteOrderService(CZZD.ERP.Model.BllOrderServiceTable model);

        CZZD.ERP.Model.BllOrderServiceTable GetOrderServiceMode(string slipNumber);
    }
}
