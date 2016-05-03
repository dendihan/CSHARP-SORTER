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
    public partial class Formproperedit : Form
    {
        private string Id="", Out="", Proper="", Desc="";
        
        public Formproperedit()
        {
            InitializeComponent();
        }

        public Formproperedit(string Out)
        {
            InitializeComponent();
            this.Out = Out;
        }
        public Formproperedit(string[] Argv)
        {
            InitializeComponent();
            this.Id = Argv[0];
            this.Out = Argv[1];
            this.Proper = Argv[2];
            this.Desc = Argv[3];

            //this.Out = Out;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            string Sqlstr;
            if (this.Id == "")
            {
                //Add propere here
                Sqlstr = string.Format("Insert into OUTPROPER(OUT000,PROPER,DESC00) values('{0}','{1}','{2}')", this.Out, textBox1.Text, textBox2.Text);
                Database.GetSqlcom(Sqlstr);
                Global.RecordLog("添加特征码:" + textBox1.Text);
            }
            else
            {
                //Add propere here
                Sqlstr = string.Format("update OUTPROPER set PROPER='{0}',DESC00='{1}' where ID0000='{2}'", textBox1.Text, textBox2.Text,Id);
                Database.GetSqlcom(Sqlstr);
                Global.RecordLog("编辑特征码:" + textBox1.Text);
            }
            


            this.Close();
        }

        private void Formproperedit_Load(object sender, EventArgs e)
        {
            if (this.Id != "")
            {
                textBox1.Text = Proper;
                textBox2.Text = Desc;
            }
        }
    }
}
