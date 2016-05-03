using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace yprfj
{
    public partial class Formgetdata : Form
    {
        public Formgetdata()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

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

            Sqlstr = string.Format("select *,(case PSTATE when 0 then '未分拣' when 1 then '已扫描' when 2 then '已分拣' else '已打印' end) PSTATE2 from V_FJDATA where convert(varchar(10),FJDATE,23)='{0}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "V_FJDATA");
                gridControl1.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }



        }

        private void Formgetdata_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            //dateTimePicker2.Value = DateTime.Now;
            //dateTimePicker1.Text = DateTime.Now.ToString();
            //dateTimePicker1.Text = DateTime.Now.ToString();
            btnquery_Click(sender,e);
        }

        private void btnget_Click(object sender, EventArgs e)
        {

            string Sqlstr, bcStr,sdt;
            sdt = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                Sqlstr = "exec pfjdataBackup '" + sdt + "'";
                Database.GetSqlcom(Sqlstr);

            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

            
            //
            XmlDocument doc = new XmlDocument();
            doc.Load(Global.GlobalXMLFile);
            XmlNodeList xnl = doc.SelectNodes("/root/rows/ITEM");
            //XmlNode xn = doc.SelectSingleNode("rows");
            //XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode xn1 in xnl)
            {
                XmlElement xe = (XmlElement)xn1;
                //MessageBox.Show(xe.GetAttribute("BARCODE").ToString());

                bcStr = xe.GetAttribute("BARCODE").ToString();

                Sqlstr = "DECLARE @BCC INT " + "SELECT @BCC=COUNT(BARCODE) FROM FJDATA WHERE BARCODE='" + bcStr + "' " +
 "IF (@BCC=0) " + "BEGIN " +
 "INSERT INTO FJDATA(BARCODE,FJDATE,FROMDATE,FROMNAME,FROMADDR,FROMCO,FROMDETAIL,FROMTEL,FROMZIPCODE," +
"TONAME,TOADDR,TOCO,TODETAIL,TOTEL,TOZIPCODE,PNAME,PNUMBER,PWEIGHT,PLENGTH,PWIDTH,PHEIGHT,PCOST,GUID,PSTATE,POUT) "
+ "VALUES('" + bcStr + "',GETDATE(),'" +xe.GetAttribute("FROMDATE").ToString()  + "'" + ",'" +
 xe.GetAttribute("FROMNAME").ToString() + "'" + ",'" + xe.GetAttribute("FROMADDR").ToString() +
 "'" + ",'" + xe.GetAttribute("FROMCO").ToString() + "'" + ",'" + xe.GetAttribute("FROMDETAIL").ToString()
 + "'" + ",'" + xe.GetAttribute("FROMTEL").ToString() + "'" + ",'" +
 xe.GetAttribute("FROMZIPCODE").ToString() + "'" + ",'" + xe.GetAttribute("TONAME").ToString() +
 "'" + ",'" + xe.GetAttribute("TOADDR").ToString() + "'" + ",'" + xe.GetAttribute("TOCO").ToString()
 + "'" + ",'" + xe.GetAttribute("TODETAIL").ToString() + "'" + ",'" +xe.GetAttribute("TOTEL").ToString()
  + "'" + ",'" + xe.GetAttribute("TOZIPCODE").ToString() + "'" + ",'" +
 xe.GetAttribute("PNAME").ToString() + "'" + ",'" + xe.GetAttribute("PNUMBER").ToString() + "'" + ",'"
 + xe.GetAttribute("PWEIGHT").ToString() + "'" + ",'" + xe.GetAttribute("PLENGTH").ToString()
 + "'" + ",'" + xe.GetAttribute("PWIDTH").ToString() + "'" + ",'" + xe.GetAttribute("PHEIGHT").ToString()
  + "'" + ",'" + xe.GetAttribute("PCOST").ToString() + "'" + ",0,0,''" +"); " + "END";


                try
                {
                    Database.GetSqlcom(Sqlstr);
                   // MessageBox.Show(Sqlstr);
                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                }
            }




          
            Global.RecordLog("获取业务数据");
            btnquery_Click(sender, e);

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
            
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{ }
           
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            string Pstate,O1,O2;
            if (hand >= 0)
            {
                DataRow dr = this.gridView1.GetDataRow(hand);
                if (dr != null)
                {
                    //MessageBox.Show("123");
                    Pstate = dr["PSTATE2"].ToString();
                    O1 = dr["POUT"].ToString();
                    O2 = dr["POUT2"].ToString();

                    if (Pstate == "已分拣")
                    {
                        //MessageBox.Show("123");
                        e.Appearance.BackColor = Color.SkyBlue;
                        e.Appearance.ForeColor = Color.Black;

                    }
                    if (Pstate == "已打印")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.Black;

                    }
                    if (Pstate == "已扫描")
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;

                    }
                    if ((Pstate == "已分拣" || Pstate == "已打印") && (O1 != O2))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                


            }
           

        }

    }
}
