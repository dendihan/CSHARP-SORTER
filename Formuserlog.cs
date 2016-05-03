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
    public partial class Formuserlog : Form
    {
        public Formuserlog()
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

            Sqlstr=string.Format("select * from USERLOG where convert(varchar(10),DATE00,23) between '{0}' and '{1}'",dateTimePicker1.Value.ToString("yyyy-MM-dd"),dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "USERSLOG");
                gridControl1.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }



        }

        private void Formuserlog_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            //dateTimePicker1.Text = DateTime.Now.ToString();
            //dateTimePicker1.Text = DateTime.Now.ToString();
            btnquery_Click(sender,e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
