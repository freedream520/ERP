using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class PurchaseOrderManage : IPurchaseOrder
    {
        public PurchaseOrderManage()
        { }

        #region 取得当前最大采购订单流水号
        /// <summary>
        /// 取得当前最大采购订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber(string companyCode, string slipType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from get_purchase_order_max_slip_number");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE and SLIP_TYPE=@SLIP_TYPE ");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,50),
                    new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20)};
            parameters[0].Value = companyCode;
            parameters[1].Value = slipType;
            return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CZZD.ERP.Model.BllPurchaseOrderTable model)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    #region 主表
                    strSql.Append("insert into BLL_PURCHASE_ORDER(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE,PURCHASE_QUOTATION_NUMBER )");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE,@PURCHASE_QUOTATION_NUMBER )");
                    SqlParameter[] parameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@TOTAL_AMOUNT",SqlDbType.Decimal,15),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PURCHASE_QUOTATION_NUMBER", SqlDbType.VarChar,20)};
                    parameters[0].Value = model.SLIP_NUMBER;
                    parameters[1].Value = model.SLIP_DATE;
                    parameters[2].Value = model.SLIP_TYPE;
                    parameters[3].Value = model.ORDER_SLIP_NUMBER;
                    parameters[4].Value = model.SUPPLIER_ORDER_NUMBER;
                    parameters[5].Value = model.SUPPLIER_CODE;
                    parameters[6].Value = model.RECEIPT_WAREHOUSE_CODE;
                    parameters[7].Value = model.DUE_DATE;
                    parameters[8].Value = model.TOTAL_AMOUNT;
                    parameters[9].Value = model.TAX_RATE;
                    parameters[10].Value = model.CURRENCY_CODE;
                    parameters[11].Value = model.PACKING_METHOD;
                    parameters[12].Value = model.PAYMENT_CONDITION;
                    parameters[13].Value = model.MEMO;
                    parameters[14].Value = model.STATUS_FLAG;
                    parameters[15].Value = model.CREATE_USER;
                    parameters[16].Value = model.LAST_UPDATE_USER;
                    parameters[17].Value = model.COMPANY_CODE;
                    parameters[18].Value = model.PURCHASE_QUOTATION_NUMBER;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));
                    #endregion

                    //明细插入
                    foreach (BllPurchaseOrderLineTable lineModel in model.Items)
                    {
                        strSql = new StringBuilder();
                        #region　明细
                        strSql.Append("insert into BLL_PURCHASE_ORDER_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,INCLUDED_TAX_STATUS,PRODUCT_NAME,SPEC,MEMO)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@INCLUDED_TAX_STATUS,@PRODUCT_NAME,@SPEC,@MEMO)");
                        SqlParameter[] lineParameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                                new SqlParameter("@INCLUDED_TAX_STATUS", SqlDbType.Int,4),
                                new SqlParameter("@PRODUCT_NAME", SqlDbType.NVarChar,100),
					            new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
                                new SqlParameter("@MEMO", SqlDbType.NVarChar,255)};
                        lineParameters[0].Value = model.SLIP_NUMBER;
                        lineParameters[1].Value = lineModel.LINE_NUMBER;
                        lineParameters[2].Value = lineModel.PRODUCT_CODE;
                        lineParameters[3].Value = lineModel.QUANTITY;
                        lineParameters[4].Value = lineModel.UNIT_CODE;
                        lineParameters[5].Value = lineModel.PRICE;
                        lineParameters[6].Value = lineModel.AMOUNT_WITHOUT_TAX;
                        lineParameters[7].Value = lineModel.TAX_AMOUNT;
                        lineParameters[8].Value = lineModel.AMOUNT_INCLUDED_TAX;
                        lineParameters[9].Value = lineModel.STATUS_FLAG;
                        lineParameters[10].Value = lineModel.INCLUDED_TAX_STATUS;
                        lineParameters[11].Value = lineModel.PRODUCT_NAME;
                        lineParameters[12].Value = lineModel.PRODUCT_SPEC;
                        lineParameters[13].Value = lineModel.MEMO;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                        #endregion

                        #region 入库预定
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_RECEIPT_PLAN(");
                        strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,INCLUDED_TAX_STATUS,PRODUCT_NAME,SPEC,LINE_MEMO,PURCHASE_QUOTATION_NUMBER)");
                        strSql.Append(" values (");
                        strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@INCLUDED_TAX_STATUS,@PRODUCT_NAME,@SPEC,@LINE_MEMO,@PURCHASE_QUOTATION_NUMBER)");

                        SqlParameter[] rpParameters = {
					            new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@PURCHASE_ORDER_LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,40),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@RECEIPT_PLAN_QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                                new SqlParameter("@INCLUDED_TAX_STATUS", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_NAME", SqlDbType.NVarChar,100),
					            new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
                                new SqlParameter("@LINE_MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PURCHASE_QUOTATION_NUMBER", SqlDbType.VarChar,20)};
                        rpParameters[0].Value = model.SLIP_NUMBER;
                        rpParameters[1].Value = lineModel.LINE_NUMBER;
                        rpParameters[2].Value = model.SLIP_DATE;
                        rpParameters[3].Value = model.SLIP_TYPE;
                        rpParameters[4].Value = model.ORDER_SLIP_NUMBER;
                        rpParameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
                        rpParameters[6].Value = model.SUPPLIER_CODE;
                        rpParameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
                        rpParameters[8].Value = model.DUE_DATE;
                        rpParameters[9].Value = model.COMPANY_CODE;
                        rpParameters[10].Value = model.TOTAL_AMOUNT;
                        rpParameters[11].Value = model.TAX_RATE;
                        rpParameters[12].Value = model.CURRENCY_CODE;
                        rpParameters[13].Value = model.PACKING_METHOD;
                        rpParameters[14].Value = model.PAYMENT_CONDITION;
                        rpParameters[15].Value = model.MEMO;
                        rpParameters[16].Value = lineModel.PRODUCT_CODE;
                        rpParameters[17].Value = lineModel.QUANTITY;
                        rpParameters[18].Value = lineModel.QUANTITY;
                        rpParameters[19].Value = lineModel.UNIT_CODE;
                        rpParameters[20].Value = lineModel.PRICE;
                        rpParameters[21].Value = lineModel.AMOUNT_WITHOUT_TAX;
                        rpParameters[22].Value = lineModel.TAX_AMOUNT;
                        rpParameters[23].Value = lineModel.AMOUNT_INCLUDED_TAX;
                        rpParameters[24].Value = CConstant.INIT_STATUS;
                        rpParameters[25].Value = model.CREATE_USER;
                        rpParameters[26].Value = model.LAST_UPDATE_USER;
                        rpParameters[27].Value = lineModel.INCLUDED_TAX_STATUS;
                        rpParameters[28].Value = lineModel.PRODUCT_NAME;
                        rpParameters[29].Value = lineModel.PRODUCT_SPEC;
                        rpParameters[30].Value = lineModel.MEMO;
                        rpParameters[31].Value = model.PURCHASE_QUOTATION_NUMBER;
                        listSql.Add(new CommandInfo(strSql.ToString(), rpParameters));
                        #endregion
                    }

                    result = DbHelperSQL.ExecuteSqlTran(listSql);

                }
                catch (SqlException ex)
                {
                    int maxLlipNumber = CConvert.ToInt32(GetMaxSlipNumber(model.COMPANY_CODE, model.SLIP_TYPE)) + 1;
                    model.SLIP_NUMBER = model.COMPANY_CODE + "-" + model.SLIP_TYPE + "-" + maxLlipNumber.ToString().PadLeft(4, '0');
                    i++;
                    if (i == 10)
                    {
                        throw ex;
                    }
                    continue;
                }
                break;
            }
            return result;
        }
        #endregion

        #region  更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllPurchaseOrderTable model)
        {

            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            #region 主表
            strSql.Append("update BLL_PURCHASE_ORDER set ");
            strSql.Append("SLIP_DATE=@SLIP_DATE,");
            strSql.Append("SLIP_TYPE=@SLIP_TYPE,");
            strSql.Append("ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER,");
            strSql.Append("SUPPLIER_ORDER_NUMBER=@SUPPLIER_ORDER_NUMBER,");
            strSql.Append("SUPPLIER_CODE=@SUPPLIER_CODE,");
            strSql.Append("RECEIPT_WAREHOUSE_CODE=@RECEIPT_WAREHOUSE_CODE,");
            strSql.Append("DUE_DATE=@DUE_DATE,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("TOTAL_AMOUNT=@TOTAL_AMOUNT,");
            strSql.Append("TAX_RATE=@TAX_RATE,");
            strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
            strSql.Append("PACKING_METHOD=@PACKING_METHOD,");
            strSql.Append("PAYMENT_CONDITION=@PAYMENT_CONDITION,");
            strSql.Append("MEMO=@MEMO,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("CREATE_USER=@CREATE_USER,");
            strSql.Append("CREATE_DATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("PURCHASE_QUOTATION_NUMBER=@PURCHASE_QUOTATION_NUMBER");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@TOTAL_AMOUNT",SqlDbType.Decimal,15),
					    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					    new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@PURCHASE_QUOTATION_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.SLIP_DATE;
            parameters[2].Value = model.SLIP_TYPE;
            parameters[3].Value = model.ORDER_SLIP_NUMBER;
            parameters[4].Value = model.SUPPLIER_ORDER_NUMBER;
            parameters[5].Value = model.SUPPLIER_CODE;
            parameters[6].Value = model.RECEIPT_WAREHOUSE_CODE;
            parameters[7].Value = model.DUE_DATE;
            parameters[8].Value = model.COMPANY_CODE;
            parameters[9].Value = model.TOTAL_AMOUNT;
            parameters[10].Value = model.TAX_RATE;
            parameters[11].Value = model.CURRENCY_CODE;
            parameters[12].Value = model.PACKING_METHOD;
            parameters[13].Value = model.PAYMENT_CONDITION;
            parameters[14].Value = model.MEMO;
            parameters[15].Value = model.STATUS_FLAG;
            parameters[16].Value = model.CREATE_USER;
            parameters[17].Value = model.LAST_UPDATE_USER;
            parameters[18].Value = model.PURCHASE_QUOTATION_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            #endregion

            #region 原有入库预定的删除
            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0} ", CConstant.DELETE_STATUS);
            strSql.Append(" where PURCHASE_ORDER_SLIP_NUMBER=@PURCHASE_ORDER_SLIP_NUMBER ");
            SqlParameter[] delRPParameters = {
					                new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)};
            delRPParameters[0].Value = model.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), delRPParameters));
            #endregion

            #region 原有采购明细的删除
            strSql = new StringBuilder();
            strSql.Append("delete from BLL_PURCHASE_ORDER_LINE ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] delLineParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            delLineParameters[0].Value = model.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), delLineParameters));
            #endregion 


            foreach (BllPurchaseOrderLineTable lineModel in model.Items)
            {
                strSql = new StringBuilder();
                #region　明细
                strSql.Append("insert into BLL_PURCHASE_ORDER_LINE(");
                strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,INCLUDED_TAX_STATUS,PRODUCT_NAME,SPEC,MEMO)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@INCLUDED_TAX_STATUS,@PRODUCT_NAME,@SPEC,@MEMO)");
                SqlParameter[] lineParameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                                new SqlParameter("@INCLUDED_TAX_STATUS", SqlDbType.Int,4),
                                new SqlParameter("@PRODUCT_NAME", SqlDbType.NVarChar,100),
					            new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
                                new SqlParameter("@MEMO", SqlDbType.NVarChar,255)};
                lineParameters[0].Value = model.SLIP_NUMBER;
                lineParameters[1].Value = lineModel.LINE_NUMBER;
                lineParameters[2].Value = lineModel.PRODUCT_CODE;
                lineParameters[3].Value = lineModel.QUANTITY;
                lineParameters[4].Value = lineModel.UNIT_CODE;
                lineParameters[5].Value = lineModel.PRICE;
                lineParameters[6].Value = lineModel.AMOUNT_WITHOUT_TAX;
                lineParameters[7].Value = lineModel.TAX_AMOUNT;
                lineParameters[8].Value = lineModel.AMOUNT_INCLUDED_TAX;
                lineParameters[9].Value = lineModel.STATUS_FLAG;
                lineParameters[10].Value = lineModel.INCLUDED_TAX_STATUS;
                lineParameters[11].Value = lineModel.PRODUCT_NAME;
                lineParameters[12].Value = lineModel.PRODUCT_SPEC;
                lineParameters[13].Value = lineModel.MEMO;
                listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                #endregion

                #region 入库预定
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_RECEIPT_PLAN(");
                strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,INCLUDED_TAX_STATUS,PRODUCT_NAME,SPEC,LINE_MEMO,PURCHASE_QUOTATION_NUMBER)");
                strSql.Append(" values (");
                strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@INCLUDED_TAX_STATUS,@PRODUCT_NAME,@SPEC,@LINE_MEMO,@PURCHASE_QUOTATION_NUMBER)");

                SqlParameter[] rpParameters = {
					            new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@PURCHASE_ORDER_LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,40),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@RECEIPT_PLAN_QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                                new SqlParameter("@INCLUDED_TAX_STATUS", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_NAME", SqlDbType.NVarChar,100),
					            new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
                                new SqlParameter("@LINE_MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PURCHASE_QUOTATION_NUMBER", SqlDbType.VarChar,20)};
                rpParameters[0].Value = model.SLIP_NUMBER;
                rpParameters[1].Value = lineModel.LINE_NUMBER;
                rpParameters[2].Value = model.SLIP_DATE;
                rpParameters[3].Value = model.SLIP_TYPE;
                rpParameters[4].Value = model.ORDER_SLIP_NUMBER;
                rpParameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
                rpParameters[6].Value = model.SUPPLIER_CODE;
                rpParameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
                rpParameters[8].Value = model.DUE_DATE;
                rpParameters[9].Value = model.COMPANY_CODE;
                rpParameters[10].Value = model.TOTAL_AMOUNT;
                rpParameters[11].Value = model.TAX_RATE;
                rpParameters[12].Value = model.CURRENCY_CODE;
                rpParameters[13].Value = model.PACKING_METHOD;
                rpParameters[14].Value = model.PAYMENT_CONDITION;
                rpParameters[15].Value = model.MEMO;
                rpParameters[16].Value = lineModel.PRODUCT_CODE;
                rpParameters[17].Value = lineModel.QUANTITY;
                rpParameters[18].Value = lineModel.QUANTITY;
                rpParameters[19].Value = lineModel.UNIT_CODE;
                rpParameters[20].Value = lineModel.PRICE;
                rpParameters[21].Value = lineModel.AMOUNT_WITHOUT_TAX;
                rpParameters[22].Value = lineModel.TAX_AMOUNT;
                rpParameters[23].Value = lineModel.AMOUNT_INCLUDED_TAX;
                rpParameters[24].Value = CConstant.INIT_STATUS;
                rpParameters[25].Value = model.CREATE_USER;
                rpParameters[26].Value = model.LAST_UPDATE_USER;
                rpParameters[27].Value = lineModel.INCLUDED_TAX_STATUS;
                rpParameters[28].Value = lineModel.PRODUCT_NAME;
                rpParameters[29].Value = lineModel.PRODUCT_SPEC;
                rpParameters[30].Value = lineModel.MEMO;
                rpParameters[31].Value = model.PURCHASE_QUOTATION_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), rpParameters));
                #endregion
            }
            return  DbHelperSQL.ExecuteSqlTran(listSql);
        }

        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SLIP_NUMBER)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_PURCHASE_ORDER set STATUS_FLAG={0} ", CConstant.DELETE_STATUS);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0} ", CConstant.DELETE_STATUS);
            strSql.Append(" where PURCHASE_ORDER_SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] receiptParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            receiptParam[0].Value = SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));


            int rows = DbHelperSQL.ExecuteSqlTran(listSql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion               

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BllPurchaseOrderTable GetModel(string SLIP_NUMBER)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from BLL_PURCHASE_ORDER ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            BllPurchaseOrderTable POModel = new BllPurchaseOrderTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                POModel.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    POModel.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                POModel.SLIP_TYPE = ds.Tables[0].Rows[0]["SLIP_TYPE"].ToString();
                POModel.ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["ORDER_SLIP_NUMBER"].ToString();
                POModel.SUPPLIER_ORDER_NUMBER = ds.Tables[0].Rows[0]["SUPPLIER_ORDER_NUMBER"].ToString();
                POModel.PURCHASE_QUOTATION_NUMBER = ds.Tables[0].Rows[0]["PURCHASE_QUOTATION_NUMBER"].ToString();
                POModel.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                POModel.RECEIPT_WAREHOUSE_CODE = ds.Tables[0].Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["DUE_DATE"].ToString() != "")
                {
                    POModel.DUE_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["DUE_DATE"].ToString());
                }
                POModel.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString() != "")
                {
                    POModel.TOTAL_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_RATE"].ToString() != "")
                {
                    POModel.TAX_RATE = decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
                }
                POModel.CURRENCY_CODE = ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
                POModel.PACKING_METHOD = ds.Tables[0].Rows[0]["PACKING_METHOD"].ToString();
                POModel.PAYMENT_CONDITION = ds.Tables[0].Rows[0]["PAYMENT_CONDITION"].ToString();
                POModel.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    POModel.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                POModel.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    POModel.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    POModel.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                POModel.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();

                strSql = new StringBuilder();
                strSql.Append("SELECT * FROM BLL_PURCHASE_ORDER_LINE");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = SLIP_NUMBER;
                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllPurchaseOrderLineTable POLModel = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    POLModel = new BllPurchaseOrderLineTable();
                    POLModel.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    POLModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    POLModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    POLModel.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
                    POLModel.UNIT_CODE = CConvert.ToString(row["UNIT_CODE"]);
                    POLModel.PRICE = CConvert.ToDecimal(row["PRICE"]);
                    POLModel.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(row["AMOUNT_WITHOUT_TAX"]);
                    POLModel.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(row["AMOUNT_INCLUDED_TAX"]);
                    POLModel.TAX_AMOUNT = CConvert.ToDecimal(row["TAX_AMOUNT"]);
                    POLModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);
                    POLModel.INCLUDED_TAX_STATUS = CConvert.ToInt32(row["INCLUDED_TAX_STATUS"]);
                    POLModel.PRODUCT_NAME = CConvert.ToString(row["PRODUCT_NAME"]);
                    POLModel.PRODUCT_SPEC = CConvert.ToString(row["SPEC"]);
                    POLModel.MEMO = CConvert.ToString(row["MEMO"]);
                    if (POLModel.SLIP_NUMBER != null)
                    {
                        POModel.AddItem(POLModel);
                    }
                }
                return POModel;
            }
            else
            {
                return null;
            }
        }
        #endregion

        public DataSet GetPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SLIP_NUMBER,CONVERT(varchar(12) ,SLIP_DATE ,111) as SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,SUPPLIER_NAME,RECEIPT_WAREHOUSE_CODE,WAREHOUSE_NAME,");
            strSql.Append(" CONVERT(varchar(12) ,DUE_DATE ,111) AS DUE_DATE,COMPANY_NAME,TOTAL_AMOUNT,TAX_RATE,CURRENCY_NAME,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG1,");
            strSql.Append(" CREATE_USER,CONVERT(varchar(12) ,CREATE_DATE_TIME ,111) AS CREATE_DATE_TIME,CONVERT(varchar(12) ,LAST_UPDATE_TIME ,111) AS LAST_UPDATE_TIME,LAST_UPDATE_USER, ");
            strSql.Append(" LINE_NUMBER,PRODUCT_NAME,QUANTITY,UNIT_NAME,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX, LINE_MEMO,PURCHASE_QUOTATION_NUMBER ");
            strSql.Append(" from bll_purchase_order_print_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得订单内容
        /// </summary>
        public DataSet GetPurchaseOrderList(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_purchase_order_entry_view ");

            strSql.Append("where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #region 采购分页查询
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_purchase_order_search_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SLIP_NUMBER asc");
            }
            strSql.Append(")AS Row, T.* from bll_purchase_order_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  根据采购单编号获得所有己入库与未入库的预定数据
        /// <summary>
        /// 根据采购单编号获得所有己入库与未入库的预定数据
        /// </summary>
        public DataSet GetReceivingPlanByPurchaseOrderSlipNumber(string purchaseOrderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BLL_RECEIPT_PLAN ");

            strSql.Append("where PURCHASE_ORDER_SLIP_NUMBER=@SLIP_NUMBER ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} ", CConstant.DELETE_STATUS);

            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = purchaseOrderSlipNumber;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion     

        #region 补充查询
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetPurchaseSupplementRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_purchase_supplement_search_view  ");
            strSql.Append("where QUANTITY < SAFETY_STOCK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public DataSet GetPurchaseSupplementList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,MODEL_NUMBER,UNIT_NAME,SAFETY_STOCK,QUANTITY,MAX_QUANTITY,MIN_PURCHASE_QUANTITY,STATUS_FLAG,CREATE_NAME,CONVERT(varchar(12) ,CREATE_DATE_TIME ,111) AS CREATE_DATE_TIME,LAST_UPDATE_NAME,CONVERT(varchar(12) ,LAST_UPDATE_TIME ,111) AS LAST_UPDATE_TIME ");
            strSql.Append(" FROM bll_purchase_supplement_search_view ");
            strSql.Append(" where QUANTITY < SAFETY_STOCK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPurchaseSupplementList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.WAREHOUSE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_purchase_supplement_search_view T");
            strSql.Append(" WHERE T.QUANTITY < T.SAFETY_STOCK ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal GetPurchaseQuantity(string warehouseCode, string productCode)
        {
            decimal purchaseQuantity = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(RECEIPT_PLAN_QUANTITY),0) FROM BLL_RECEIPT_PLAN ");
            strSql.Append(" where RECEIPT_WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG = {0} ", CConstant.INIT_STATUS);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)
                    };
            parameters[0].Value = warehouseCode;
            parameters[1].Value = productCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                purchaseQuantity = CConvert.ToDecimal(obj);
            }
            return purchaseQuantity;
        }

        #endregion

        #region 主成品采购查询
        public DataSet GetPartsList(string PRODUCT_CODE, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PRODUCT_CODE asc");
            }
            strSql.Append(")AS Row, T.* from BASE_PRODUCT_PARTS T");
            strSql.AppendFormat(" where PRODUCT_CODE =@PRODUCT_CODE and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = PRODUCT_CODE;

            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetPartsRecordCount(string PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCT_PARTS");
            strSql.AppendFormat(" where PRODUCT_CODE =@PRODUCT_CODE and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);

            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = PRODUCT_CODE;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseStockTable GetStockModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BASE_STOCK ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            BaseStockTable model = new BaseStockTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    model.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

    } //end class
}
