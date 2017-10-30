using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.Bll
{
    public class BDepositArrLine
    {
        IDepositArrLine dal = DALFactory.DataAccess.CreateDepositArrLineManage();
    }
}
