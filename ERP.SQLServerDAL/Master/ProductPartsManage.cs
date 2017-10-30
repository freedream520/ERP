using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductPartsManage:IProductParts
    {
        public ProductPartsManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PRODUCT_CODE,string PRODUCT_PART_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_PRODUCT_PARTS");
			strSql.Append(" where PRODUCT_CODE=@PRODUCT_CODE and PRODUCT_PART_CODE=@PRODUCT_PART_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = PRODUCT_CODE;
			parameters[1].Value = PRODUCT_PART_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseProductPartsTable model)
		{
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.PRODUCT_CODE, model.PRODUCT_PART_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_PRODUCT_PARTS set ");
                strSql.Append("QUANTITY=@QUANTITY,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where PRODUCT_CODE=@PRODUCT_CODE and PRODUCT_PART_CODE=@PRODUCT_PART_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.PRODUCT_CODE;
                parameters[1].Value = model.PRODUCT_PART_CODE;
                parameters[2].Value = model.QUANTITY;
                parameters[3].Value = model.STATUS_FLAG;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;			
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_PRODUCT_PARTS(");
                strSql.Append("PRODUCT_CODE,PRODUCT_PART_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@PRODUCT_CODE,@PRODUCT_PART_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),				
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.PRODUCT_CODE;
                parameters[1].Value = model.PRODUCT_PART_CODE;
                parameters[2].Value = model.QUANTITY;
                parameters[3].Value = model.STATUS_FLAG;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion 
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CZZD.ERP.Model.BaseProductPartsTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_PRODUCT_PARTS set ");
			strSql.Append("QUANTITY=@QUANTITY,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
			strSql.Append(" where PRODUCT_CODE=@PRODUCT_CODE and PRODUCT_PART_CODE=@PRODUCT_PART_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,40),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			parameters[0].Value = model.PRODUCT_CODE;
			parameters[1].Value = model.PRODUCT_PART_CODE;
			parameters[2].Value = model.QUANTITY;
			parameters[3].Value = model.STATUS_FLAG;			
			parameters[4].Value = model.LAST_UPDATE_USER;			

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
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
		public bool Delete(string PRODUCT_CODE,string PRODUCT_PART_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("update BASE_PRODUCT_PARTS  set STATUS_FLAG = {0}", CConstant.DELETE_STATUS);
            strSql.Append(" where PRODUCT_CODE=@PRODUCT_CODE and PRODUCT_PART_CODE=@PRODUCT_PART_CODE ");		    
			SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = PRODUCT_CODE;
			parameters[1].Value = PRODUCT_PART_CODE;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
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
		public CZZD.ERP.Model.BaseProductPartsTable GetModel(string PRODUCT_CODE,string PRODUCT_PART_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PRODUCT_CODE,PRODUCT_NAME,PRODUCT_PART_CODE,PRODUCT_PART_NAME,QUANTITY,STATUS_FLAG,CREATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_NAME,LAST_UPDATE_TIME from base_parts_view ");
			strSql.Append(" where PRODUCT_CODE=@PRODUCT_CODE and PRODUCT_PART_CODE=@PRODUCT_PART_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
			SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_PART_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = PRODUCT_CODE;
			parameters[1].Value = PRODUCT_PART_CODE;

			CZZD.ERP.Model.BaseProductPartsTable model=new CZZD.ERP.Model.BaseProductPartsTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PRODUCT_CODE=ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
				model.PRODUCT_PART_CODE=ds.Tables[0].Rows[0]["PRODUCT_PART_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["QUANTITY"].ToString()!="")
				{
					model.QUANTITY=decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString()!="")
				{
					model.STATUS_FLAG=int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
				}
				model.CREATE_USER=ds.Tables[0].Rows[0]["CREATE_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString()!="")
				{
					model.CREATE_DATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
				}
				model.LAST_UPDATE_USER=ds.Tables[0].Rows[0]["LAST_UPDATE_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString()!="")
				{
					model.LAST_UPDATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
				}
                model.PRODUCT_NAME = ds.Tables[0].Rows[0]["PRODUCT_NAME"].ToString();
                model.PRODUCT_PART_NAME = ds.Tables[0].Rows[0]["PRODUCT_PART_NAME"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PRODUCT_CODE,PRODUCT_NAME,PRODUCT_PART_CODE,PRODUCT_PART_NAME,QUANTITY,STATUS_FLAG,CREATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_NAME,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_parts_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_parts_view");
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
                strSql.Append("order by T.PRODUCT_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_parts_view T");
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
