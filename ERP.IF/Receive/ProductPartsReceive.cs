using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class ProductPartsReceive : AbstractReceive
    {
        public ProductPartsReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public ProductPartsReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override string[] doUpdateDB()
        {
            BaseProductPartsTable ProductPartsTable = null;
            BProductParts bProductParts = new BProductParts();
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
                if (CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Length > 40)
                {
                    string product = GetValue(dr, "PRODUCT_CODE").ToString().Substring(0, 40);
                    str.Append(CheckProduct(product, "商品编号"));
                }
                else
                {
                    str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "PRODUCT_CODE")), "商品编号"));
                }
                //材料商品编号
                if (CConvert.ToString(GetValue(dr, "PRODUCT_PART_CODE")).Length > 40)
                {
                    string productpart = GetValue(dr, "PRODUCT_PART_CODE").ToString().Substring(0, 40);
                    str.Append(CheckProduct(productpart, "材料商品编号"));
                }
                else
                {
                    str.Append(CheckProduct(CConvert.ToString(GetValue(dr, "PRODUCT_PART_CODE")), "材料商品编号"));
                }
                //数量
                str.Append(CheckDecimal(GetValue(dr, "QUANTITY", 0), 12, 2, "数量"));
                //状态
                str.Append(CheckInt(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL_STATUS), 9, "状态"));
                if (str.ToString().Trim().Length > 0)
                {
                    strError.Append(GetStringBuilder(dr, str.ToString().Trim()));
                    failureData++;
                    continue;
                }
                try
                {
                    ProductPartsTable = new BaseProductPartsTable();
                    if (GetValue(dr, "PRODUCT_CODE").ToString().Length > 20)
                    {
                        ProductPartsTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE")).Substring(0, 20);
                    }
                    else
                    {
                        ProductPartsTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_CODE"));
                    }
                    if (GetValue(dr, "PRODUCT_PART_CODE").ToString().Length > 20)
                    {
                        ProductPartsTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_PART_CODE")).Substring(0, 20);
                    }
                    else
                    {
                        ProductPartsTable.PRODUCT_CODE = CConvert.ToString(GetValue(dr, "PRODUCT_PART_CODE"));
                    }
                    ProductPartsTable.QUANTITY = CConvert.ToDecimal(GetValue(dr, "QUANTITY", 0));
                    ProductPartsTable.STATUS_FLAG = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL_STATUS));
                    ProductPartsTable.CREATE_USER = _userInfo.CODE;
                    ProductPartsTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bProductParts.Exists(ProductPartsTable.PRODUCT_CODE, ProductPartsTable.PRODUCT_PART_CODE))
                    {
                        bProductParts.Add(ProductPartsTable);
                    }
                    else
                    {
                        bProductParts.Update(ProductPartsTable);
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

        public override void doCheckError()
        {

        }
    }
}
