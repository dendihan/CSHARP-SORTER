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
    public partial class Formrole : Form
    {
        public Formrole()
        {
            InitializeComponent();
        }


        private void Rolequery()
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v

            Sqlstr = string.Format("select * from USERGROUPS");
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "ROLE");
                gridControl1.DataSource = ResDS.Tables[0];
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

        private void btnquery_Click(object sender, EventArgs e)
        {

            string Id, Remark, Name, Code;


            if (gridView1.FocusedRowHandle >= 0)
            {
                    //MessageBox.Show("123");
                    //Id = gridView1.FocusedValue.ToString();
                    Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                    Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NAME00").ToString();
                    Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    Remark = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "REMARK").ToString();
                    Formroleedit frmroleedit = new Formroleedit(new string[]{Id,Name,Code,Remark});
                    frmroleedit.ShowDialog();
                    frmroleedit.Dispose();
                    Rolequery();
            }


        }

        private void Formrole_Load(object sender, EventArgs e)
        {
            Rolequery();
   
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string Id,Sqlstr,Name,Code; 


            if(gridView1.FocusedRowHandle>=0)
            {
                if ((MessageBox.Show("是否确认删除选定角色", "提示", MessageBoxButtons.YesNo))==DialogResult.Yes) 
                {
                    //MessageBox.Show("123");
                    //Id = gridView1.FocusedValue.ToString();
                    Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                    Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NAME00").ToString();
                    Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    try
                    {
                        
                        //delete ACTION of role firet
                        Sqlstr = string.Format("delete from GROUPACT where CODE00='{0}'", Code);
                        //MessageBox.Show(Sqlstr);
                        Database.GetSqlcom(Sqlstr);
                        
                        //delete ROLE here
                        Sqlstr = string.Format("delete from USERGROUPS where ID0000='{0}'", Id);
                        Database.GetSqlcom(Sqlstr);
                    }
                    catch
                    {
                        MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                    
                    }
                    Global.RecordLog("删除角色:"+Name);
                    Rolequery();

                }  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formroleedit frmroleedit = new Formroleedit();
            frmroleedit.ShowDialog();
            frmroleedit.Dispose();
            Rolequery();
        }

      

    }
}
