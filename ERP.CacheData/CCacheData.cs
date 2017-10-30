using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.CacheData
{
    public class CCacheData
    {
        private static BCommon bCommon = new BCommon();

        private static DataTable _slipType = null;
        private static DataTable _purchaseSlipType = null;
        private static DataTable _orderSlipType = null;
        private static DataTable _taxation = null;
        private static DataTable _currency = null;
        private static DataTable _myDesk = null;
        private static DataTable _warehouse = null;
        private static DataTable _reason = null;
        private static DataTable _attacheDirectory = null;
        private static DataTable _functions = null;
        private static DataTable _rolesFunction = null;
        private static DataTable _delay = null;
        private static DataTable _company = null;
        private static DataTable _stations = null;
        private static DataTable _fileType = null;
        private static DataTable _baseTable = null;
        private static DataTable _price = null;

        public static DataTable SlipType
        {
            get
            {
                if (_slipType == null)
                {
                    _slipType = new DataTable();
                    _slipType.Columns.Add("CODE", Type.GetType("System.String"));
                    _slipType.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _slipType.NewRow();
                    dr["CODE"] = "ORDER";
                    dr["NAME"] = "销售订单";
                    _slipType.Rows.Add(dr);

                    dr = _slipType.NewRow();
                    dr["CODE"] = "PURCHASE";
                    dr["NAME"] = "采购订单";
                    _slipType.Rows.Add(dr);
                }
                return _slipType;
            }
            set { _slipType = value; }
        }

        public static DataTable Delay
        {
            get
            {
                if (_delay == null)
                {
                    _delay = new DataTable();
                    _delay.Columns.Add("CODE", Type.GetType("System.String"));
                    _delay.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _delay.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "90日";
                    _delay.Rows.Add(dr);

                    dr = _delay.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "180日";
                    _delay.Rows.Add(dr);

                    dr = _delay.NewRow();
                    dr["CODE"] = "3";
                    dr["NAME"] = "一年";
                    _delay.Rows.Add(dr);
                }
                return _delay;
            }
            set { _delay = value; }
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        public static DataTable PurchaseSlipType
        {
            get
            {
                if (_purchaseSlipType == null)
                {
                    _purchaseSlipType = bCommon.GetMasterList("SLIP_TYPE", "", "", " TYPE_CODE='PURCHASE' ").Tables[0];
                }
                return CCacheData._purchaseSlipType;
            }
            set { CCacheData._purchaseSlipType = value; }
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        public static DataTable OrderSlipType
        {
            get
            {
                if (_orderSlipType == null)
                {
                    _orderSlipType = bCommon.GetMasterList("SLIP_TYPE", "", "", " TYPE_CODE='ORDER'").Tables[0];
                }
                return CCacheData._orderSlipType;
            }
            set { CCacheData._orderSlipType = value; }
        }

        public static DataTable Stations
        {
            get
            {
                if (_stations == null)
                {
                    _stations = bCommon.GetMasterList("NAMES", "", "", " CODE_TYPE='MaintenanceStations'").Tables[0];
                }
                return CCacheData._stations;
            }
            set { CCacheData._stations = value; }
        }

        /// <summary>
        /// 税率
        /// </summary>
        public static DataTable Taxation
        {
            get
            {
                if (_taxation == null)
                {
                    _taxation = bCommon.GetMasterList("TAXATION", "", "", "").Tables[0];
                }
                return CCacheData._taxation;
            }
            set { CCacheData._taxation = value; }
        }

        /// <summary>
        /// 货币
        /// </summary>
        public static DataTable Currency
        {
            get
            {
                if (_currency == null)
                {
                    _currency = bCommon.GetMasterList("CURRENCY", "", "", "").Tables[0];
                }
                return CCacheData._currency;
            }
            set { CCacheData._currency = value; }
        }

        /// <summary>
        /// 理由
        /// </summary>
        public static DataTable Reason
        {
            get
            {
                if (_reason == null)
                {
                    _reason = bCommon.GetMasterList("REASON", "", "", "").Tables[0];
                }
                return CCacheData._reason;
            }
            set { CCacheData._reason = value; }
        }

        /// <summary>
        /// 公司
        /// </summary>
        public static DataTable Company
        {
            get
            {
                if (_company == null)
                {
                    _company = bCommon.GetMasterList("COMPANY", "", "", "").Tables[0];
                }
                return CCacheData._company;
            }
            set { CCacheData._company = value; }
        }


        /// <summary>
        /// 我的桌面信息
        /// </summary>
        public static DataTable GetDesk(string companyCode, string userCode)
        {
            if (_myDesk == null || _myDesk.Rows.Count == 0)
            {
                ResetDesk(companyCode, userCode);
            }
            return _myDesk;
        }

        /// <summary>
        /// 重设我的桌面信息
        /// </summary>
        public static void ResetDesk(string companyCode, string userCode)
        {
            _myDesk = bCommon.GetDeskDatas(companyCode, userCode).Tables[0];
        }

        /// <summary>
        /// 仓库
        /// </summary>
        public static DataTable WAREHOUSE
        {
            get
            {
                if (_warehouse == null)
                {
                    _warehouse = bCommon.GetMasterList("WAREHOUSE", "", "", "").Tables[0];
                }
                return CCacheData._warehouse;

            }
            set { CCacheData._warehouse = value; }
        }

        /// <summary>
        ///  附件目录
        /// </summary>
        public static DataTable AttacheDirectory
        {
            get
            {
                if (_attacheDirectory == null)
                {
                    _attacheDirectory = bCommon.GetNames("ATTACHED_PATH").Tables[0];
                }
                return CCacheData._attacheDirectory;
            }
            set { CCacheData._attacheDirectory = value; }
        }

        /// <summary>
        /// 获得指定类型的目录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetAttacheDirectory(string type)
        {
            string ret = "";
            foreach (DataRow dr in CCacheData.AttacheDirectory.Rows)
            {
                if (type.Equals(dr["CODE"]))
                {
                    ret = CConvert.ToString(dr["PROPERT1"]);
                }
            }
            return ret;
        }

        /// <summary>
        /// 系统功能列表
        /// </summary>
        public static DataTable Function
        {
            get
            {
                if (_functions == null)
                {
                    _functions = bCommon.GetFunctionList().Tables[0];
                }
                return CCacheData._functions;
            }
            set { CCacheData._functions = value; }
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public static void SetRolesFunction(string roles_code)
        {
            _rolesFunction = bCommon.GetRoles(roles_code).Tables[0];
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public static DataTable GetRolesFunction(string roles_code)
        {
            if (_rolesFunction == null)
            {
                SetRolesFunction(roles_code);
            }
            return _rolesFunction;
        }

        /// <summary>
        /// 导入文件类型
        /// </summary>
        public static DataTable FileType
        {
            get
            {
                if (_fileType == null)
                {
                    _fileType = new DataTable();
                    _fileType.Columns.Add("CODE", Type.GetType("System.String"));
                    _fileType.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _fileType.NewRow();
                    dr["CODE"] = "EXCEL";
                    dr["NAME"] = "Excel文件(*.xls,*.xlsx)";
                    _fileType.Rows.Add(dr);

                    dr = _fileType.NewRow();
                    dr["CODE"] = "TXT";
                    dr["NAME"] = "文本文件(*.txt)";
                    _fileType.Rows.Add(dr);

                    dr = _fileType.NewRow();
                    dr["CODE"] = "CSV";
                    dr["NAME"] = "文本文件(*.csv)";
                    _fileType.Rows.Add(dr);
                }
                return CCacheData._fileType;
            }
            set { CCacheData._fileType = value; }
        }

        /// <summary>
        /// 导入数据库表名
        /// </summary>
        public static DataTable BaseTable
        {
            get
            {
                if (_baseTable == null)
                {
                    _baseTable = new DataTable();
                    _baseTable.Columns.Add("CODE", Type.GetType("System.String"));
                    _baseTable.Columns.Add("NAME", Type.GetType("System.String"));
                    DataRow dr = null;

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "";
                    dr["NAME"] = "未设定";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT_GROUP";
                    dr["NAME"] = "商品种类";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT";
                    dr["NAME"] = "商品信息";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT_PARTS";
                    dr["NAME"] = "商品材料构成";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT_UNIT";
                    dr["NAME"] = "商品单位";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_UNIT";
                    dr["NAME"] = "单位设定";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_CUSTOMER";
                    dr["NAME"] = "客户信息";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_CUSTOMER_PRICE";
                    dr["NAME"] = "客户单价";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_CUSTOMER_REPORTED";
                    dr["NAME"] = "客户备案";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SUPPLIER";
                    dr["NAME"] = "供应商";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_STOCK";
                    dr["NAME"] = "库存";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_WAREHOUSE";
                    dr["NAME"] = "仓库";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_LOCATION";
                    dr["NAME"] = "货位";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SUPPLIER_PRICE";
                    dr["NAME"] = "供应商单价";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SAFETY_STOCK";
                    dr["NAME"] = "安全在库数";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_CURRENCY";
                    dr["NAME"] = "货币";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_TAXATION";
                    dr["NAME"] = "税率";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SLIP_TYPE";
                    dr["NAME"] = "单据类型";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_DELIVERY";
                    dr["NAME"] = "客户地址";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_MASTER_MACHINE";
                    dr["NAME"] = "机械序列号";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_USER";
                    dr["NAME"] = "用户";
                    _baseTable.Rows.Add(dr);
                }
                return CCacheData._baseTable;
            }
            set { CCacheData._baseTable = value; }
        }

        public static DataTable PRICE_TAX
        {
            get
            {
                if (_price == null)
                {
                    _price = new DataTable();
                    _price.Columns.Add("CODE", Type.GetType("System.String"));
                    _price.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _price.NewRow();
                    dr["CODE"] = "0";
                    dr["NAME"] = "不含税单价";
                    _price.Rows.Add(dr);

                    dr = _price.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "含税单价";
                    _price.Rows.Add(dr);
                }
                return _price;
            }
            set { _price = value; }
        }


    }//END CLASS
}
