using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Common;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using System.Data;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.SQLServerDAL
{
    public class SlipTypeManage:ISlipType
    {
        public SlipTypeManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TYPE_CODE, string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_SLIP_TYPE");
            strSql.Append(" where TYPE_CODE=@TYPE_CODE and CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = TYPE_CODE;
            parameters[1].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CZZD.ERP.Model.BaseSlipTypeTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.TYPE_CODE, model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_SLIP_TYPE set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("INDICATES_ORDER=@INDICATES_ORDER");
                strSql.Append(" where TYPE_CODE=@TYPE_CODE and CODE=@CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8)};
                parameters[0].Value = model.TYPE_CODE;
                parameters[1].Value = model.CODE;
                parameters[2].Value = model.NAME;
                parameters[3].Value = model.COMPANY_CODE;
                parameters[4].Value = CConstant.INIT_STATUS;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                parameters[7].Value = model.INDICATES_ORDER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_SLIP_TYPE(");
                strSql.Append("TYPE_CODE,CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME, INDICATES_ORDER)");
                strSql.Append(" values (");
                strSql.Append("@TYPE_CODE,@CODE,@NAME,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(), @INDICATES_ORDER)");
                SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8)};
                parameters[0].Value = model.TYPE_CODE;
                parameters[1].Value = model.CODE;
                parameters[2].Value = model.NAME;
                parameters[3].Value = model.COMPANY_CODE;
                parameters[4].Value = CConstant.INIT_STATUS;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                parameters[7].Value = model.INDICATES_ORDER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            if (rows > 0)
            {
                return true;
                CCacheData.SlipType = null;
                CCacheData.OrderSlipType = null;
                CCacheData.PurchaseSlipType = null;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CZZD.ERP.Model.BaseSlipTypeTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_SLIP_TYPE set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("INDICATES_ORDER=@INDICATES_ORDER");
            strSql.Append(" where TYPE_CODE=@TYPE_CODE and CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8)};
            parameters[0].Value = model.TYPE_CODE;
            parameters[1].Value = model.CODE;
            parameters[2].Value = model.NAME;
            parameters[3].Value = model.COMPANY_CODE;
            parameters[4].Value = CConstant.INIT_STATUS;
            parameters[5].Value = model.LAST_UPDATE_USER;
            parameters[6].Value = model.INDICATES_ORDER;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                CCacheData.SlipType = null;
                CCacheData.OrderSlipType = null;
                CCacheData.PurchaseSlipType = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string TYPE_CODE, string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_SLIP_TYPE  set STATUS_FLAG = {0}", CConstant.DELETE_STATUS);
            strSql.Append(" where TYPE_CODE=@TYPE_CODE and CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = TYPE_CODE;
            parameters[1].Value = CODE;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                CCacheData.SlipType = null;
                CCacheData.OrderSlipType = null;
                CCacheData.PurchaseSlipType = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BaseSlipTypeTable GetModel(string TYPE_CODE, string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TYPE_CODE,CODE,NAME,COMPANY_CODE,STATUS_FLAG,COMPANY_NAME,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,INDICATES_ORDER from base_sliptype_view ");
            strSql.Append(" where TYPE_CODE=@TYPE_CODE and CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            SqlParameter[] parameters = {
					new SqlParameter("@TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = TYPE_CODE;
            parameters[1].Value = CODE;

            CZZD.ERP.Model.BaseSlipTypeTable model = new CZZD.ERP.Model.BaseSlipTypeTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TYPE_CODE = ds.Tables[0].Rows[0]["TYPE_CODE"].ToString();
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUE = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INDICATES_ORDER"].ToString() != "")
                {
                    model.INDICATES_ORDER = int.Parse(ds.Tables[0].Rows[0]["INDICATES_ORDER"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TYPE_NAME,CODE,NAME,COMPANY_NAME,STATUS_FLAG ,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,INDICATES_ORDER");
            strSql.Append(" FROM base_sliptype_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_sliptype_view");
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
                strSql.Append("order by T.TYPE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_sliptype_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

       

        #endregion  Method
    }
}
