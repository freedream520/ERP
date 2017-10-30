using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Data;
using CZZD.ERP.Bll;

namespace CZZD.ERP.IF
{
    public class ProductReceive : AbstractReceive
    {
        public ProductReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }
        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseProductTable ProductTable = null;
            BProduct bProduct = new BProduct();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                //编号
                if (GetValue(dr, "CODE").ToString().Length > 40)
                {                   
                    if (!string.IsNullOrEmpty(GetValue(dr, "CODE").ToString().Substring(0, 40)))
                    {
                        str.Append(CheckString(GetValue(dr, "CODE"), "编号"));
                    }
                    else
                    {
                        str.Append("编号不能为空!");
                    }
                }
                else 
                {
                    if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                    {
                        str.Append(CheckString(GetValue(dr, "CODE"), "编号"));
                    }
                    else
                    {
                        str.Append("编号不能为空!");
                    }
                }
                //名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "名称"));
                //商品规格
                str.Append(CheckLenght(GetValue(dr, "SPEC"), 50, "商品规格"));
                //机器型号
                str.Append(CheckLenght(GetValue(dr, "MODEL_NUMBER"), 50, "机器型号"));
                //商品类别编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "GROUP_CODE"))))
                {
                    str.Append(CheckProductGroup(CConvert.ToString(GetValue(dr, "GROUP_CODE")), "商品类别编号"));
                }
                //基本单位
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"))))
                {
                    str.Append(CheckUnit(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE")), "基本单位"));
                }

                //原价计算对象
                str.Append(CheckLenght(GetValue(dr, "ACCOUTING_TARGET"), 100, "原价计算对象"));
                //海关商品编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "HS_CODE"))))
                {
                    str.Append(CheckHsCode(CConvert.ToString(GetValue(dr, "HS_CODE")), "海关商品编号"));
                }
                //默认售价
                str.Append(CheckDecimal(GetValue(dr, "SALES_PRICE", 0), 12, 2, "默认售价"));
                //货位
                str.Append(CheckLenght(GetValue(dr, "LOCATION_CODE"), 20, "货位"));
                //在库Flag
                if (CConvert.ToInt32(GetValue(dr, "STOCK_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "STOCK_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "STOCK_FLAG", 1)) != "")
                {
                    str.Append("在库Flag只能为1或2!");
                }
                else
                {
                    str.Append(CheckInt(GetValue(dr, "STOCK_FLAG", 1), 2, "在库Flag"));
                }
                //1:组成品  2：材料
                if (CConvert.ToInt32(GetValue(dr, "PROPERTY_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "PROPERTY_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "PROPERTY_FLAG", 1)) != "")
                {
                    str.Append("是否组成品只能为1或2!");
                }
                //一式品
                if (CConvert.ToInt32(GetValue(dr, "FROMSET_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "FROMSET_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "FROMSET_FLAG", 1)) != "")
                {
                    str.Append("一式品输入只能为1或2!");
                }
                //机械区分
                if (CConvert.ToInt32(GetValue(dr, "MECHANICAL_DISTINCTION_FLAG", 1)) != 1 && CConvert.ToInt32(GetValue(dr, "MECHANICAL_DISTINCTION_FLAG", 1)) != 2 && CConvert.ToString(GetValue(dr, "MECHANICAL_DISTINCTION_FLAG", 1)) != "")
                {
                    str.Append("机械区分输入只能为1或2!"); 
                }
                //安全在库数
                str.Append(CheckDecimal(GetValue(dr, "SAFETY_STOCK", 0), 12, 2, "安全在库数"));
                //状态
                str.Append(CheckInt(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL_STATUS), 1, "状态"));
                //销售地点
                str.Append(CheckInt(GetValue(dr, "SELL_LOCATION", CConstant.NORMAL_STATUS), 1, "销售地点"));
                //包装方式
                str.Append(CheckInt(GetValue(dr, "PACKAGE_MODE", CConstant.NORMAL_STATUS), 1, "包装方式"));
                //名称
                str.Append(CheckLenght(GetValue(dr, "NAME_JP"), 100, "日文名称"));
                //含税单价
                str.Append(CheckDecimal(GetValue(dr, "PURCHASE_PRICE", 0), 12, 2, "含税单价"));
                //代理店销售价格
                str.Append(CheckDecimal(GetValue(dr, "CUSTOMER_SALES_PRICE", 0), 12, 2, "代理店销售价格"));
                //不含税单价
                str.Append(CheckDecimal(GetValue(dr, "PURCHASE_PRICE_WITHOUT_TAX", 0), 12, 2, "不含税单价"));
                //含税单价
                //str.Append(CheckDecimal(GetValue(dr, "PURCHASE_PRICE_INCLUDED_TAX", 0), 12, 2, "含税单价"));
                //日元单价
                str.Append(CheckDecimal(GetValue(dr, "PRICE_JP", 0), 12, 2, "日元单价"));

                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    int ret = 0;
                    ProductTable = new BaseProductTable();
                    if (GetValue(dr, "CODE").ToString().Length > 20)
                    {
                        ProductTable.CODE = CConvert.ToString(GetValue(dr, "CODE")).Substring(0, 20);
                    }
                    else
                    {
                        ProductTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    }
                    ProductTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    ProductTable.SPEC = CConvert.ToString(GetValue(dr, "SPEC"));
                    ProductTable.MODEL_NUMBER = CConvert.ToString(GetValue(dr, "MODEL_NUMBER"));
                    ProductTable.GROUP_CODE = CConvert.ToString(GetValue(dr, "GROUP_CODE"));
                    if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"))))
                    {
                        ProductTable.BASIC_UNIT_CODE = CConvert.ToString(GetValue(dr, "BASIC_UNIT_CODE"));
                    }
                    else
                    {
                        ProductTable.BASIC_UNIT_CODE = "01";
                    }
                    ProductTable.ACCOUTING_TARGET = CConvert.ToInt32(GetValue(dr, "ACCOUTING_TARGET"));
                    ProductTable.HS_CODE = CConvert.ToString(GetValue(dr, "HS_CODE"));
                    ProductTable.LOCATION_CODE = CConvert.ToString(GetValue(dr, "LOCATION_CODE"));
                    ProductTable.STOCK_FLAG = CConvert.ToInt32(GetValue(dr, "STOCK_FLAG", 1));
                    ProductTable.PROPERTY_FLAG = CConvert.ToInt32(GetValue(dr, "PROPERTY_FLAG", 1));
                    ProductTable.FROMSET_FLAG = CConvert.ToInt32(GetValue(dr, "FROMSET_FLAG", 1));
                    ProductTable.MECHANICAL_DISTINCTION_FLAG = CConvert.ToInt32(GetValue(dr, "MECHANICAL_DISTINCTION_FLAG", 1));
                    ProductTable.SAFETY_STOCK = CConvert.ToDecimal(GetValue(dr, "SAFETY_STOCK", 0));
                    ProductTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL_STATUS));

                    ProductTable.SELL_LOCATION = CConvert.ToInt32(GetValue(dr, "SELL_LOCATION", 1));
                    ProductTable.PACKAGE_MODE = CConvert.ToInt32(GetValue(dr, "PACKAGE_MODE", 1));
                    ProductTable.NAME_JP = CConvert.ToString(GetValue(dr, "NAME_JP"));

                    ProductTable.PURCHASE_PRICE_INCLUDED_TAX = CConvert.ToDecimal(GetValue(dr, "PURCHASE_PRICE", 0));
                    ProductTable.SALES_PRICE = CConvert.ToDecimal(GetValue(dr, "SALES_PRICE", 0));
                    ProductTable.PURCHASE_PRICE_WITHOUT_TAX = CConvert.ToDecimal(GetValue(dr, "PURCHASE_PRICE_WITHOUT_TAX", 0));
                    ProductTable.CUSTOMER_SALES_PRICE = CConvert.ToDecimal(GetValue(dr, "CUSTOMER_SALES_PRICE", 0));
                    ProductTable.PRICE_JP = CConvert.ToDecimal(GetValue(dr, "PRICE_JP", 0));

                    ProductTable.CREATE_USER = _userInfo.CODE;
                    ProductTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProduct.Exists(ProductTable.CODE))
                    {
                        bProduct.Add(ProductTable);
                    }
                    else
                    {
                        bProduct.Update(ProductTable);
                    }
                    successData++;
                }
                catch
                {
                    strError.Append(GetStringBuilder(dr, " 数据导入失败，请与系统管理员联系！").ToString());
                    failureData++;
                }
            }
            //错误记录处理
            if (strError.Length > 0)
            {
                errorFilePath = WriteFile(strError.ToString());
            }

            //备份处理
            backupFilePath = BackupFile();

            return new string[] { successData.ToString(), failureData.ToString(), errorFilePath, backupFilePath };
        }
    }
}
