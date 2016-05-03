using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace yprfj
{
    public partial class Formpermission : Form
    {
        public Formpermission()
        {
            InitializeComponent();
        }

        private void Dataquery()
        {
            string Sqlstr;
            DataSet ResDS1,ResDS2;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v


            //select  ROLE
            Sqlstr = string.Format("select * from USERGROUPS");
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS1 = Database.GetDataset(Sqlstr, "ROLE");
                gridControl1.DataSource = ResDS1.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

            //select action
            Sqlstr = string.Format("select * from GROUPACT");
            try
            {
                ResDS2 = Database.GetDataset(Sqlstr, "ACTION");
                gridControl2.DataSource = ResDS2.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

        }

      

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Sqlstr;
            DataSet ResDS;

            Sqlstr = string.Format("INSERT INTO GROUPACT(CODE00,ACTNAME,CNNAME,CHOOSE) SELECT '{0}',ACTNAME,CNNAME,'1' FROM  ACTIONS WHERE ACTNAME NOT IN(SELECT ACTNAME FROM GROUPACT WHERE CODE00='{0}')", gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString());

            try
            {
                Database.GetSqlcom(Sqlstr);
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

            Sqlstr = string.Format("select * from GROUPACT");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "ACTION");
                gridControl2.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
        }

        private void Formpermission_Load(object sender, EventArgs e)
        {
            Dataquery();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {

                //MessageBox.Show(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString());
                gridView2.ActiveFilterString = "CODE00='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString()+"'";
            }        
        }

        private void gridControl2_BackgroundImageChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //MessageBox.Show("123");
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //MessageBox.Show(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CHOOSE").ToString());
            String Id, Oldcheck, Newcheck,Sqlstr;
            Oldcheck = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CHOOSE").ToString();
            Id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID0000").ToString();
            if(Oldcheck=="0")
                Newcheck="1";
            else
                Newcheck="0";

            Sqlstr = string.Format("update GROUPACT set CHOOSE='{0}' where ID0000='{1}'",Newcheck,Id);

            try
            {
                Database.GetSqlcom(Sqlstr);
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

        
        }
    }
}
