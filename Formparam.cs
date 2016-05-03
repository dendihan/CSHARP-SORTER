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
    public partial class Formparam : Form
    {
        public Formparam()
        {
            InitializeComponent();
        }

        string Id;
        
        private void Paramquery()
        {
            string Sqlstr;
            DataSet ResDS;

            //select proper
            Sqlstr = string.Format("select * from PARAMETER");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "PARAMETER");
                this.Id = ResDS.Tables[0].Rows[0]["ID0000"].ToString();
                //gridControl1.DataSource = ResDS.Tables[0];
                foreach (Control cur in groupBox1.Controls)
                {
                    if (cur is TextBox)
                    {
                        cur.Text= ResDS.Tables[0].Rows[0][cur.Name].ToString();
                    }
                }  
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
   
        
        }


        private void Inquery()
        {
            string Sqlstr;
            DataSet ResDS;

            //select proper
            Sqlstr = string.Format("select * from PARAMIN");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "PARAMIN");
                gridControl1.DataSource = ResDS.Tables[0];
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

            //select proper
            Sqlstr = string.Format("select * from PARAMOUT");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "PARAMOUT");
                gridControl2.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

        }
        
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {

            btnsave_Click(sender, e);
            this.Close();
            this.Dispose();

        }

        private void Formparam_Load(object sender, EventArgs e)
        {
            //

            Inquery();
            Paramquery();
            Enabletext(false);
            Outquery();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            //
            Enabletext(true);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string Sqlstr;
            //DataSet ResDS;
            
            //textBox1.Enabled = false;

            if (ADDRESS.Enabled == true)
            {
                Enabletext(false);

                Sqlstr = string.Format("update PARAMETER set ADDRESS='{0}',CARS='{1}',ROUNDMAX='{2}',PLCIP='{3}',PORT00='{4}',BARCODEIP='{5}',BARCODEPORT='{6}' where ID0000='{7}'", ADDRESS.Text.Trim(), CARS.Text.Trim(), ROUNDMAX.Text.Trim(), PLCIP.Text.Trim(), PORT00.Text.Trim(), BARCODEIP.Text.Trim(), BARCODEPORT.Text.Trim(), this.Id);
                
                try
                {
                    //MessageBox.Show(Sqlstr);
                    Database.GetSqlcom(Sqlstr);
                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                }
            }
            
            
            
        }

        private void Enabletext(bool a)
        {
            foreach (Control cur in groupBox1.Controls)
            {
                if (cur is TextBox)
                {
                    cur.Enabled = a;
                }
            }  
        
        }

        private void btndelin_Click(object sender, EventArgs e)
        {
            string Id, Sqlstr, Code;


            if (gridView1.FocusedRowHandle >= 0)
            {
                if ((MessageBox.Show("是否确认删除选定入口", "提示", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {
        
                    Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                    Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    //Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    try
                    {



                        //delete PROPER here
                        Sqlstr = string.Format("delete from PARAMIN where ID0000='{0}'", Id);
                        Database.GetSqlcom(Sqlstr);
                    }
                    catch
                    {
                        MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);

                    }
                    Global.RecordLog("删除入口:" + Code);
                    Inquery();

                }
            }
        }

        private void btnaddin_Click(object sender, EventArgs e)
        {
            Formparaminedit frmparaminedit = new Formparaminedit();
            frmparaminedit.ShowDialog();
            frmparaminedit.Dispose();
            Inquery();
        }

        private void btneditin_Click(object sender, EventArgs e)
        {
            string Id, Code,Ip,Write,Read,Attr;
            int Rowhandle;


            if (gridView1.FocusedRowHandle >= 0)
            {
                Rowhandle = gridView1.FocusedRowHandle;
                //MessageBox.Show("123");
                //Id = gridView1.FocusedValue.ToString();
                Id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID0000").ToString();
                //Name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NAME00").ToString();
                Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                Ip = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IPADDR").ToString();
                Write = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "WRITEPLC").ToString();
                Read = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "READPLC").ToString();
                Attr = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ATTR00").ToString();
                
                //Formuseredit frmuseredit = new Formuseredit(new string[] { Id, Name, Code, Gpname, Passwd });
                Formparaminedit frmparaminedit = new Formparaminedit(new string[] { Id, Code, Ip, Write, Read, Attr });
                frmparaminedit.ShowDialog();
                frmparaminedit.Dispose();
                Inquery();
                gridView1.FocusedRowHandle = Rowhandle;
            }            
            
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Outquery();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string Id, Sqlstr, Code;


            if (gridView2.FocusedRowHandle >= 0)
            {
                if ((MessageBox.Show("是否确认删除选定出口", "提示", MessageBoxButtons.YesNo)) == DialogResult.Yes)
                {

                    Id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID0000").ToString();
                    Code = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "CODE00").ToString();
                    //Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODE00").ToString();
                    try
                    {



                        //delete PROPER here
                        Sqlstr = string.Format("delete from PARAMOUT where ID0000='{0}'", Id);
                        Database.GetSqlcom(Sqlstr);
                    }
                    catch
                    {
                        MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);

                    }
                    Global.RecordLog("删除出口:" + Code);
                    Outquery();

                }
            }
        }

        private void btnaddout_Click(object sender, EventArgs e)
        {
            Formparamoutedit frmparamoutedit = new Formparamoutedit();
            frmparamoutedit.ShowDialog();
            frmparamoutedit.Dispose();
            Outquery();
        }

        private void btneditout_Click(object sender, EventArgs e)
        {
            string Id;
            string Code;
            string Type;
            string Name;
            string Tarna;
            string Tarco;
            string Max;
            string Ip;
            string Opcmax;
            string Opccou;
            string Opcchg;
            string Opcbeg;
            string Opcend;
            string Opcguid;
            string State;
            


            int Rowhandle;
            Rowhandle = gridView2.FocusedRowHandle;

            if (Rowhandle >= 0)
            {
                
                //MessageBox.Show("123");
                //Id = gridView1.FocusedValue.ToString();
                Id = gridView2.GetRowCellValue(Rowhandle, "ID0000").ToString();
                Code = gridView2.GetRowCellValue(Rowhandle, "CODE00").ToString();
                Type = gridView2.GetRowCellValue(Rowhandle, "TYPE00").ToString();
                Name = gridView2.GetRowCellValue(Rowhandle, "NAME00").ToString();
                Tarco = gridView2.GetRowCellValue(Rowhandle, "TARCODE").ToString();
                Tarna = gridView2.GetRowCellValue(Rowhandle, "TARNAME").ToString();
                Max = gridView2.GetRowCellValue(Rowhandle, "MAX000").ToString();
                Ip = gridView2.GetRowCellValue(Rowhandle, "PRINTIP").ToString();
                Opcmax = gridView2.GetRowCellValue(Rowhandle, "OPCITEMIDMAX").ToString();
                Opccou = gridView2.GetRowCellValue(Rowhandle, "OPCITEMIDCOU").ToString();
                Opcchg = gridView2.GetRowCellValue(Rowhandle, "OPCITEMIDCHG").ToString();
                Opcbeg = gridView2.GetRowCellValue(Rowhandle, "OPCITEMBEGIN").ToString();
                Opcend = gridView2.GetRowCellValue(Rowhandle, "OPCITEMEND").ToString();
                Opcguid = gridView2.GetRowCellValue(Rowhandle, "OPCITEMGUID").ToString();
                State = gridView2.GetRowCellValue(Rowhandle, "STAT00").ToString();
                
                

             



                //Formuseredit frmuseredit = new Formuseredit(new string[] { Id, Name, Code, Gpname, Passwd });
                Formparamoutedit frmparamoutedit = new Formparamoutedit(new string[] { Id, Code, Type,Name,Tarco,Tarna,Max,Ip,Opcmax,Opccou,Opcchg,Opcbeg,Opcend,Opcguid,State });
                
                frmparamoutedit.ShowDialog();
                frmparamoutedit.Dispose();
                Outquery();
                gridView2.FocusedRowHandle = Rowhandle;
            }            
        }
    }
}
