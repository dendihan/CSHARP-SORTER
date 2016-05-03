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
    public partial class Formshowcol : Form
    {
        public Formshowcol()
        {
            InitializeComponent();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formshowcol_Load(object sender, EventArgs e)
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v

            Sqlstr = string.Format("select * from USERSHOWCOL where USERID='{0}'", Global.Globaluserid);
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "SHOWCOL");
                gridControl1.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            int Rowcnt;
            string Sqlstr,Id,Show;
            //Rowcnt=gridView2.
            Rowcnt = gridView2.RowCount;

            for (int i=0; i < Rowcnt; i++)
            {
                Id = gridView2.GetRowCellValue(i, "ID0000").ToString();
                Show = gridView2.GetRowCellValue(i, "SHOW00").ToString();

                Sqlstr=string.Format("update USERSHOWCOL set SHOW00='{0}' where ID0000='{1}'",Show,Id);
                Database.GetSqlcom(Sqlstr);

            }

                
            this.Close();
        }
    }
}
