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
    public partial class Formmain : Form
    {
        //private string Sqlstr; 
        //public var create here
        public static Boolean Loginpass=false;
        //form
        public static Formdatacompute frmdatacompute;
        public static Formrole frmrole;
        public static Formuser frmuser;
        public static Formuserlog frmuserlog;
        public static Formerrorlog frmerrorlog;
        public static Formgetdata frmgetdata;
        public static Formout frmout;
        public static Formpermission frmpermission;
        public static Formproper frmproper;
        public static Formparam frmparam;
        public static Formin frmin;
        public static Formmonitor frmmonitor;



        public Formmain()
        {
            
            InitializeComponent();
            //this.Visible = false;
            
            
        }

        private void EnableAction()
        {
            string Sqlstr;
            DataSet ResDS;
            DataRow Myrow;

            try
            {
                Sqlstr = string.Format("select * from GROUPACT where CODE00='{0}'", Global.Globalgroup);
                ResDS = Database.GetDataset(Sqlstr, "ACTION");
                ResDS.Tables[0].PrimaryKey = new DataColumn[]{ResDS.Tables[0].Columns["ACTNAME"]};
                //Myrow = ResDS.Tables[0].Rows.Find("ActMonitor");
                //MessageBox.Show(Myrow["CHOOSE"].ToString());

                
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    ToolStripDropDownItem newmenu = (ToolStripDropDownItem)menuStrip1.Items[i];
                    if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                    {
                        for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                        {

                            if (newmenu.DropDownItems[j].GetType().Name != "ToolStripSeparator")
                            {
                                newmenu.DropDownItems[j].Enabled = false;
                                Myrow = ResDS.Tables[0].Rows.Find(newmenu.DropDownItems[j].Name);
                                //MessageBox.Show(Myrow["CHOOSE"].ToString());
                                //if(Myrow != null&&Convert.ToInt32(Myrow["CHOOSE"]) == 1)
                                //{}
                             

                              //  try
                              //  {
                                    //MessageBox.Show(Myrow["CHOOSE"].ToString());
                                   // if (Myrow["CHOOSE"].ToString() == "1")
                                    if (Myrow != null && Convert.ToInt32(Myrow["CHOOSE"]) == 1)
                                    {
                                        //MessageBox.Show("123");
                                        newmenu.DropDownItems[j].Enabled = true;

                                    }
                               // }
                               // catch
                               // { 
                                    //
                               // }
                                

                            }

                        }
                    }
                 
                }
                //toolbar enable
                if (ActGetData.Enabled == false)
                    toolStripButton1.Enabled = false;
                if (ActMonitor.Enabled == false)
                    toolStripButton2.Enabled = false;
                if (ActIn.Enabled == false)
                    toolStripButton3.Enabled = false;
                if (ActOut.Enabled == false)
                    toolStripButton4.Enabled = false;
                if (ActQuery.Enabled == false)
                    toolStripButton5.Enabled = false;
                
            }
                
            catch
            {
                MessageBox.Show("无法连接数据库! ", "提示", MessageBoxButtons.OK);
            }

            
        }
        private void 数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Frommain_Load(object sender, EventArgs e)
        {
            string Sqlstr;
            //image for tool bar
            toolStrip1.ImageList = imageList1;
            toolStripButton1.ImageIndex = 0;
            toolStripButton2.ImageIndex = 1;
            toolStripButton3.ImageIndex = 2;
            toolStripButton4.ImageIndex = 3;
            toolStripButton5.ImageIndex = 4;

            //image for menubar
            int imgcnt=0;
            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                ToolStripDropDownItem newmenu= (ToolStripDropDownItem)menuStrip1.Items[i];
                if (newmenu.HasDropDownItems && newmenu.DropDownItems.Count > 0)
                {
                    for (int j = 0; j < newmenu.DropDownItems.Count; j++)
                    {
                                            
                        if (newmenu.DropDownItems[j].GetType().Name != "ToolStripSeparator")
                        {
                            newmenu.DropDownItems[j].Image = imageList1.Images[imgcnt];
                            if (imgcnt < imageList1.Images.Count-1)
                            {
                                imgcnt++;   
                            }
                        
                        }
                       
                    }
                }
            }
           
            
            Global.GloballocalIP = Global.GetLocalIp();
           // MessageBox.Show(Global.GloballocalIP);//for test
            Database.M_str_sqlcon = Database.GetConStr();
           // MessageBox.Show(Database.M_str_sqlcon);

            this.Hide();
            Formlogin Frmlogin = new Formlogin();
            Frmlogin.ShowDialog();            
            Frmlogin.Dispose();
            this.WindowState = FormWindowState.Maximized;
            this.Show();

            if (Loginpass)
            //if (true)
            { 
                EnableAction();
                Global.RecordLog("用户登录");
                statusStrip1.Items[1].Text = Global.GloballocalIP;
                statusStrip1.Items[3].Text = Global.Globaluser;
                statusStrip1.Items[5].Text = DateTime.Now.ToString();
                Sqlstr = "select * from PARAMETER";

                try
                {
                    SqlDataReader TemDR = Database.GetCom(Sqlstr);

                    if (TemDR.Read())
                    {
                        Global.GlobalCtrlIP = TemDR["CTRLIP"].ToString();
                        Global.GlobalPort = (int)TemDR["PORT00"];
                        Global.GlobalScanIP = TemDR["BARCODEIP"].ToString();
                        Global.GlobalScanPort = (int)TemDR["BARCODEPORT"];
                        Global.GlobalPrint_origin = TemDR["ADDRESS"].ToString();

                        
                    }
                    TemDR.Close();
                    TemDR.Dispose();
                    //MessageBox.Show(Global.GlobalCtrlIP);
                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                }

                Database.ConClose();

            }

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Global.RecordLog("用户退出");
            
            /*
            1.this.Close();   只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；

            2.Application.Exit();  强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；

            3.Application.ExitThread(); 强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；

            4.System.Environment.Exit(0);   这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。 
            */
            Application.Exit();
        }

        private void 维护指引ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.RecordLog("查看维护指引");
            try
            {
                System.Diagnostics.Process.Start("智能自动化分拣信息系统使用说明书.chm");
            }
            catch
            {
                MessageBox.Show("无法打开帮助文档，文件正在被使用！","提示", MessageBoxButtons.OK);
            }
            
        }

        private void 数据统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 统计查询 页面");
            Global.OpenForm<Formdatacompute>(ref frmdatacompute,this);
        }

        private void ActEvent_Click(object sender, EventArgs e)
        {
            Global.RecordLog("查看事件日志");
            Global.OpenForm<Formuserlog>(ref frmuserlog, this);
        }

        private void ActAlert_Click(object sender, EventArgs e)
        {
            Global.RecordLog("查看报警信息");
            Global.OpenForm<Formerrorlog>(ref frmerrorlog, this);
        }

        private void ActGetData_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 数据获取 页面");
            Global.OpenForm<Formgetdata>(ref frmgetdata, this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ActGetData_Click(sender, e);
        }

        private void ActRole_Click(object sender, EventArgs e)
        {
           //角色管理
            Global.RecordLog("打开 角色管理 页面");
            Global.OpenForm<Formrole>(ref frmrole, this);
        }

        private void ActUser_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 用户管理 页面");
            Global.OpenForm<Formuser>(ref frmuser, this);
        }

        private void ActPermission_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 权限管理 页面");
            Global.OpenForm<Formpermission>(ref frmpermission, this);
            //Global.OpenForm<Formout>(ref frmpermission, this);
        }

        private void ActProper_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 出口特征 页面");
            Global.OpenForm<Formproper>(ref frmproper, this);    
        }

        private void ActParam_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 参数设置 页面");
            Global.OpenForm<Formparam>(ref frmparam, this); 
        }

        private void ActOut_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 出口管理 页面");
            Global.OpenForm<Formout>(ref frmout, this); 
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ActIn_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 入口操作 页面");
            Global.OpenForm<Formin>(ref frmin, this);
        }

        private void ActMonitor_Click(object sender, EventArgs e)
        {
            Global.RecordLog("打开 分拣监控 页面");
            Global.OpenForm<Formmonitor>(ref frmmonitor, this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ActMonitor_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ActIn_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ActOut_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            数据统计ToolStripMenuItem_Click(sender, e);
        }





  
    }
}
