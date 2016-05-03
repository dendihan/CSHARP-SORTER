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
    public partial class Formparamoutedit : Form
    {

        string Id="";
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
        
        public static void foo()
        {
        
        }
        public Formparamoutedit()
        {
            InitializeComponent();
        }
        public Formparamoutedit(string[] Argv)
        {
            InitializeComponent(); 
            this.Id=Argv[0];
            this.Code = Argv[1];
            this.Type = Argv[2];
            this.Name = Argv[3];
            this.Tarco = Argv[4];
            this.Tarna = Argv[5];
            this.Max = Argv[6];
            this.Ip = Argv[7];
            this.Opcmax = Argv[8];
            this.Opccou = Argv[9];
            this.Opcchg = Argv[10];
            this.Opcbeg = Argv[11];
            this.Opcend = Argv[12];
            this.Opcguid = Argv[13];
            this.State = Argv[14];
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsure_Click(object sender, EventArgs e)            
        {
            string Sqlstr;

            if (Id == "")
            {
                Sqlstr = string.Format("Insert into PARAMOUT(CODE00,TYPE00,NAME00,TARCODE,TARNAME,MAX000,PRINTIP,OPCITEMIDMAX,OPCITEMIDCOU,OPCITEMIDCHG,OPCITEMBEGIN,OPCITEMEND,OPCITEMGUID,STAT00) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13})", textcode.Text, textType.Text, textname.Text, texttarcode.Text, texttarname.Text, textmax.Text, textip.Text, textopcmax.Text, textopccou.Text, textopcchg.Text, textopcbeg.Text, textopcend.Text, textopcguid.Text, checkBox1.Checked ? "1" : "0");

                //MessageBox.Show(Sqlstr);
                Database.GetSqlcom(Sqlstr);

                Global.RecordLog("添加出口:" + textname.Text);
            }
            else
            {
                Sqlstr = string.Format("update PARAMOUT set CODE00='{0}',TYPE00='{1}',NAME00='{2}',TARCODE='{3}',TARNAME='{4}',MAX000='{5}',PRINTIP='{6}',OPCITEMIDMAX='{7}',OPCITEMIDCOU='{8}',OPCITEMIDCHG='{9}',OPCITEMBEGIN='{10}',OPCITEMEND='{11}',OPCITEMGUID='{12}',STAT00='{13}' where ID0000='{14}'", textcode.Text, textType.Text, textname.Text, texttarcode.Text, texttarname.Text, textmax.Text, textip.Text, textopcmax.Text, textopccou.Text, textopcchg.Text, textopcbeg.Text, textopcend.Text, textopcguid.Text, checkBox1.Checked ? "1" : "0", this.Id);

                //MessageBox.Show(Sqlstr);
                Database.GetSqlcom(Sqlstr);

                Global.RecordLog("编辑出口:" + textname.Text);
            }

            

            this.Close();
        }

        private void Formparamoutedit_Load(object sender, EventArgs e)
        {
            if (this.Id != "")
            {
 
                textcode.Text = this.Code;
                textType.Text = this.Type;
                textname.Text = this.Name;
                texttarname.Text = this.Tarna;
                texttarcode.Text = this.Tarco;
                textmax.Text = this.Max;
                textip.Text = this.Ip;
                textopcmax.Text = this.Opcmax;
                textopccou.Text = this.Opccou;
                textopcchg.Text = this.Opcchg;
                textopcbeg.Text = this.Opcbeg;
                textopcend.Text = this.Opcend;
                textopcguid.Text = this.Opcguid;
                checkBox1.Checked = this.State=="1"?true:false;
              
            
            }
        }
    }
}
