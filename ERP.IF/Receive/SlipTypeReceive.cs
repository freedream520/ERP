﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.IF
{
    public class SlipTypeReceive : AbstractReceive
    {
        public SlipTypeReceive(string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public SlipTypeReceive(bool anAutoMode, string aFileName, string fileType, string sheet, Hashtable _filedsHt, BaseUserTable userInfo)
            : base(anAutoMode, aFileName, fileType, sheet, _filedsHt, userInfo)
        {
        }

        public override void doCheckError()
        {

        }

        public override string[] doUpdateDB()
        {
            BaseSlipTypeTable SlipTypeTable = null;
            BSlipType bSlipType = new BSlipType();
            StringBuilder strError = new StringBuilder();
            int successData = 0;
            int failureData = 0;
            string errorFilePath = "";
            string backupFilePath = "";

            //数据导入处理
            foreach (DataRow dr in _csvDataTable.Rows)
            {
                StringBuilder str = new StringBuilder();
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "TYPE_CODE"))))
                {
                    str.Append(CheckSlipType(CConvert.ToString(GetValue(dr, "TYPE_CODE")), "单据类型"));
                }
                else
                {
                    str.Append("单据类型不能为空!");
                }
                //订单类型编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "CODE"))))
                {
                    str.Append(CheckString(GetValue(dr, "CODE"), 20, "单据类型编号"));
                }
                else
                {
                    str.Append("订单类型编号不能为空!");
                }
                //订单类型名称
                str.Append(CheckLenght(GetValue(dr, "NAME"), 100, "单据类型名称"));
                //公司编号
                if (!string.IsNullOrEmpty(CConvert.ToString(GetValue(dr, "COMPANY_CODE"))))
                {
                    str.Append(CheckCompany(CConvert.ToString(GetValue(dr, "COMPANY_CODE")), "公司"));
                }                
                //表示顺序
                str.Append(CheckInt(GetValue(dr, "INDICATES_ORDER", 0), 100000, "表示顺序"));
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
                    SlipTypeTable = new BaseSlipTypeTable();
                    SlipTypeTable.TYPE_CODE = CConvert.ToString(GetValue(dr, "TYPE_CODE"));
                    SlipTypeTable.CODE = CConvert.ToString(GetValue(dr, "CODE"));
                    SlipTypeTable.NAME = CConvert.ToString(GetValue(dr, "NAME"));
                    SlipTypeTable.COMPANY_CODE = CConvert.ToString(GetValue(dr, "COMPANY_CODE"));
                    SlipTypeTable.INDICATES_ORDER = CConvert.ToInt32(GetValue(dr, "INDICATES_ORDER", 0));
                    SlipTypeTable.STATUE = CConvert.ToInt32(GetValue(dr, "STATUS_FLAG", CConstant.NORMAL_STATUS));
                    SlipTypeTable.CREATE_USER = _userInfo.CODE;
                    SlipTypeTable.LAST_UPDATE_USER = _userInfo.CODE;

                    if (!bSlipType.Exists(SlipTypeTable.TYPE_CODE, SlipTypeTable.CODE))
                    {
                        bSlipType.Add(SlipTypeTable);
                    }
                    else
                    {
                        bSlipType.Update(SlipTypeTable);
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
