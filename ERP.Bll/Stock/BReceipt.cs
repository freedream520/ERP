using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BReceipt
    {
        IReceipt dal = DALFactory.DataAccess.CreateReceiptManage();

        public int UpdateReceiptPlan(int SLIP_NUMBER, string LAST_UPDATE_USER)
        {
            return dal.UpdateReceiptPlan(SLIP_NUMBER, LAST_UPDATE_USER);
        }

        public int AddReceiptPlan(BllReceiptPlanTable model)
        {
            return dal.AddReceiptPlan(model);
        }

        public int AddReceipt(BllReceiptTable model)
        {
            return dal.AddReceipt(model);
        }

        public int UpdataCancel(BllReceiptLineTable model)
        {
            return dal.UpdataCancel(model);
        }

        public BllReceiptTable GetReceiptModel(string SLIP_NUMBER)
        {
            return dal.GetReceiptModel(SLIP_NUMBER);
        }

        public BllReceiptTable GetRModel(string PO_SLIP_NUMBER)
        {
            return dal.GetRModel(PO_SLIP_NUMBER);
        }

        public BllReceiptLineTable GetLineModel(string SLIP_NUMBER, int LINE_NUMBER)
        {
            return dal.GetLineModel(SLIP_NUMBER, LINE_NUMBER);
        }

        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        public int GetMaxLineNumber()
        {
            return dal.GetMaxLineNumber();
        }

        public bool Exsitreceipt(string PO_SLIP_NUMBER)
        {
            return dal.Exsitreceipt(PO_SLIP_NUMBER);
        }

        public int Receipt(List<BllReceiptTable> receiptList, bool IsInstallments, DateTime planDate)
        {
            return dal.Receipt(receiptList, IsInstallments, planDate);
        }

        public BllReceiptPlanTable GetReceiptPlanModel(int slipNumber)
        {
            return dal.GetReceiptPlanModel(slipNumber);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }

        public int GetSearchRecordCount(string strWhere)
        {
            return dal.GetSearchRecordCount(strWhere);
        }

        public DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetSearchList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetPrintList(string strWhere)
        {
            return dal.GetPrintList(strWhere);
        }


        /// <summary>
        /// 入库取消
        /// </summary>
        public int UnReceipt(string slipNumber)
        {
            return dal.UnReceipt(slipNumber);
        }
    }//end class
}
