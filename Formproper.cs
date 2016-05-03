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
    public partial class Formproper : Form
    {
        public Formproper()
        {
            InitializeComponent();
        }

        private void Properquery()
        {
            string Sqlstr;
            DataSet ResDS;

            //select proper
            Sqlstr = string.Format("select * from OUTPROPER");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "OUTPROPER");
                gridControl2.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
        
        }
        
        private void Outquery()
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v


            //select  OUT
            Sqlstr = string.Format("select * from PARAMOUT");
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "PARAMOUT");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Id, Sqlstr, Name;


            if (gridView2.FocusedRowHandle >= 0)
            {
                if ((MessageBox.Show("是否确认删除选定特征码", "提示", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
                    //MessageBox.Show("123");
                    //Id = gridView1.FocusedValue.ToString();
                    Id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID0000").ToString();
                    Name = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PROPER").ToString();
                    //Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    try
                    {



                        //delete PROPER here
                        Sqlstr = string.Format("delete from OUTPROPER where ID0000='{0}'", Id);
                        Database.GetSqlcom(Sqlstr);
                    }
                    catch
                    {
                        MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);

                    }
                    Global.RecordLog("删除特征码:" + Name);
                    Properquery();

                }
            }
            /*
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
             */
        }

//       private void Formpermission_Load(object sender, EventArgs e)
//        {
            
//        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {

                //MessageBox.Show(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString());
                gridView2.ActiveFilterString = "OUT000='" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString()+"'";
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
            
            /*
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

            */
        }

        private void Formproper_Load(object sender, EventArgs e)
        {
            Outquery();
            Properquery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Type;
            //ADD PROPER
            if (gridView1.FocusedRowHandle >= 0)
            {
                Type = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TYPE00").ToString();
                if(Type=="异常出口")
                {
                    MessageBox.Show("异常出口，不需要设置特征码", "提示", MessageBoxButtons.OK);
                    return;
                }
                
                Formproperedit frmproperedit = new Formproperedit(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString());
                frmproperedit.ShowDialog();
                frmproperedit.Dispose();
                Properquery();
           

            }
            


        }

        private void button3_Click(object sender, EventArgs e)
        {                        
            //EDIT PROPER

            string Id,Out,Proper,Desc;


            if (gridView2.FocusedRowHandle >= 0)
            {

                Id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID0000").ToString();
                Out = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OUT000").ToString();
                Proper = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "PROPER").ToString();
                Desc = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DESC00").ToString();
                Formproperedit frmproperedit = new Formproperedit(new string[] { Id, Out, Proper, Desc });
                frmproperedit.ShowDialog();
                frmproperedit.Dispose();
                Properquery();
            }

        }
    }
}
