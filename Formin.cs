using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;




namespace yprfj
{
    public partial class Formin : Form
    {
        private float scale = 0;
        private int save = 0;
        private int imgh = 0;
        private int imgw = 0;
        private int Havelog=0;
        private int Tc=0, Td=0;
        private int I_overtask = 0;
        private int I_alltask = 0;
        private int Beginflag = 1; //comport begin
        private string I_TcpRec;
        private string AppDir;
        private string I_Guid;
        private string I_Filename;
        private string I_OpcItemID="";
        private bool Nextpic;
        private bool Imgmove=false;        
        private TcpClient tcpClient;
        private Queue<string> I_NoReadGuidQueue;
        private Queue<string> I_FtpRecFileQueue;
        private Thread Threadread;
        private Thread Threadimg;  
        
        
        public Formin()
        {
            InitializeComponent();
        }
        //IMG THREAD here
        private void Imgexec()
        {
            while (!this.IsDisposed)
            {
                Nextpic = false;

                try
                {
                    if (I_NoReadGuidQueue.Count > 0 && I_FtpRecFileQueue.Count > 0)
                    {
                        //GUID
                        Monitor.Enter(I_NoReadGuidQueue);
                        I_Guid = I_NoReadGuidQueue.Dequeue();
                        I_NoReadGuidQueue.TrimExcess();
                        Monitor.Exit(I_NoReadGuidQueue);
                        //FILE NAME
                        Monitor.Enter(I_FtpRecFileQueue);
                        I_Filename = I_FtpRecFileQueue.Dequeue();
                        I_FtpRecFileQueue.TrimExcess();
                        Monitor.Exit(I_FtpRecFileQueue);
                        Thread.Sleep(800);

                        RefreshImg();
                        for (int i = 0; i < 6; i++)
                        {
                            if (Nextpic)
                                break;
                            Thread.Sleep(500);   
                        }

                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
                catch(Exception ex)
                {
                    Global.ErrorLog("入口队列处理异常： " + ex.Message);
                    Monitor.Exit(I_NoReadGuidQueue);
                    Monitor.Exit(I_FtpRecFileQueue);
                    
                }
            
            
            
            }
        
        
        }
        //display img for barcode picture
        private void RefreshImg()
        {
            try
            {
                pictureBox1.Image = Image.FromFile(I_Filename);
                statusStrip1.Items[3].Text = "载入图片： " + I_Filename;
                panel2.Dock = DockStyle.Fill;
                pictureBox1.Dock = DockStyle.Fill;
                Imgmove = false;
            
            
            }
            catch(Exception ex)
            {

                statusStrip1.Items[3].Text = "载入图片异常： " + ex.Message;
                Global.ErrorLog("载入图片异常： " + ex.Message);  
 
                

            
            }
        
        }


        // TCPclient read below
        private void Tcpexec()
        {

            while(!this.IsDisposed)
            {
                //MessageBox.Show("123");
                //Tcpconnect();
                
                try
                {
                    if (tcpClient==null || !tcpClient.Connected || (tcpClient.Client.Poll(20, SelectMode.SelectRead) && (tcpClient.Client.Available == 0)))
                    {

                        Thread.Sleep(10000);
                        Tcpconnect();
                        

                    }
                    else
                    {

                        Thread.Sleep(100);
                        Tcpread();
                        
                    }
                    //MessageBox.Show(tcpClient.Available.ToString());
                }
                catch
                { }
                

            } 
        }
        //connect
        private void Tcpconnect()
        {

            try
            {
                //Application.DoEvents();
               // if (!tcpClient.Connected)
               // {
                    //MessageBox.Show("123");
                    Application.DoEvents();
                    tcpClient = new TcpClient();
                    tcpClient.Connect(Global.GlobalCtrlIP, Global.GlobalPort);
                    
                    //tcpClient.Connect("127.0.0.1", 8888);
                    statusStrip1.Items[1].Text = "SOCKET 已连接";
    
               // }


            }
            catch(Exception ex)
            {
                Tc++;
                if (Tc > 99)
                    Tc = 1;
                //IAsyncResult asyncresult = new IAsyncResult();
                tcpClient.Close();
                tcpClient = null;
                statusStrip1.Items[1].Text = "SOCKET 连接...("+Tc.ToString()+")";
                if (Havelog == 0)
                {
                    Havelog = 1;
                    Global.ErrorLog("Socket 服务器连接异常： "+ex.Message);
                  
                }
            }

        }
        //~~~~~~~~~~~~~~~~~~~~~~read function~~~~~~~~~~~~~~~~~~
        private void Tcpread()
        {

            string Msg, Tmpstr;
            int P1, P2;


            try
            {
                NetworkStream Stream = tcpClient.GetStream();
                if(Stream.DataAvailable)
                {
                    byte[] bytes = new Byte[1024];
                    int Length = Stream.Read(bytes, 0, bytes.Length);
                    if (Length > 0)
                    {
                        I_TcpRec = Encoding.Default.GetString(bytes, 0, Length);
                       
                    }
                
                }         
            }
            catch (Exception ex)
            {
                statusStrip1.Items[2].Text = ex.Message;

            }

            if (I_TcpRec != "")
            {
                //MessageBox.Show(I_TcpRec);
                Td++;
                if (Td > 99)
                    Td = 1;
                statusStrip1.Items[0].Text = Td.ToString();
                try
                {
                    P1 = I_TcpRec.IndexOf("[STX]");
                    P2 = I_TcpRec.IndexOf("[ETX]");

                    if ((P1 >= 0) && ((P2 - P1) > 5))
                    {
                        Msg = I_TcpRec.Substring(P1 + 5, P2 - P1 - 5);
                        
                        if (Msg.ToUpper().StartsWith("NR:"))
                        {
                            Tmpstr = Msg.Substring(3,Msg.Length-3);
                            try 
                            {
                                Monitor.Enter(I_NoReadGuidQueue);
                                I_NoReadGuidQueue.Enqueue(Tmpstr);
                                I_NoReadGuidQueue.TrimExcess();
                                statusStrip1.Items[2].Text =
                                "[STX]" + Msg + "[ETX]" + "(" + I_NoReadGuidQueue.Count.ToString() + ")" + " ,I_Guid=" + I_NoReadGuidQueue.Peek();


                            }
                            finally
                            {
                                Monitor.Exit(I_NoReadGuidQueue);
                            }
                        
                        }
                        
                    }
                
                }
                catch(Exception ex)
                {
                    Global.ErrorLog("入口接收数据处理异常： " + ex.Message);    
                
                }

            
            }
            I_TcpRec = "";


        }

        private void Formin_Load(object sender, EventArgs e)
        {
            Imgmove = false;

            Havelog = 0;
            I_overtask = 0;
            I_alltask = 0;
            Td = 0;
            I_Guid = "";
            Tc = 0;

            
            /*
            if (!tcpClient.Connected)
            {
                MessageBox.Show("123");
            }
             */
            Tcpconnect();
            //Control.CheckForIllegalCrossThreadCalls = false;
            I_NoReadGuidQueue = new Queue<string>();
            I_FtpRecFileQueue = new Queue<string>();
            Threadread = new Thread(this.Tcpexec);
            //Thread Threadread = new Thread(this.Tcpconnect);
            Threadread.Start();  // 只要使用Start方法，线程才会运行 

            Threadimg = new Thread(this.Imgexec);
            Threadimg.Start();
            

            //SQL 
            Properquery();
            I_OpcItemID=WritePLCquery(Global.GloballocalIP);



            //comport open
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
                serialPort1.Open();
            }
            catch
            { 
            
            
            }

           
            //Control.CheckForIllegalCrossThreadCalls = false;
            //serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {

            this.Close();
            //this.Close();
            //this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Properquery()
        {
            string Sqlstr;
            DataSet ResDS;
            //MessageBox.Show(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //dateTimePicker1.Value
            //dateTimePicker1.v


            //select  PROPER
            Sqlstr = string.Format("select * from OUTPROPER");
            //MessageBox.Show(Sqlstr);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "PROPER");
                gridControl1.DataSource = ResDS.Tables[0];
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }

       }

        private string WritePLCquery(string Gloip)
        {
            string Sqlstr;
            DataSet ResDS;

            Sqlstr = string.Format("SELECT WRITEPLC FROM PARAMIN WHERE IPADDR='{0}'", Gloip);
            try
            {
                ResDS = Database.GetDataset(Sqlstr, "WRITEPLC");
                //gridControl1.DataSource = ResDS.Tables[0];
                if (ResDS.Tables[0].Rows.Count > 0)
                {
                    return ResDS.Tables[0].Rows[0]["WRITEPLC"].ToString();
                
                }
            }
            catch
            {
                MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
            }
                return "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int C=0, R=0;
            string Sqlstr;
            DataSet ResDS;

            Sqlstr = "select cou1,cou2 from (SELECT '1' id,count(BARCODE) cou1 FROM FJDATA where PSTATE>1) a,(SELECT '1' id,count(BARCODE) cou2 FROM FJDATA) b where a.id=b.id";
            ResDS = Database.GetDataset(Sqlstr, "PROPER");
            //gridControl1.DataSource = ResDS.Tables[0];
            try
            {
                if (ResDS.Tables[0].Rows.Count > 0)
                {
                    C = Convert.ToInt32(ResDS.Tables[0].Rows[0]["cou1"]);
                    if (C != I_overtask)
                    {
                        I_overtask = C;
                        R = 1;
                    }

                    C = Convert.ToInt32(ResDS.Tables[0].Rows[0]["cou2"]);
                    if (C != I_alltask)
                    {
                        I_alltask = C;
                        R = 2;
                    }

                    if (R != 0)
                    {
                        this.labeltask.Text = I_overtask.ToString() + @"/" + I_alltask.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                Global.ErrorLog("入口页面显示异常： " + ex.Message);
            }
            
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            string tmp;
            string outcode;
            outcode = textout.Text.Trim();
            if (I_Guid != "" && outcode != "")
            { 
                tmp = "[STX]BM:" + I_Guid + "," + outcode + "[ETX]";
                if (tcpClient != null && tcpClient.Connected)
                {
                    try
                    { 
                        //send message here
                        Byte[] bSend = Encoding.ASCII.GetBytes(tmp);
                        tcpClient.Client.Send(bSend, bSend.Length, 0);


                        Nextpic = true;
                        I_Guid = "";
                        I_Filename = "";
                        textbarcode.Text = "";
                        textout.Text = "";
                        statusStrip1.Items[0].Text = "发送：" + tmp;
                    }
                    catch(Exception ex)
                    { 
                        statusStrip1.Items[1].Text = "发送异常：" + ex.Message;    
                    }

                }
                else
                {
                    MessageBox.Show("未接到服务器端", "提示", MessageBoxButtons.OK);    
                    return;
                }
            
            
            }
            else
            {
                if (outcode == "")
                {
                    MessageBox.Show("请输入出口 ", "提示", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("未接到服务端出口请求", "提示", MessageBoxButtons.OK);
                }
            }
            textbarcode.Focus();

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //

            if (serialPort1.IsOpen)
            {
                try
                {
                    if (this.Beginflag == 1)
                    {
                        textbarcode.Text = "";
                    }
                    
                    string strRec = serialPort1.ReadExisting();
                    if (strRec.EndsWith("\r"))
                    {
                        this.Beginflag = 1;
                    }
                    textbarcode.Text += strRec;
                }
                catch
                { 
                
                //
                }
            
            }

        }

        private void Formin_FormClosed(object sender, FormClosedEventArgs e)
        {


            //close thread
            //Threadread.Abort();
            //Threadimg.Abort();

            //close TCP 

            if (tcpClient != null)
            {
                tcpClient.Close();
                
            }


            //close comport
            if (serialPort1.IsOpen)
                serialPort1.Close();

            //this.Close();
            this.Dispose();
        }

        private void textout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnsure_Click(sender, e);

        }

        private void textbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string s;
            string sqlstr;
            string outcode="";
            string tmp;
            DataSet ResDS;
            
            if (e.KeyChar == '\r')
            {
                s = textbarcode.Text.Trim();
                e.KeyChar = '\0';


                sqlstr = string.Format("SELECT POUT FROM FJDATA WHERE BARCODE='{0}'",s);
                //MessageBox.Show(Sqlstr);
                try
                {
                    ResDS = Database.GetDataset(sqlstr, "PROPER");
                    if (ResDS.Tables[0].Rows.Count > 0)
                        outcode = ResDS.Tables[0].Rows[0]["POUT"].ToString();
                    if (outcode == "" || outcode == "0")
                    {
                        MessageBox.Show("没找到分配出口 ", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        textout.Text = outcode;
                        if (I_Guid == "")
                        { 
                            tmp = "[STX]BC:" + I_OpcItemID + "," + s + "[ETX]";
                        }
                        else
                        { 
                            tmp = "[STX]BM:" + I_Guid + "," + outcode + "[ETX]";
                        }
                    }

                    if (tcpClient != null && tcpClient.Connected)
                    {
                        try
                        {
                            //send message here
                            Byte[] bSend = Encoding.ASCII.GetBytes(tmp);
                            tcpClient.Client.Send(bSend, bSend.Length, 0);


                            Nextpic = true;
                            I_Guid = "";
                            I_Filename = "";
                            textbarcode.Text = "";
                            statusStrip1.Items[0].Text = "发送：" + tmp;
                        }
                        catch (Exception ex)
                        {
                            statusStrip1.Items[1].Text = "发送异常：" + ex.Message;
                        }

                    }
                    else
                    {
                        MessageBox.Show("未接到服务器端", "提示", MessageBoxButtons.OK);
                        return;
                    }
            

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器！", "提示", MessageBoxButtons.OK);
                }


            
            
            
            }
        }

        private void Formin_Shown(object sender, EventArgs e)
        {
            textbarcode.Focus();
        }
    }
}
