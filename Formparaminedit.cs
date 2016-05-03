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
    public partial class Formparaminedit : Form
    {
        private string Id="", Code, Ip, Write, Read, Attr;
        public Formparaminedit()
        {
            InitializeComponent();
        }

    

        public Formparaminedit(string[] Agrv)
        {
            InitializeComponent();
            this.Id = Agrv[0];
            this.Code = Agrv[1];
            this.Ip = Agrv[2];
            this.Write = Agrv[3];
            this.Read = Agrv[4];
            this.Attr = Agrv[5];

        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            String Sqlstr;

            if (Id == "")
            {
                Sqlstr = string.Format("Insert into PARAMIN(CODE00,IPADDR,READPLC,WRITEPLC,ATTR00) values('{0}','{1}','{2}','{3}','{4}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked ? "1" : "0");

                //MessageBox.Show(Sqlstr);
                Database.GetSqlcom(Sqlstr);
                Global.RecordLog("添加入口:" + textBox1.Text);
            }
            else
            {
                Sqlstr = string.Format("update PARAMIN set CODE00='{0}',IPADDR='{1}',READPLC='{2}',WRITEPLC='{3}',ATTR00='{4}'where ID0000='{5}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked ? "1" : "0",this.Id);

                //MessageBox.Show(Sqlstr);
                Database.GetSqlcom(Sqlstr);
                Global.RecordLog("编辑入口:" + textBox1.Text);
            
            }

            




            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formparaminedit_Load(object sender, EventArgs e)
        {
            if (Id != "") 
            { 
                textBox1.Text=this.Code;
                textBox2.Text = this.Ip;
                textBox3.Text = this.Read;
                textBox4.Text = this.Write;
                checkBox1.Checked = this.Attr == "1" ? true : false;
            
            }
        }
    }
}
