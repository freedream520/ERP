using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmMasterMachine : FrmBase
    {
        private BMasterMachine bMasterMachine = new BMasterMachine();
        private DataTable _currentDt = new DataTable();
        private BaseMasterMachineTable _currentMasterMachineTable;
        private bool isSearch = false;

        public FrmMasterMachine()
        {
            InitializeComponent();
        }

        private void FrmMasterMachine_Load(object sender, EventArgs e)
        {
            init();
            this.WindowState = FormWindowState.Normal;
        }

        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            _currentDt.Columns.Add("MACHINE_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("MACHINE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("CUSTOMER_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("STATIONS", Type.GetType("System.String"));
            _currentDt.Columns.Add("PURCHASE_ORDER_SLIP_NUMBER", Type.GetType("System.String"));
            _currentDt.Columns.Add("FANUC_SERIAL_NUMBER", Type.GetType("System.String"));
            _currentDt.Columns.Add("FANUC_SLIP_NUMBER", Type.GetType("System.String"));
            _currentDt.Columns.Add("RECEIPT_DATE", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("CREATE_DATE_TIME", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("LAST_UPDATE_TIME", Type.GetType("System.String"));
            _currentDt.Columns.Add("PURCHASE_SLIP_NUMBER", Type.GetType("System.String"));
            _currentDt.Columns.Add("SALE_DATE_TIME", Type.GetType("System.String"));
            PageSize = 18;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion
        }

        #region 按键
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["MACHINE_CODE"].Value == null || "".Equals(row.Cells["MACHINE_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMachineName.Focused)
                {
                    MasterToolBar_DoSearch_Click(sender, e);
                }
                else
                {
                    //System.Windows.Forms.SendKeys.Send("{Tab}");
                    ProcessTabKey(true);
                }
            }
        }
        #endregion

        #region  页面事件
        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        /// <summary>
        /// gridView双击事件
        /// </summary>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_MODIFY);
        }

        #endregion

        #region 工具条事件
        /// <summary>
        /// 新建
        /// </summary>
        private void MasterToolBar_DoNew_Click(object sender, EventArgs e)
        {
            OpenDialogFrm(CConstant.MODE_NEW);
        }

        /// <summary>
        /// 复制
        /// </summary>
        private void MasterToolBar_DoCopy_Click(object sender, EventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_COPY);
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void MasterToolBar_DoDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    GetCurrentSelectedTable();
                    if (_currentMasterMachineTable != null)
                    {
                        bMasterMachine.Delete(_currentMasterMachineTable.MACHINE_CODE);
                        Search(this.pgControl.GetCurrentPage());
                    }
                    else
                    {
                        MessageBox.Show("请选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _currentMasterMachineTable = null;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void MasterToolBar_DoModify_Click(object sender, EventArgs e)
        {
            GetCurrentSelectedTable();
            OpenDialogFrm(CConstant.MODE_MODIFY);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void MasterToolBar_DoSearch_Click(object sender, EventArgs e)
        {
            isSearch = true;
            Search(1);
        }

        /// <summary>
        /// 导出
        /// </summary>
        private void MasterToolBar_DoExport_Click(object sender, EventArgs e)
        {
            _currentDt = bMasterMachine.GetList(GetConduction()).Tables[0];
            if (isSearch && _currentDt != null)
            {
                int result = CommonExport.DataTableToExcel(_currentDt, CConstant.MASTER_MACHINE_HEADER, CConstant.MASTER_MACHINE_COLUMNS, "MASTER_MACHINE", "MASTER_MACHINE");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void MasterToolBar_DoCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查询
        private void Search(int currentPage)
        {
            int recordCount = bMasterMachine.GetRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);

            //初始化工具条
            this.MasterToolBar.SetMasterToolsBar(GetDataTabelRowsCount(_currentDt));
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            if (txtMachineCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and MACHINE_CODE like '{0}%'", txtMachineCode.Text.Trim());
            }
            if (txtMachineName.Text.Trim() != "")
            {
                sb.AppendFormat(" and MACHINE_NAME like '{0}%'", txtMachineName.Text.Trim());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bMasterMachine.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;
        }
        #endregion

        /// <summary>
        /// 打开新窗口
        /// </summary>
        private void OpenDialogFrm(int mode)
        {
            if (mode == CConstant.MODE_NEW || _currentMasterMachineTable != null)
            {
                FrmMasterMachineDialog frm = new FrmMasterMachineDialog();
                frm.UserInfo = _userInfo;
                frm.CurrentMasterMachineTable = _currentMasterMachineTable;
                frm.Mode = mode;
                DialogResult resule = frm.ShowDialog(this);
                if (resule == DialogResult.OK && isSearch)
                {
                    Search(this.pgControl.GetCurrentPage());
                }
                frm.Dispose();
            }
            else
            {
                //MessageBox.Show("请选择正确的行!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            _currentMasterMachineTable = null;
        }

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private void GetCurrentSelectedTable()
        {
            try
            {
                string code = dgvData.SelectedRows[0].Cells[0].Value.ToString();
                if (code != "")
                {
                    _currentMasterMachineTable = bMasterMachine.GetModel(code);
                }
            }
            catch (Exception ex) { }

            if (_currentMasterMachineTable == null || _currentMasterMachineTable.MACHINE_CODE == null || "".Equals(_currentMasterMachineTable.MACHINE_CODE))
            {
                _currentMasterMachineTable = null;
            }
        }

    }
}
