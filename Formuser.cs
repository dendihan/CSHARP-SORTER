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
    public partial class Formuser : Form
    {
        public Formuser()
        {
            InitializeComponent();
        }


        private void Dataquery()
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v

            Sqlstr = string.Format("select A.ID0000,A.CODE00,A.NAME00,A.PASSWD,B.NAME00 GPNAME,DATE00 from USERS A LEFT JOIN USERGROUPS B on A.GROUP0=B.CODE00");
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "USER");
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

            string Id, Gpname, Name, Code,Passwd;


            if (gridView1.FocusedRowHandle >= 0)
            {
                    //MessageBox.Show("123");
                    //Id = gridView1.FocusedValue.ToString();
                    Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                    Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NAME00").ToString();
                    Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    Gpname = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GPNAME").ToString();
                    Passwd = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PASSWD").ToString();
                    Formuseredit frmuseredit = new Formuseredit(new string[] { Id, Name, Code, Gpname, Passwd });
                    frmuseredit.ShowDialog();
                    frmuseredit.Dispose();
                    Dataquery();
            }


        }

        private void Formuser_Load(object sender, EventArgs e)
        {
            Dataquery();
   
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string Id,Sqlstr,Name; 


            if(gridView1.FocusedRowHandle>=0)
            {
                if ((MessageBox.Show("是否确认删除选定用户", "提示", MessageBoxButtons.YesNo))==DialogResult.Yes) 
                {
                    //MessageBox.Show("123");
                    //Id = gridView1.FocusedValue.ToString();
                    Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                    Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NAME00").ToString();
                    //Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    try
                    {
                        

                        
                        //delete USER here
                        Sqlstr = string.Format("delete from USERS where ID0000='{0}'", Id);
                        Database.GetSqlcom(Sqlstr);
                    }
                    catch
                    {
                        MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                    
                    }
                    Global.RecordLog("删除角色:"+Name);
                    Dataquery();

                }  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formuseredit frmuseredit = new Formuseredit();
            frmuseredit.ShowDialog();
            frmuseredit.Dispose();
            Dataquery();
        }

      

    }
}
