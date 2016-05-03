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
    public partial class Formuseredit : Form
    {
        private string Id = "", Name1 = "", Code = "", Gpname = "", Passwd = ""; 

        public Formuseredit()
        {
            InitializeComponent();
        }

        public Formuseredit(string[] Argv)
        {
            
            //SEQ { Id, Name, Code, Gpname, Passwd }
            InitializeComponent();
            Id = Argv[0];
            Name1 = Argv[1];
            Code = Argv[2];
            Gpname = Argv[3];
            Passwd = Argv[4];
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            string Sqlstr;
            try
            {
                if (Id == "")
                {
                    //Add USER here
                    Sqlstr = string.Format("Insert into USERS(CODE00,NAME00,PASSWD,GROUP0) values('{0}','{1}','{2}',(select CODE00 from USERGROUPS where NAME00='{3}'))", textBox1.Text, textBox2.Text, textBox3.Text,comboBox1.Text);
                    Database.GetSqlcom(Sqlstr);
                    Global.RecordLog("添加用户:" + textBox2.Text);
                }
                else
                {
                    //Edit USER here
                    Sqlstr = string.Format("update USERS set CODE00='{0}',NAME00='{1}',PASSWD='{2}',GROUP0=(select CODE00 from USERGROUPS where NAME00='{3}') where ID0000='{4}'", textBox1.Text, textBox2.Text, textBox3.Text,comboBox1.Text, Id);

                    //MessageBox.Show(Sqlstr);
                    Database.GetSqlcom(Sqlstr);
                    Global.RecordLog("编辑用户:" + textBox2.Text);
                
                }
                
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);

            }
            
            
            this.Close();
        }

        private void Formuseredit_Shown(object sender, EventArgs e)
        {
            string Sqlstr;
            DataSet ResDS;

            
            Sqlstr = string.Format("select NAME00 from USERGROUPS");
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "GPNAME");
                for (int i = 0; i < ResDS.Tables[0].Rows.Count; i++)
                {
                    comboBox1.Items.Add(ResDS.Tables[0].Rows[i]["NAME00"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

                if (Id != "")
                {
                    textBox1.Text = Code;
                    textBox1.SelectAll();
                    //textBox1.SelectionLength
                    textBox2.Text = Name1;
                    textBox3.Text = Passwd;
                    comboBox1.Text = Gpname;
                }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formuseredit_Load(object sender, EventArgs e)
        {

        }
    }
}
