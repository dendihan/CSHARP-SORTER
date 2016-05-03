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
    public partial class Formdatacompute : Form
    {
        public Formdatacompute()
        {
            InitializeComponent();
        }

        private void Formdatacompute_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
       
            btnquery_Click(sender, e);
            ShowCol();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v

            Sqlstr = string.Format("select *,(case PSTATE when 0 then '未分拣' when 1 then '已扫描' when 2 then '已分拣' else '已打印' end) PSTATE2 from V_FJDATA where convert(varchar(10),FJDATE,23) between '{0}' and '{1}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "FJDATA");
                gridControl1.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
        }

        private void btncol_Click(object sender, EventArgs e)
        {
            Global.RecordLog("更改自定义列");
            // this button is used to change column show for FJDATA
            Formshowcol frmshowcol = new Formshowcol();
            frmshowcol.ShowDialog();
            frmshowcol.Dispose();
            //btnquery_Click(sender, e);
            ShowCol();
   
           
        }

        private void ShowCol()
        {
            string Sqlstr;
            DataSet ResDS;
            DataRow Myrow;
            int Colcnt;

            Sqlstr = string.Format("select * from USERSHOWCOL where USERID='{0}'", Global.Globaluserid);
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "SHOWCOL");
                if (ResDS.Tables[0].Rows.Count == 0)
                {
                    Sqlstr = string.Format("INSERT INTO USERSHOWCOL(TNAME0,COLID0,COLCAP,USERID,SHOW00) SELECT TNAME0,COLID0,COLCAP,'{0}',1  FROM SHOWCOL", Global.Globaluserid);
                    Database.GetSqlcom(Sqlstr);
                }
                else
                {
                   
                    
                    //Colcnt = gridView1.Columns.Count;
                    Colcnt = ResDS.Tables[0].Rows.Count;
                    ResDS.Tables[0].PrimaryKey = new DataColumn[] { ResDS.Tables[0].Columns["COLID0"] };
                    //MessageBox.Show(Colcnt.ToString());
                    //Myrow = ResDS.Tables[0].Rows.Find(gridView1.Columns[0].Name);

                    for (int i = 0; i < Colcnt; i++)
                    //for (int i = Colcnt-1; i >= 0; i--)
                    {
                        Myrow = ResDS.Tables[0].Rows.Find(gridView1.Columns[i].Name);
                        //MessageBox.Show(gridView1.Columns[i].Name);
                        
                        if (Myrow != null && Convert.ToInt32(Myrow["SHOW00"]) == 0)
                        {
                            gridView1.Columns[i].Visible = false;
                        }
                        else
                        {
                            gridView1.Columns[i].Visible = true;
                            gridView1.Columns[i].VisibleIndex = i+1;
                        }
                    }
                    

                }

            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
        
        }
    }
}
