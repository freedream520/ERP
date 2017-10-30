using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSlipTypeTable
    {
        public BaseSlipTypeTable()
        { }
        #region Model
        private string _type_code;
        private string _code;
        private string _name;
        private string _company_code;
        private int _statue;
        private string _company_name;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private int? _indicates_order;

        public string TYPE_CODE
        {
            set { _type_code = value; }
            get { return _type_code; }
        }

        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }

        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        public int STATUE
        {
            set { _statue = value; }
            get { return _statue; }
        }

        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
        }

        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }

        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }

        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }

        public int? INDICATES_ORDER
        {
            set { _indicates_order = value; }
            get { return _indicates_order; }
        }
        #endregion Model
    }
}
