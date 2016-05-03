using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace yprfj
{
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("123");
            string Sqlstr,User,Password;
            DataSet ResDS;


            User = comboBox1.Text;
            Password = textPWD.Text;

            if (User == "" || Password == "")
            {
                MessageBox.Show("请输入用户名和密码! ", "提示", MessageBoxButtons.OK);
                return;
            }
            try
            {
                Sqlstr = string.Format("select * from USERS where NAME00='{0}' and PASSWD='{1}'",User,Password);
                ResDS = Database.GetDataset(Sqlstr, "USERS");
                if(ResDS.Tables[0].Rows.Count>0)
                {
                    Formmain.Loginpass=true;
                    this.Close();
                    Global.Globaluser = User;
                    Global.Globaluserid = ResDS.Tables[0].Rows[0]["ID0000"].ToString();
                    Global.Globalgroup = ResDS.Tables[0].Rows[0]["GROUP0"].ToString();
                }
                else
                {
                    Formmain.Loginpass=false;
                    textPWD.Text="";
                    MessageBox.Show("密码错误! ", "提示", MessageBoxButtons.OK);
                }
            }
            catch
            {
                MessageBox.Show("无法连接数据库! ", "提示", MessageBoxButtons.OK);   
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender,e);
            }
        }

        private void Formlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Formmain.Loginpass)
                System.Environment.Exit(0);
            //Application.Exit();
        }

        private void Formlogin_Load(object sender, EventArgs e)
        {
           
            string Sqlstr = "select * from USERS";
            DataSet ResDS;
            int Usercnt;

            
            try
            { 
                ResDS= Database.GetDataset(Sqlstr,"USERS");
                Usercnt = ResDS.Tables["USERS"].Rows.Count;
                for (int i = 0; i < Usercnt-1; i++)
                {
                    comboBox1.Items.Add(ResDS.Tables["USERS"].Rows[i]["NAME00"].ToString());           
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch
            {
                MessageBox.Show("无法获取登录姓名！", "提示", MessageBoxButtons.OK);
            }

            
        }

        private void Formlogin_Shown(object sender, EventArgs e)
        {
            /*
            string Sqlstr = "select * from USERS";
            DataSet ResDS;
            int Usercnt;


            try
            {
                ResDS = Database.GetDataset(Sqlstr, "USERS");
                Usercnt = ResDS.Tables["USERS"].Rows.Count;
                for (int i = 0; i < Usercnt - 1; i++)
                {
                    comboBox1.Items.Add(ResDS.Tables["USERS"].Rows[i]["NAME00"].ToString());
                }
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            catch
            {
                MessageBox.Show("无法获取登录姓名！", "提示", MessageBoxButtons.OK);
            }
             */
            textPWD.Focus();
        }

        private void textPWD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
