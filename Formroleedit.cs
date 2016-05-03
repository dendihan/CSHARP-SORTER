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
    public partial class Formroleedit : Form
    {
        private string Id = "", Name = "", Code = "", Remark = ""; 

        public Formroleedit()
        {
            InitializeComponent();
        }

        public Formroleedit(string[] Argv)
        {
            InitializeComponent();
            Id = Argv[0];
            Name = Argv[1];
            Code = Argv[2];
            Remark = Argv[3];
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
                    //Add ROLE here
                    Sqlstr = string.Format("Insert into USERGROUPS(CODE00,NAME00,REMARK) values('{0}','{1}','{2}')", textBox1.Text, textBox2.Text, textBox3.Text);
                    Database.GetSqlcom(Sqlstr);
                    Global.RecordLog("添加角色:" + textBox2.Text);
                }
                else
                {
                    //Edit ROLE here
                    Sqlstr = string.Format("update USERGROUPS set CODE00='{0}',NAME00='{1}',REMARK='{2}' where ID0000='{3}'", textBox1.Text, textBox2.Text, textBox3.Text,Id);
                    Database.GetSqlcom(Sqlstr);
                    Global.RecordLog("编辑角色:" + textBox2.Text);
                
                }
                
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);

            }
            
            
            this.Close();
        }

        private void Formroleedit_Shown(object sender, EventArgs e)
        {
            if (Id != "")
            {
                textBox1.Text = Code;
                textBox1.SelectAll(); 
                //textBox1.SelectionLength
                textBox2.Text = Name;
                textBox3.Text = Remark;
            }
        }
    }
}
