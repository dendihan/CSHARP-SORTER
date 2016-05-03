using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using OPCAutomation;
using System.Threading;
//using yprfj.AsyncTcpServer;

namespace yprfj
{
    public partial class Formmonitor : Form
    {
        const int c_carHeight = 45; // 小车高度
        const int c_arc = 8; // 半弧形 小车个数
        const int c_gap = 5; // 小车间隙
        const int c_InHeight = 45; // 入口高度
        const int c_InGap = 5; // 入口间隙
        const int c_OutHeight = 45; // 出口高度
        const int c_OutGap = 5; // 出口间隙
        const string PLCProgID = "KEPware.KEPServerEx.V4";
  

        string Scanreadstr="";
        int c_carWidth=35;//小车宽度
        int M_DevInit = 0; // 设备初始化参数是否已下传 1 是 0 否
        int M_Cars = 64;
        int M_MaxRound; // 主线最大转圈数
        string PLCNode; // PLC IP 地址
        int M_InNum = 2; // 入口个数
        int M_OunNum_usual = 8; // 正常出口个数
        int M_OunNum_unusual = 2; // 异常出口个数

        Panel[] M_Carry;// 小车
        Panel[] M_In;// 入口
        Panel[] M_Out;// 出口
        Label[] M_Carry_Lab1;// 小车标签
        Label[] M_Carry_Lab2;// 小车标签
        Label[] M_Carry_Lab_in;// 小车标签
        Label[] M_Carry_Lab_out1;// 小车标签
        Label[] M_Carry_Lab_out2;// 小车标签
        Label[] M_Out_Lab;// 出口标签

        TCarPosi[] M_CarPosi; // 位置信息
        TOuter[] M_Outer;// 出口信息
        TInner[] M_Inner;// 入口信息
        string[] M_Errors;// plc 报警
        Array M_InnerIP;// 入口 IP

        int M_Online;// 设备运行状态
        string M_DevState;// 设备运行状态

        int M_CurCarID;//光电检测后小车编号
        int M_CurGuid; //光电检测后唯一码
        int M_CurOuter;// 光电检测后小车物件对应出口

        int l2top;
        int l2left;
        int top0;
        int left0; 
        int R_rate;
        Queue<TPrint> M_PrintQueue;// 打印队列

        //OPC below
        OPCServer OPCServer1;
        IOPCGroups ObjOPCGroups;
        OPCGroup OPCGroupErrBegin;
        OPCGroup OPCGroupMain;
        OPCGroup OPCGCarEnter;
        OPCGroup OPCGroupWrite;
        OPCItems MainOPCItems;
        OPCItems CarEnterOPCItems;
        OPCItems CarLeaveOPCItems;
        OPCItems ErrBeginOPCItems;
        OPCItems WriteOPCItems;

        string OPCITEMID_CARENTER;// 主线小车进入光电开关
        string OPCITEMID_CARLEAVE;// 主线小车离开光电开关
        string OPCITEMID_CURCARID;// 主线光电位置当前小车编号
        string OPCITEMID_CURGUID;// 主线光电位置当前唯一编号
        string OPCITEMID_CUROUTER;// 主线光电位置当前唯一编号
        string OPCITEMID_ONLINE;// PLC 在线
        string OPCITEMID_PLCRUN1;// PLC 运行状态 正常
        string OPCITEMID_PLCRUN2;// PLC 运行状态 急停
        string OPCITEMID_PLCRUN3;// PLC 运行状态 异常
        string OPCITEMID_WRITEHEART;// 心跳写入
        string OPCITEMID_WRITEROUNDMAX; // 转圈最大数
        string OPCITEMID_WRITEGUID;// 主线扫码件唯一码
        string OPCITEMID_WRITEOUTID; // 主线扫码件出口编号
        string OPCITEMID_ERRBEGIN;// 可以开始读取报警信息
        string OPCITEMID_ERREND;// 报警信息读取完成

        AsyncTcpServer Tcpserver;
        TcpClient Scaner;
        Thread Threadscan;
        Thread ThreadPLC;
        //DataSet DSopc;



        /*
        private class TCarPosi
        {

            int POSIID;
            int GUID00;
            int CARID;
            int OUTID;
            string OUTCode;
            string OPCCARID;
            string OPCOUTID;
            string OPCGUID;
               
        }
         */
        // mainline
        private class TCarPosi
        {

            public int POSIID;// 位置编号 1 - 64
            public int GUID00;// 从 PLC 读取的唯一码
            public int CARID;// 小车编号
            public int OUTID;//出口编号
            public string OUTCode;//出口代码
            public string OPCCARID;// OPC ITEM ID
            public string OPCOUTID;// OPC ITEM ID
            public string OPCGUID;// OPC ITEM ID

        }
       //out  
        private class TOuter
        {

            public int AutoID;
            public int MAX000;
            public int COUNT0;
            //string OUTCode;
            public string CODE00;
            public string TARCODE;
            public string TARNAME;
            //string TARCODE;
            public string OPCMAX;
            public string OPCCOU;
            public string OPCCHG;
            public string OPCOUTBEGIN;
            public string OPCOUTEND;
            public string OPCOUTGUID;
            public string PRINTIP;

        }

        //in
        private class TInner
        {

            public int AutoID;// 自动编号
            public int ATTR00;      // 属性  
            public string CODE00;  // 代码
            public string IPADDR;  // ip 地址
            public string READPLC; // OPC 读 item id
            public string WRITEPLC;// OPC 写 ITEM ID

        }
        //print
        private class TPrint
        {

            public int Cou;       // 包含货件量
            public string OUTCode;// 出口编号
            public string TARCODE;// 目的地代码
            public string TARNAME;// 目的地名称
            public string BarCode;// 条码

        }


        public Formmonitor()
        {
            InitializeComponent();
        }

       
        //------------------common function below---------------------

        public void WriteMemo(string memo)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Action<string> actionDelegate = (x) => { this.richTextBox1.Text = this.richTextBox1.Text.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + x.Trim() + "\r");};
                //this.richTextBox1
                this.richTextBox1.Invoke(actionDelegate, memo);

            }
            else
            {
                //listBox1.Items.Add(e.TcpClient.Client.RemoteEndPoint.ToString());
                this.richTextBox1.Text = this.richTextBox1.Text.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + memo.Trim() + "\r");
            }
            
        
        }

       
        private void BarCodeNoReadNotifyInner()
        {
            // 没接收到条码， 发信息到入口计算机 [STX]NR:GUID[ETX]

            try
            {
                if (Tcpserver != null)
                    Tcpserver.SendToAll("[STX]NR:" + Global.GlobalIndex + "[ETX]"+"\n");
               // MessageBox.Show(Global.GlobalIndex);
            }
            finally
            {
                Global.GlobalIndex = "0";
            
            }
        }
        

        private void PrintLabel()
        {
            string ZPLCode, printer;
            //int i;
            try
            {
                Global.GlobalPrint_ip = "";

                for (int i = 0; i < M_Outer.Length; i++)
                {
                    if (M_Outer[i].CODE00 == Global.GlobalPrint_out)
                    {
                        Global.GlobalPrint_ip = M_Outer[i].PRINTIP;
                    }
                
                }
                printer = @"\\" + Global.GlobalPrint_ip + @"\" + Global.GlobalPrint_name;
                ZPLCode = Global.MakeZPLCode(Global.GlobalPrint_barcode, Global.GlobalPrint_dest, Global.GlobalPrint_pcs, Global.GlobalPrint_origin);
                Global.WriteRawStringToPrinter(printer, ZPLCode);
                WriteMemo("补打出口包装袋标签：" + Global.GlobalPrint_barcode);
                Global.RecordLog("补打出口包装袋标签：" + Global.GlobalPrint_barcode);


            }
            catch(Exception ex)
            {
                MessageBox.Show("打印错误："+ex.Message, "提示", MessageBoxButtons.OK);
            }
        
        }

        private void OutPrintUpdate(string OUTCode, string LabBarCode)
        {
            string sqlstr;

            sqlstr = string.Format("UPDATE FJDATA SET PSTATE=3,LabBarCode='{0}' WHERE PSTATE=2 and isnull(LabBarCode,'')='' AND POUT2='{1}'", LabBarCode, OUTCode);
            try
            {
                Database.GetSqlcom(sqlstr);
            }
            catch(Exception ex)
            {
                WriteMemo("OutPrintUpdate 异常： " + ex.Message);
            }
        
        }

        private string GetMaxSeq(string OUTCode)
        {
            string r, sqlstr;
            DataSet ResDS;

            try
            {
                sqlstr = string.Format("SELECT MAX(RIGHT(LABBARCODE,4))+1 MAXSEQ FROM FJDATA WHERE POUT2='{0}'",OUTCode);
                ResDS = Database.GetDataset(sqlstr, "MAX");
                if (ResDS.Tables[0].Rows.Count == 0 || ResDS.Tables[0].Rows[0]["MAXSEQ"].ToString()=="")
                {
                    r = "0001";
                
                }
                else
                {
                    r = ResDS.Tables[0].Rows[0]["MAXSEQ"].ToString();

                    while (r.Length < 4)
                    {
                        r = "0" + r;
                    
                    }
                                
                }
   
            }
            catch(Exception ex)
            { 
                WriteMemo("GetMaxSeq 异常： " + ex.Message);
                r = "";
            }

            return r;
            
        }

        private string GetPcs(string OUTCode)
        {
            string sqlstr, r;
            DataSet ResDS;
            try
            {
                sqlstr = string.Format("SELECT COUNT(BARCODE) COU FROM FJDATA WHERE PSTATE=2 AND ISNULL(LabBarCode,'')='' AND POUT2='{0}'", OUTCode);
                ResDS = Database.GetDataset(sqlstr, "COU");
                r = ResDS.Tables[0].Rows[0]["COU"].ToString();

                while (r.Length < 3)
                {
                    r = "0" + r;
                    
                }
                                
                
   
            }
            catch(Exception ex)
            { 
                WriteMemo("GetPcs 异常： " + ex.Message);
                r = "";
            }

            return r;
        
        }
        private string findopcitem(string itemid, DataSet DSopc) //Use to find OPC ITEMS ID
        {
            string r = "";
            DataRow Myrow;

            if (DSopc != null && DSopc.Tables[0].Rows.Count > 0)
            {
                DSopc.Tables[0].PrimaryKey = new DataColumn[] { DSopc.Tables[0].Columns["NAME00"] };
                Myrow = DSopc.Tables[0].Rows.Find(itemid);
                if (Myrow != null)
                {
                    r = Myrow["ITEMID"].ToString();

                }
         
            }


            return r;
        }

        private void OutUpdate(int guid, string OUTCode)
        {
            string sqlstr;
            try
            {
                sqlstr = string.Format("UPDATE FJDATA SET PSTATE=2,POUT2='{0}' WHERE PSTATE=1 AND GUID={1}", OUTCode, guid.ToString());
                Database.GetSqlcom(sqlstr);
            }
            catch(Exception ex) 
            { 
                WriteMemo("OutUpdate 异常： " + ex.Message);
            
            }

        }


        //------------------common function end-----------------------


        //---------------------opc relate below---------------
        private object MainItemRead(string itemid)
        {
            object myValue = 0, myQuality, myTimeStamp;
            //string a;
            //int b;
            
            //MainOPCItems.Item(itemid).Read(1, myValue, myQuality, myTimeStamp);
            try
            {
                MainOPCItems.Item(itemid).Read(1, out myValue, out myQuality, out myTimeStamp);

                if (myValue.ToString() == "true" )
                {
                    myValue = 1;
                }
                if (myValue.ToString() == "false")
                {
                    myValue = 0;
                }

                
            
            }
            catch(Exception ex)
            { 
                WriteMemo("读 PLC " + itemid + " 异常: " + ex.Message);
            }

            return myValue;
            
        }

        private void PLCMainItemWrite(string itemid, object val)
        {
            try
            {
                MainOPCItems.Item(itemid).Write(val);
            }
            catch(Exception ex)
            {
                WriteMemo("PLCMainItemWrite 异常： (" + itemid + ")" + ex.Message);
            }
        
        }

        private void PLCItemWrite(string itemid, object val)
        {

            //WriteOPCItems.Item(itemid).Write(val);
            try
            {
                WriteOPCItems.Item(itemid).Write(val);
            }
            catch (Exception ex)
            {
                WriteMemo("PLCItemWrite 异常： (" + itemid + ")" + ex.Message);
            }

        }

        // wirte PLC heart
        private void WriteHeart1()
        {
            try
            {
                PLCItemWrite(OPCITEMID_WRITEHEART, 1);
            }
            catch (Exception ex)
            {
                WriteMemo("WriteHeart1 异常： " + ex.Message);
            }  
        
        }

        // wirte PLC heart
        private void WriteHeart0()
        {
            try
            {
                PLCItemWrite(OPCITEMID_WRITEHEART, 0);
            }
            catch (Exception ex)
            {
                WriteMemo("WriteHeart0 异常： " + ex.Message);
            }

        }

        private void WriteDevParam()
        {

            try
            {
                PLCItemWrite(OPCITEMID_WRITEROUNDMAX, M_MaxRound);
                for (int i = 0; i < M_Outer.Length; i++)
                {
                    if ((M_Outer[i].OPCMAX) != string.Empty)
                    {
                        PLCItemWrite(M_Outer[i].OPCMAX, M_Outer[i].MAX000);
                    }
                
                }
                    M_DevInit = 1;
            }
            catch(Exception ex)
            {
                M_DevInit = 0;
                WriteMemo("WriteDevParam 参数初始化异常： " + ex.Message);

            }
        }
        
        private void UpdateDBByBarCode()
        {

            string sqlstr, outer="";
            DataSet ResDS;
            sqlstr = string.Format("SELECT TOP 1 POUT FROM FJDATA WHERE BARCODE='{0}'", Global.GlobalBarCode);
            try
            {
                sqlstr = string.Format("SELECT TOP 1 POUT FROM FJDATA WHERE BARCODE='{0}'", Global.GlobalBarCode);
                ResDS = Database.GetDataset(sqlstr, "OUTER");

                if (ResDS.Tables[0].Rows.Count > 0)
                {
                    outer = ResDS.Tables[0].Rows[0]["POUT"].ToString();

                }

                if (Global.GlobalIndex == "")
                    Global.GlobalIndex = "0";
                if (outer == "") 
                    outer = "0";
                if (Global.GlobalLength == "")
                    Global.GlobalLength = "0";
                if (Global.GlobalWidth == "")
                    Global.GlobalWidth = "0";
                if (Global.GlobalHeight == "")
                    Global.GlobalHeight = "0";
                if (Global.GlobalVolume == "")
                    Global.GlobalVolume = "0";

                PLCItemWrite(OPCITEMID_WRITEGUID, Global.GlobalIndex);
                PLCItemWrite(OPCITEMID_WRITEOUTID, outer);
                PLCItemWrite(OPCITEMID_ERRBEGIN, 1);

                sqlstr = "UPDATE FJDATA SET PLENGTH=" + Global.GlobalLength + ",PWIDTH=" + Global.GlobalWidth + ",PHEIGHT=" + Global.GlobalHeight +
        ",VOLUME=" + Global.GlobalVolume + ",GUID='" + Global.GlobalIndex + "',PSTATE=1 " + " WHERE BARCODE='" +
        Global.GlobalBarCode + "'";

                Database.GetSqlcom(sqlstr);

                WriteMemo("条码=" + Global.GlobalBarCode + ", 小车号=" + Global.GlobalIndex + ", 出口=" + outer);

                Global.GlobalIndex = "0";
                outer = "0";
                Global.GlobalBarCode = "";
            
            }
            catch (Exception ex)
            {
                Global.ErrorLog("UpdateDBByBarCode 异常：" + sqlstr + "。 " + ex.Message);
            }

        }

        private void WriteOuterForInter()
        {
            string sqlstr, outer="0";
            DataSet ResDS;

            // 根据入口扫码写出口代码到PLC
            try
            {
                if (Global.GlobalBarCodeIn != "" && Global.GlobalOPCItemIn != "")
                {
                    sqlstr = string.Format("SELECT TOP 1 POUT FROM FJDATA WHERE BARCODE='{0}'", Global.GlobalBarCodeIn);
                    ResDS = Database.GetDataset(sqlstr, "OUTER");

                    if (ResDS.Tables[0].Rows.Count > 0)
                    {
                        outer = ResDS.Tables[0].Rows[0]["POUT"].ToString();

                    }
                    PLCItemWrite(Global.GlobalOPCItemIn, outer);
                    //PLCItemWrite("YPRCH.S7-300.IN.IN1", outer);

                    //MessageBox.Show("出口"+outer.ToString());
                    //Global.GlobalBarCodeIn = "";
                    //Global.GlobalOPCItemIn = "";

                    WriteMemo("供包台扫码结果写PLC，出口：" + outer + " PLC(OPC):" + Global.GlobalOPCItemIn);


                }
            }
            catch (Exception ex)
            { 
                Global.ErrorLog("WriteOuterForInter 异常：" + Global.GlobalOPCItemIn + " -> " + outer + " . " + ex.Message);
            }

            
        }

        private void WriteOuterForMain()
        {
            if (Global.GlobalGuid != "" && Global.GlobalOuter != "")
            {
                try
                {
                    PLCItemWrite(OPCITEMID_WRITEGUID, Global.GlobalGuid);
                    PLCItemWrite(OPCITEMID_WRITEOUTID, Global.GlobalOuter);
                    WriteMemo("供包台扫码结果写PLC，唯一码：" + Global.GlobalGuid + " PLC(OPC):" + OPCITEMID_WRITEGUID + "; 出口：" + Global.GlobalOuter + " PLC(OPC):" + OPCITEMID_WRITEOUTID);
                    Global.GlobalGuid = "";
                    Global.GlobalOuter = "";
                
                }
                catch(Exception ex)
                {
                    Global.ErrorLog("WriteOuterForMain 异常：" + Global.GlobalGuid + " -> " + Global.GlobalOuter + "."+ex.Message);
                
                }
            
            }
            
        }


        
        //---------------------opc relate end---------------


        //------------------------TCP SERVER BELOW-------------------------

        void Tcpserver_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
        {
            int res;

            //throw new NotImplementedException();
            string IP, S;
            S = e.Datagram;
            IP = ((IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Address.ToString();
            S = IP + "," + S;
            res = Global.CheckForMsg(S);

            //MessageBox.Show(res.ToString());
            switch (res)
            {
                case 0: break;
                case 1: WriteMemo(Global.GlobalRec); break;
                case 2: WriteMemo(Global.GlobalRec); WriteOuterForInter(); break;
                case 3: WriteMemo(Global.GlobalRec); WriteOuterForMain(); break;
                case 4: WriteMemo(Global.GlobalRec); break;
                case 5: WriteMemo(Global.GlobalRec); break;
                default: break;


            }
        }

        void Tcpserver_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {

            string IP;

            IP = e.TcpClient.Client.RemoteEndPoint.ToString();
            WriteMemo(IP + "断开连接");


            //throw new NotImplementedException();

            // listBox1.Items.Remove(e.TcpClient.Client.RemoteEndPoint.ToString());
            if (this.listBox1.InvokeRequired)
            {
                Action<string> actionDelegate = (x) => { listBox1.Items.Remove(x); };

                this.listBox1.Invoke(actionDelegate, IP);

            }
            else
            {
                listBox1.Items.Remove(IP);
            }

        }

        void Tcpserver_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {
            //throw new NotImplementedException();

            //listBox1.Items.Add(e.TcpClient.Client.RemoteEndPoint.ToString());
            string IP;

            IP = e.TcpClient.Client.RemoteEndPoint.ToString();
            WriteMemo(IP + "连接");

            if (this.listBox1.InvokeRequired)
            {
                Action<string> actionDelegate = (x) => { listBox1.Items.Add(x); };

                this.listBox1.Invoke(actionDelegate, IP);

            }
            else
            {
                listBox1.Items.Add(IP);
            }
        }

        //------------------------TCP SERVER above-------------------------

        
        
        
        //------------------------TCP CLIENT below-------------------------

        private void Scanexec()
        {

            while (!this.IsDisposed)
            {
                //MessageBox.Show("123");
                //Tcpconnect();

                try
                {
                    if (Scaner == null || !Scaner.Connected || (Scaner.Client.Poll(20, SelectMode.SelectRead) && (Scaner.Client.Available == 0)))
                    {

                        Thread.Sleep(10000);
                        Scanconnect();


                    }
                    else
                    {

                        Thread.Sleep(100);
                        Scanread();

                    }
                    //MessageBox.Show(tcpClient.Available.ToString());
                }
                catch
                { }


            }
        }
        //connect
        private void Scanconnect()
        {

            try
            {
                //Application.DoEvents();
                // if (!tcpClient.Connected)
                // {
                //MessageBox.Show("123");
                Application.DoEvents();
                Scaner = new TcpClient();
                Scaner.Connect(Global.GlobalScanIP, Global.GlobalScanPort);

                //tcpClient.Connect("127.0.0.1", 8888);
               // statusStrip1.Items[1].Text = "SOCKET 已连接";

                // }


            }
            catch 
            {

                Scaner.Close();
                Scaner = null;
                /*
                Tc++;
                if (Tc > 99)
                    Tc = 1;
                //IAsyncResult asyncresult = new IAsyncResult();
                tcpClient.Close();
                tcpClient = null;
                statusStrip1.Items[1].Text = "SOCKET 连接...(" + Tc.ToString() + ")";
                if (Havelog == 0)
                {
                    Havelog = 1;
                    Global.ErrorLog("Socket 服务器连接异常： " + ex.Message);

                }
                 */ 
            }

        }

        private void Scanread()
        {
            string msg, tmpstr;
            int p1, p2, p3, p4, ind;

            try
            {
                NetworkStream Stream = Scaner.GetStream();
                if (Stream.DataAvailable)
                {
                    byte[] bytes = new Byte[1024];
                    int Length = Stream.Read(bytes, 0, bytes.Length);
                    if (Length > 0)
                    {
                        Scanreadstr = Encoding.Default.GetString(bytes, 0, Length);

                    }

                }
            }
            catch (Exception ex)
            {
                //statusStrip1.Items[2].Text = ex.Message;

            }

            if (Scanreadstr != "")
            {

                //WriteMemo(Scanreadstr);

                //MessageBox.Show(Scanreadstr);
                try
                {
                    p1 = Scanreadstr.IndexOf("\u0002");
                    p2 = Scanreadstr.IndexOf("\u0003");
                    //p1 = Scanreadstr.IndexOf("A");
                    //p2 = Scanreadstr.IndexOf("B");
                    if (p1 >= 0 && p2 - p1 > 5)
                    {
                        msg = Scanreadstr.Substring(p1 + 1, p2 - p1 - 1);
                        WriteMemo(msg);
                        Scanreadstr = "";

                        ind = msg.ToUpper().IndexOf("NOREAD");
                        if (ind >= 0)
                        {
                            Global.GlobalBarCode = "";
                            Global.GlobalLength = "";
                            Global.GlobalWidth = "";
                            Global.GlobalHeight = "";
                            Global.GlobalVolume = "";
                            Global.GlobalIsBarCodeRead = 0;

                            p3 = msg.IndexOf(",");
                            Global.GlobalIndex = msg.Substring(0, p3);
                            Thread.Sleep(50);

                            BarCodeNoReadNotifyInner();

                        }
                        else
                        {
                            Global.GlobalBarCode = "";
                            Global.GlobalLength = "";
                            Global.GlobalWidth = "";
                            Global.GlobalHeight = "";
                            Global.GlobalVolume = "";
                            Global.GlobalIsBarCodeRead = 1;



                            try
                            {
                                p3 = msg.IndexOf(",");
                                Global.GlobalIndex = msg.Substring(0, p3);

                                tmpstr = msg.Substring(p3 + 1, msg.Length - p3 - 1);
                                
                                p3 = tmpstr.IndexOf(",");
                                Global.GlobalBarCode = tmpstr.Substring(0, p3);
                                // 可能出现多个条码 条码1/条码2/条码3...

                                p4 = Global.GlobalBarCode.IndexOf("/");

                                if (p4 >= 0)
                                {
                                    Global.GlobalBarCode = Global.GlobalBarCode.Substring(0, p4);   
                                }
                                tmpstr = tmpstr.Substring(p3+1,tmpstr.Length-p3-1);

                                p3 = tmpstr.IndexOf(",");
                                Global.GlobalLength = tmpstr.Substring(0, p3);
                                tmpstr = tmpstr.Substring(p3 + 1, tmpstr.Length - p3 - 1);

                                p3 = tmpstr.IndexOf(",");
                                Global.GlobalWidth = tmpstr.Substring(0, p3);
                                tmpstr = tmpstr.Substring(p3 + 1, tmpstr.Length - p3 - 1);
                                Global.GlobalHeight = tmpstr;
                                //p3 = tmpstr.IndexOf(",");
                                //Global.GlobalHeight = tmpstr.Substring(0, p3);
                                //Global.GlobalVolume = tmpstr.Substring(p3 + 1, tmpstr.Length - p3 - 1);
                                Global.GlobalVolume = "0";
                                WriteMemo("Index=" + Global.GlobalIndex + ",条码=" + Global.GlobalBarCode + ",长度=" + Global.GlobalLength + ",宽度=" + Global.GlobalWidth +
                  ",高度=" + Global.GlobalHeight + ",体积=" + Global.GlobalVolume);
                  //notify!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                  //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                UpdateDBByBarCode();


                            }
                            catch (Exception ex)
                            {
                                Global.ErrorLog("控制器数据解析：" + msg + " -> " + ex.Message);
                            
                            }
                        
                        
                        }

                    
                    }
                
                
                }
                catch (Exception ex)
                { 
                    Global.ErrorLog("监控接收数据处理异常： " + ex.Message);
                
                }
            
            }

            Scanreadstr = "";
        }


        //------------------------TCP CLIENT above-------------------------

        //~~~~~~~~~~~~~~~~~~~~~~~READPLC BELOW~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
        private void PLCexec()
        {
            TPrint printInfo;
            int heartRate;
            heartRate = 0;
            while (!this.IsDisposed)
            {
                Application.DoEvents();
                //send heart for PLC
                //Thread.Sleep(100);
                heartRate++;
                try
                {
                    heartRate = 0;
                    WriteHeart1();
                    /*
                    if (heartRate == 1)
                    {
                        heartRate = 0;
                        WriteHeart1();
                    }
                    */ 
                }
                catch(Exception ex)
                {
                    Global.ErrorLog("线程写 PLC 心跳异常： " + ex.Message);

                }
                //DEVICE PARAMETER
                if (M_DevInit == 0)
                {
                    try
                    {
                        WriteDevParam();
                    }
                    catch (Exception ex)
                    {
                        Global.ErrorLog("线程写 PLC 设备参数异常： " + ex.Message);

                    }
                
                }
                // READ PLC WORKING STATUS

                //ReadMain();
                try
                {
                    ReadMain();
                }
                catch (Exception ex)
                {
                    Global.ErrorLog("线程读 PLC 设备状态异常： " + ex.Message);

                }

                //PRINT INFO
                try
                {
                    M_PrintQueue.TrimExcess();
                    if (M_PrintQueue.Count >0)
                    {
                        printInfo = M_PrintQueue.Dequeue();
                        M_PrintQueue.TrimExcess();
                        Global.GlobalPrint_pcs = printInfo.Cou.ToString();
                        Global.GlobalPrint_dest = printInfo.TARNAME;
                        Global.GlobalPrint_barcode = printInfo.BarCode;
                        Global.GlobalPrint_out = printInfo.OUTCode;
                        PrintLabel();


                    }
                }
                catch (Exception ex)
                {
                    Global.ErrorLog("线程打印信息入队列异常： " + ex.Message);

                }


                //REFRESH FORM

                try
                {
                    UpdateDEVStatus();
                }
                catch (Exception ex)
                {
                    Global.ErrorLog("线程显示设备在线状态异常： " + ex.Message);

                }

                try
                {
                    ShowMain();
                }
                catch (Exception ex)
                {
                    Global.ErrorLog("线程显示设备主线状态异常： " + ex.Message);

                }
            
            }

            
        }

        private void UpdateDEVStatus()
        {
            //working status
            labelstate.Text = M_DevState;

            R_rate++;
            if (R_rate == 3)
            {
                R_rate = 1;
                if (this.ovalShape2.FillColor == Color.Green)
                {
                    this.ovalShape2.FillColor = SystemColors.ButtonShadow;
                }
                else
                {
                    this.ovalShape2.FillColor = Color.Green;
                }
            
            }

            if (M_Online == 1)
            {
                this.ovalShape1.FillColor = Color.Green;
            }
            else
            {
                this.ovalShape1.FillColor = Color.Red;
            }

        }

        private void ShowMain()
        {
            int mod8;
            for (int i = 0; i < M_CarPosi.Length; i++)
            {
                if (M_CarPosi[i].OUTID > 0)
                {
                    M_Carry_Lab2[i].Text = M_CarPosi[i].CARID.ToString() + ":" + M_CarPosi[i].OUTID.ToString();
                    M_Carry_Lab2[i].ForeColor = Color.DimGray;
                }
                else
                {
                    M_Carry_Lab2[i].Text = M_CarPosi[i].CARID.ToString();
                    M_Carry_Lab2[i].ForeColor = Color.Yellow;
                }

                mod8 = ((M_CarPosi[i].CARID - 1) / 8) % 2;

                //change cars color by car position
                //8 cars one color
                if (mod8 == 0)
                {
                    M_Carry_Lab2[i].Parent.BackColor = Color.Coral;
                }
                else
                {
                    M_Carry_Lab2[i].Parent.BackColor = Color.Purple;
                }


            }

            for (int i = 0; i < M_Outer.Length; i++)
            {
                M_Carry_Lab_out2[i].Text = M_Outer[i].COUNT0.ToString();   
            }
        
        }

        private void ReadMain()
        {
            int st1, st2, st3, outGuid,chg,outaction;
            string oc, TARCODE, maxseq, pcs, LabBarCode;
            TPrint printInfo = new TPrint();

            //MessageBox.Show("1");
            
            for (int i = 0; i < M_CarPosi.Length; i++)
            {

                //MessageBox.Show(M_CarPosi[i].OPCCARID);
                M_CarPosi[i].CARID = Convert.ToInt32(MainItemRead(M_CarPosi[i].OPCCARID));
                M_CarPosi[i].OUTID = Convert.ToInt32(MainItemRead(M_CarPosi[i].OPCOUTID));

            }

            for (int i = 0; i < M_Outer.Length; i++)
            { 
                M_Outer[i].COUNT0 = Convert.ToInt32(MainItemRead(M_Outer[i].OPCCOU));
                // 读取出口换包信息
                chg = Convert.ToInt32(MainItemRead(M_Outer[i].OPCCHG));
                // 加入打印队列
                if (chg == 1)
                { 
                    printInfo.OUTCode = M_Outer[i].CODE00;
                    printInfo.Cou = M_Outer[i].COUNT0;
                    printInfo.TARCODE = M_Outer[i].TARCODE;
                    printInfo.TARNAME = M_Outer[i].TARNAME;

                    oc = M_Outer[i].CODE00;
                    if(oc.Length<2)
                        oc = "0" + oc;
                    TARCODE = M_Outer[i].TARCODE;
                    while (TARCODE.Length < 6)
                    { 
                        TARCODE = "0" + TARCODE;
                    }
                    pcs = GetPcs(M_Outer[i].CODE00);
                    maxseq = GetMaxSeq(M_Outer[i].CODE00);

                    LabBarCode = oc + TARCODE + pcs + DateTime.Now.ToString("yyMMdd") +maxseq;
                    printInfo.BarCode = LabBarCode;
                    OutPrintUpdate(M_Outer[i].CODE00, LabBarCode);
                    M_PrintQueue.Enqueue(printInfo);
                    M_PrintQueue.TrimExcess();
                    PLCMainItemWrite(M_Outer[i].OPCCHG, 0);

                }
                // 检测 物件从主线 -> 包装袋
                outaction = Convert.ToInt32(MainItemRead(M_Outer[i].OPCOUTBEGIN));
                if (outaction==1)
                {
                    outGuid = Convert.ToInt32(MainItemRead(M_Outer[i].OPCOUTGUID));
                    // 更新数据库对应记录
                    OutUpdate(outGuid, M_Outer[i].CODE00);
                    // 读取完成
                    PLCItemWrite(M_Outer[i].OPCOUTEND, 1);     
                }
      
            
            }

            
            
            
            M_Online = Convert.ToInt32(MainItemRead(OPCITEMID_ONLINE));
            //MessageBox.Show(OPCITEMID_ONLINE);
            st1 = Convert.ToInt32(MainItemRead(OPCITEMID_PLCRUN1));
            st2 = Convert.ToInt32(MainItemRead(OPCITEMID_PLCRUN2));
            st3 = Convert.ToInt32(MainItemRead(OPCITEMID_PLCRUN3));

            M_DevState = "";

            if (st1==1)
                M_DevState = "正常运行";
            if (st2 == 1)
                M_DevState = "急停";
            if (st3 == 1)
                M_DevState = "报警";

        
        }

        //~~~~~~~~~~~~~~~~~~~~~~~READPLC above~~~~~~~~~~~~~~~~~~~~~~~~~~~~//




        //create mainline/in/out below
        private void CreateMainLine()
        {
            int i, i1, i2, i3, i4, i5;
            int lineCount, posright, posleft, ctop, cleft;


            i = 0;
            i1 = 0;
            i2 = 0;
            i3 = 0;
            i4 = 0;
            i5 = 0;
            posright = 0;
            posleft = 0;
            ctop = 0;
            cleft = 0;
            //M_Cars = 64;
            lineCount = (M_Cars - (c_arc * 4)) / 2;
            top0 = 450;
            left0 = (c_carWidth + c_gap) * c_arc;
            M_Carry = new Panel[M_Cars];
            M_Carry_Lab1 = new Label[M_Cars];
            M_Carry_Lab2 = new Label[M_Cars];
            for (i = 0; i < M_Carry.Length; i++)
            {
                M_Carry[i] = new Panel();
                M_Carry[i].Parent = this.panel2;
                M_Carry[i].AutoSize = false;
                M_Carry[i].Width = c_carWidth;
                M_Carry[i].Height = c_carHeight;
                M_Carry[i].BorderStyle = BorderStyle.FixedSingle;
                M_Carry[i].BackColor = Color.Purple;
                
    
                //position ID
                M_Carry_Lab1[i] = new Label();
                M_Carry_Lab1[i].Parent = M_Carry[i];
                M_Carry_Lab1[i].Dock = DockStyle.Top;
                M_Carry_Lab1[i].Text = i.ToString();
                if( i==0 )
                    M_Carry_Lab1[i].Text = M_Carry.Length.ToString();    
                M_Carry_Lab1[i].TextAlign = ContentAlignment.MiddleCenter;
                M_Carry_Lab1[i].Font = new Font(M_Carry_Lab1[i].Font.Name, 10);

                if (i < lineCount) //下
                {
                    M_Carry[i].Top = top0;
                    M_Carry[i].Left = i * (c_carWidth + c_gap) + left0; 
                }
                else if (i >= lineCount && i < lineCount + c_arc) //右下
                {
                    i1++;
                    M_Carry[i].Top = top0 - i1 * (c_carHeight / 2);
                    M_Carry[i].Left = i * (c_carWidth + c_gap) + left0;
                    posright = i * (c_carWidth + c_gap) + left0;
                }
                else if (i >= lineCount + c_arc && i < lineCount + 2 * c_arc)//右上
                {
                    i1++;
                    M_Carry[i].Top = top0 - (i1 +1)* (c_carHeight / 2);
                    M_Carry[i].Left = posright - i2 * (c_carWidth + c_gap);
                    i2++;
                    ctop = M_Carry[i].Top;
                    cleft = M_Carry[i].Left;
                
                }
                else if (i >= lineCount + 2 * c_arc && i < lineCount + 2 * c_arc + lineCount)//上
                {
                    i3++;
                    M_Carry[i].Top = ctop - c_carHeight / 2;
                    M_Carry[i].Left = cleft - i3 * (c_carWidth + c_gap);
                    l2top = M_Carry[i].Top;
                    l2left = M_Carry[i].Left;
                
                }
                else if (i >= lineCount + 2 * c_arc + lineCount && i < lineCount + 3 * c_arc + lineCount)//左上
                {
                    i4++;
                    M_Carry[i].Top = l2top + i4 * (c_carHeight / 2 );
                    M_Carry[i].Left = l2left - i4 * (c_carWidth + c_gap);
                    posleft = M_Carry[i].Left;
                
                }
                else //左下
                {
                    i4++;
                    M_Carry[i].Top = l2top + i4 * (c_carHeight / 2) + (c_carHeight / 2);
                    M_Carry[i].Left = posleft + i5 * (c_carWidth + c_gap);
                    i5++;
                
                }

               



            }

            for (i = 0; i < M_Carry.Length; i++)
            {
                 //CAR ID
                M_Carry_Lab2[i] = new Label();
                if (i < M_Carry.Length - 1)
                {
                    M_Carry_Lab2[i].Parent = M_Carry[i + 1];
                }
                else
                {
                    M_Carry_Lab2[i].Parent = M_Carry[0];   
                }
                    
                
                M_Carry_Lab2[i].Dock = DockStyle.Bottom;
                M_Carry_Lab2[i].Text = "0";
                M_Carry_Lab2[i].ForeColor = Color.Yellow;
                M_Carry_Lab2[i].TextAlign = ContentAlignment.MiddleCenter;
                M_Carry_Lab2[i].Font = new Font(M_Carry_Lab2[i].Font.Name,10);
                
            }
                
        
        }
        // create in here

        private void CreateIn()
        {
            //int i;
            M_In = new Panel[M_InNum];
            M_Carry_Lab_in = new Label[M_InNum];
            for (int i = 0; i < M_In.Length; i++)
            {
                M_In[i] = new Panel();
                M_In[i].Parent = this.panel2;
                M_In[i].AutoSize = false;
                M_In[i].Width = c_carWidth;
                M_In[i].Height = c_carHeight;
                M_In[i].BorderStyle = BorderStyle.FixedSingle;
                M_In[i].BackColor = Color.Green;
                M_In[i].Top = top0 - c_gap - c_InHeight;
                M_In[i].Left = left0 + i * (c_carWidth + c_InGap) + (c_carWidth + c_InGap) * 2;

                M_Carry_Lab_in[i] = new Label();
                M_Carry_Lab_in[i].Parent = M_In[i];
                M_Carry_Lab_in[i].Dock = DockStyle.Fill;
                M_Carry_Lab_in[i].Text = (i+1).ToString();
                //M_Carry_Lab_in[i].ForeColor = Color.Yellow;
                M_Carry_Lab_in[i].TextAlign = ContentAlignment.MiddleCenter;
                M_Carry_Lab_in[i].Font = new Font(M_Carry_Lab_in[i].Font.Name, 10);
            
            
            }

        
        
        }
        
        // create out here

        private void CreateOut()
        {
            int i1;
            int len, linecount, rpos;

            i1 = 0;
            rpos = 0;
            len = M_OunNum_usual + M_OunNum_unusual;
            M_Out = new Panel[len];
            M_Carry_Lab_out1 = new Label[len];
            M_Carry_Lab_out2 = new Label[len];
            linecount = (M_Cars - (c_arc * 4)) / 2;
            for (int i = 0; i < M_Out.Length ; i++)
            {
                M_Out[i] = new Panel();
                M_Out[i].Parent = this.panel2;
                M_Out[i].AutoSize = false;
                M_Out[i].Width = c_carWidth;
                M_Out[i].Height = c_carHeight;
                M_Out[i].BorderStyle = BorderStyle.FixedSingle;
                M_Out[i].BackColor = Color.LightBlue;
               // M_In[i].Top = top0 - c_gap - c_InHeight;
               // M_In[i].Left = left0 + i * (c_carWidth + c_InGap) + (c_carWidth + c_InGap) * 2;

                M_Carry_Lab_out1[i] = new Label();
                M_Carry_Lab_out1[i].Parent = M_Out[i];
                M_Carry_Lab_out1[i].Dock = DockStyle.Top;
                M_Carry_Lab_out1[i].Text = (i + 1).ToString();
                //M_Carry_Lab_out1[i].ForeColor = Color.Yellow;
                M_Carry_Lab_out1[i].TextAlign = ContentAlignment.MiddleCenter;
                M_Carry_Lab_out1[i].Font = new Font(M_Carry_Lab_out1[i].Font.Name, 10);

                M_Carry_Lab_out2[i] = new Label();
                M_Carry_Lab_out2[i].Parent = M_Out[i];
                M_Carry_Lab_out2[i].Dock = DockStyle.Bottom;
                M_Carry_Lab_out2[i].Text = "0";
                M_Carry_Lab_out2[i].ForeColor = Color.Red;
                M_Carry_Lab_out2[i].TextAlign = ContentAlignment.MiddleCenter;
                M_Carry_Lab_out2[i].Font = new Font(M_Carry_Lab_out1[i].Font.Name, 10);

                if (i < M_OunNum_usual)
                {
                    M_Out[i].Top = l2top - c_gap - c_OutHeight;
                    M_Out[i].Left = l2left + 4 * (c_gap + c_carWidth) + i * (c_carWidth + c_OutGap);
                    rpos = M_Out[i].Left;
                }
                else
                {
                    M_Out[i].Top = l2top + c_gap + c_OutHeight;
                    M_Out[i].Left = rpos - i1 * (c_carWidth + c_OutGap);
                    i1++;
                }
            
            
            
            }


        
        
        }


        private void Formmonitor_Load(object sender, EventArgs e)
        {
            //CreateMainLine();
        }

        private void Formmonitor_Shown(object sender, EventArgs e)
        {
            string sqlstr;
            DataSet ResDS;
            int rc, mainitemcount;

           
            
            try
            {   
                try 
                {
                    sqlstr = "SELECT * FROM PARAMETER";
                    ResDS = Database.GetDataset(sqlstr, "PARAM");

                    if (ResDS.Tables[0].Rows.Count>0)
                    {
                        M_Cars = Convert.ToInt32(ResDS.Tables[0].Rows[0]["CARS"]);
                        M_MaxRound = Convert.ToInt32(ResDS.Tables[0].Rows[0]["ROUNDMAX"]);
                        PLCNode = ResDS.Tables[0].Rows[0]["PLCIP"].ToString();

                    }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器1！", "提示", MessageBoxButtons.OK);
                }

                try
                {
                    sqlstr = "SELECT COUNT(*) COU FROM PARAMIN";
                    ResDS = Database.GetDataset(sqlstr, "PARAMIN");

                    if (ResDS.Tables[0].Rows.Count > 0)
                    {
                        M_InNum = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU"]);
                      

                    }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器2！", "提示", MessageBoxButtons.OK);
                }

                try
                {
                    sqlstr = "select cou1,cou2 from (SELECT 1 id,COUNT(*) COU1 FROM PARAMOUT WHERE TYPE00='正常出口') a,(SELECT 1 id,COUNT(*) COU2 FROM PARAMOUT WHERE TYPE00='异常出口') b where a.id=b.id";
                    ResDS = Database.GetDataset(sqlstr, "PARAMOUT");

                    if (ResDS.Tables[0].Rows.Count > 0)
                    {
                        M_OunNum_usual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU1"]);
                        M_OunNum_unusual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU2"]);

                        //MessageBox.Show(M_OunNum_usual.ToString() + M_OunNum_unusual.ToString());
                    }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器3！", "提示", MessageBoxButtons.OK);
                }
            
                //mainline

              
                try
                {
                    //sqlstr = "select cou1,cou2 from (SELECT 1 id,COUNT(*) COU1 FROM PARAMOUT WHERE TYPE00=''正常出口'') a,(SELECT 1 id,COUNT(*) COU2 FROM PARAMOUT WHERE TYPE00=''异常出口'') b where a.id=b.id";

                    sqlstr = "SELECT * FROM POSIINFO ORDER BY POSIID";
                    ResDS = Database.GetDataset(sqlstr, "MAINLINE");
                    M_Cars = ResDS.Tables[0].Rows.Count;
                    M_CarPosi = new TCarPosi[M_Cars];
                    for (int i=0; i < M_Cars; i++)
                    {
                        M_CarPosi[i] = new TCarPosi();
                        M_CarPosi[i].POSIID = Convert.ToInt32(ResDS.Tables[0].Rows[i]["POSIID"]);
                        M_CarPosi[i].GUID00 = 0;
                        M_CarPosi[i].CARID = 0;
                        M_CarPosi[i].OUTID = 0;
                        M_CarPosi[i].OUTCode = "";
                        M_CarPosi[i].OPCCARID = ResDS.Tables[0].Rows[i]["OPCCARID"].ToString().Trim();
                        M_CarPosi[i].OPCOUTID = ResDS.Tables[0].Rows[i]["OPCOUTID"].ToString().Trim();
                        M_CarPosi[i].OPCGUID = ResDS.Tables[0].Rows[i]["OPCGUID"].ToString().Trim();

                            //ResDS.Tables[0].Rows[0]["PLCIP"].ToString();
                    }

                  //  if (ResDS.Tables[0].Rows.Count > 0)
                   // {
                  //      M_OunNum_usual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU1"]);
                 //       M_OunNum_unusual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU2"]);

                 //   }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器4！", "提示", MessageBoxButtons.OK);
                }
               
                //OUT
                try
                {
                    //sqlstr = "select cou1,cou2 from (SELECT 1 id,COUNT(*) COU1 FROM PARAMOUT WHERE TYPE00=''正常出口'') a,(SELECT 1 id,COUNT(*) COU2 FROM PARAMOUT WHERE TYPE00=''异常出口'') b where a.id=b.id";

                    sqlstr = "SELECT * FROM PARAMOUT ORDER BY ID0000";
                    ResDS = Database.GetDataset(sqlstr, "OUT");
                    rc = ResDS.Tables[0].Rows.Count;
                    M_Outer = new TOuter[rc];
                    for (int i = 0; i < rc; i++)
                    {
                        M_Outer[i] = new TOuter(); 
                        M_Outer[i].AutoID = Convert.ToInt32(ResDS.Tables[0].Rows[i]["ID0000"]);
                        M_Outer[i].CODE00 = ResDS.Tables[0].Rows[i]["CODE00"].ToString().Trim();
                        M_Outer[i].MAX000 = Convert.ToInt32(ResDS.Tables[0].Rows[i]["MAX000"]);
                        M_Outer[i].TARCODE = ResDS.Tables[0].Rows[i]["TARCODE"].ToString().Trim();
                        M_Outer[i].TARNAME = ResDS.Tables[0].Rows[i]["TARNAME"].ToString().Trim();
                        M_Outer[i].COUNT0 = 0;
                        M_Outer[i].OPCMAX = ResDS.Tables[0].Rows[i]["OPCITEMIDMAX"].ToString().Trim();
                        M_Outer[i].OPCCOU = ResDS.Tables[0].Rows[i]["OPCITEMIDCOU"].ToString().Trim();
                        M_Outer[i].OPCCHG = ResDS.Tables[0].Rows[i]["OPCITEMIDCHG"].ToString().Trim();
                        M_Outer[i].OPCOUTBEGIN = ResDS.Tables[0].Rows[i]["OPCITEMBEGIN"].ToString().Trim();
                        M_Outer[i].OPCOUTEND = ResDS.Tables[0].Rows[i]["OPCITEMEND"].ToString().Trim();
                        M_Outer[i].OPCOUTGUID = ResDS.Tables[0].Rows[i]["OPCITEMGUID"].ToString().Trim();
                        M_Outer[i].PRINTIP = ResDS.Tables[0].Rows[i]["PRINTIP"].ToString().Trim();

                        //ResDS.Tables[0].Rows[0]["PLCIP"].ToString();
                    }

                    //  if (ResDS.Tables[0].Rows.Count > 0)
                    // {
                    //      M_OunNum_usual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU1"]);
                    //       M_OunNum_unusual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU2"]);

                    //   }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器5！", "提示", MessageBoxButtons.OK);
                }
                
                // IN
                try
                {
                    //sqlstr = "select cou1,cou2 from (SELECT 1 id,COUNT(*) COU1 FROM PARAMOUT WHERE TYPE00=''正常出口'') a,(SELECT 1 id,COUNT(*) COU2 FROM PARAMOUT WHERE TYPE00=''异常出口'') b where a.id=b.id";

                    sqlstr = "SELECT * FROM PARAMIN ORDER BY CODE00";
                    ResDS = Database.GetDataset(sqlstr, "IN");
                    rc = ResDS.Tables[0].Rows.Count;
                    M_Inner = new TInner[rc];
                    for (int i = 0; i < rc; i++)
                    {

                        M_Inner[i] = new TInner();
                        M_Inner[i].AutoID = Convert.ToInt32(ResDS.Tables[0].Rows[i]["ID0000"]);
                        M_Inner[i].CODE00 = ResDS.Tables[0].Rows[i]["CODE00"].ToString().Trim();
                        M_Inner[i].IPADDR = ResDS.Tables[0].Rows[i]["IPADDR"].ToString().Trim();
                        M_Inner[i].READPLC = ResDS.Tables[0].Rows[i]["READPLC"].ToString().Trim();
                        M_Inner[i].WRITEPLC = ResDS.Tables[0].Rows[i]["WRITEPLC"].ToString().Trim();
                        M_Inner[i].ATTR00 = Convert.ToInt32(ResDS.Tables[0].Rows[i]["ATTR00"]);
 

                        //ResDS.Tables[0].Rows[0]["PLCIP"].ToString();
                    }

                    //  if (ResDS.Tables[0].Rows.Count > 0)
                    // {
                    //      M_OunNum_usual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU1"]);
                    //       M_OunNum_unusual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU2"]);

                    //   }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器6！", "提示", MessageBoxButtons.OK);
                }

                //opc items
                sqlstr = "SELECT * FROM OPCITEM WHERE NAME00<>'ERROR'";
                ResDS = Database.GetDataset(sqlstr, "OPC");
                OPCITEMID_CARENTER =findopcitem("CARENTER", ResDS);
                OPCITEMID_CARLEAVE =findopcitem("CARLEAVE", ResDS);
                OPCITEMID_CURCARID =findopcitem("CURCARID", ResDS);
                OPCITEMID_CURGUID = findopcitem("CURGUID", ResDS);
                OPCITEMID_CUROUTER =findopcitem("CUROUTER", ResDS);
                OPCITEMID_ONLINE =findopcitem("ONLINE", ResDS);
                OPCITEMID_PLCRUN1 =findopcitem("PLCRUN1", ResDS);
                OPCITEMID_PLCRUN2 =findopcitem("PLCRUN2", ResDS);
                OPCITEMID_PLCRUN3 =findopcitem("PLCRUN3", ResDS);
                OPCITEMID_WRITEHEART =findopcitem("WRITEHEART", ResDS);
                OPCITEMID_WRITEROUNDMAX =findopcitem("WRITEROUNDMAX", ResDS);
                OPCITEMID_WRITEGUID =findopcitem("WRITEGUID", ResDS);
                OPCITEMID_WRITEOUTID =findopcitem("WRITEOUTID", ResDS);
                OPCITEMID_ERRBEGIN =findopcitem("ERRBEGIN", ResDS);
                OPCITEMID_ERREND =findopcitem("ERREND", ResDS);

                //ERROR OPC
                try
                {
                    //sqlstr = "select cou1,cou2 from (SELECT 1 id,COUNT(*) COU1 FROM PARAMOUT WHERE TYPE00=''正常出口'') a,(SELECT 1 id,COUNT(*) COU2 FROM PARAMOUT WHERE TYPE00=''异常出口'') b where a.id=b.id";

                    sqlstr = "SELECT * FROM OPCITEM WHERE NAME00='ERROR'";
                    ResDS = Database.GetDataset(sqlstr, "OPCERROR");
                    rc = ResDS.Tables[0].Rows.Count;
                    M_Errors = new string[rc];
                    for (int i = 0; i < rc; i++)
                    {
                        //M_Inner[i].AutoID = Convert.ToInt32(ResDS.Tables[0].Rows[i]["ID0000"]);
                        //M_Inner[i].CODE00 = ResDS.Tables[0].Rows[i]["CODE00"].ToString().Trim();
                        M_Errors[i] = ResDS.Tables[0].Rows[i]["ITEMID"].ToString().Trim();


                        //ResDS.Tables[0].Rows[0]["PLCIP"].ToString();
                    }

                    //  if (ResDS.Tables[0].Rows.Count > 0)
                    // {
                    //      M_OunNum_usual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU1"]);
                    //       M_OunNum_unusual = Convert.ToInt32(ResDS.Tables[0].Rows[0]["COU2"]);

                    //   }

                }
                catch
                {
                    MessageBox.Show("无法连接数据库服务器7！", "提示", MessageBoxButtons.OK);
                }
                
                //OPC connect

                try
                {
                    OPCServer1 = new OPCServer();
                    OPCServer1.Connect(PLCProgID);
                    ObjOPCGroups = OPCServer1.OPCGroups;
                    OPCGroupMain = ObjOPCGroups.Add("main");
                    OPCGroupMain.IsActive = true;
                    OPCGroupMain.IsSubscribed = false;
                    MainOPCItems = OPCGroupMain.OPCItems;

                    for (int i = 0; i < M_CarPosi.Length; i++)
                    { 
                        mainitemcount = MainOPCItems.Count;
                        if (M_CarPosi[i].OPCCARID != string.Empty)
                        {
                            MainOPCItems.AddItem(M_CarPosi[i].OPCCARID, mainitemcount + 1);    
                        }
                        mainitemcount = MainOPCItems.Count;
                        if (M_CarPosi[i].OPCOUTID != string.Empty)
                        {
                            MainOPCItems.AddItem(M_CarPosi[i].OPCOUTID, mainitemcount + 1);
                        }
                    
                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = MainOPCItems.Count;
                        if (M_Outer[i].OPCCOU != string.Empty)
                        {
                            MainOPCItems.AddItem(M_Outer[i].OPCCOU, mainitemcount + 1);
                        }
                      

                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = MainOPCItems.Count;
                        if (M_Outer[i].OPCCHG != string.Empty)
                        {
                            MainOPCItems.AddItem(M_Outer[i].OPCCHG, mainitemcount + 1);
                        }


                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = MainOPCItems.Count;
                        if (M_Outer[i].OPCOUTBEGIN != string.Empty)
                        {
                            MainOPCItems.AddItem(M_Outer[i].OPCOUTBEGIN, mainitemcount + 1);
                        }


                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = MainOPCItems.Count;
                        if (M_Outer[i].OPCOUTGUID != string.Empty)
                        {
                            MainOPCItems.AddItem(M_Outer[i].OPCOUTGUID, mainitemcount + 1);
                        }


                    }
                    for (int i = 0; i < M_Errors.Length; i++)
                    {
                        mainitemcount = MainOPCItems.Count;
                        if (M_Errors[i] != string.Empty)
                        {
                            MainOPCItems.AddItem(M_Errors[i], mainitemcount + 1);
                        }


                    }

                    mainitemcount = MainOPCItems.Count;
                    MainOPCItems.AddItem(OPCITEMID_ONLINE, mainitemcount + 1);
                    MainOPCItems.AddItem(OPCITEMID_PLCRUN1, mainitemcount + 2);
                    MainOPCItems.AddItem(OPCITEMID_PLCRUN2, mainitemcount + 3);
                    MainOPCItems.AddItem(OPCITEMID_PLCRUN3, mainitemcount + 4);
                    MainOPCItems.AddItem(OPCITEMID_CURCARID, mainitemcount + 5);
                    MainOPCItems.AddItem(OPCITEMID_CURGUID, mainitemcount + 6);
                    MainOPCItems.AddItem(OPCITEMID_CUROUTER, mainitemcount + 7);

                    // 主线扫码前光电检测
                    //OPCGCarEnter.ConnectTo(OPCServer1.OPCGroups.Add('carEnter'));
                    OPCGCarEnter = ObjOPCGroups.Add("carEnter");
                    OPCGCarEnter.IsActive = true;
                    OPCGCarEnter.IsSubscribed = true;
                    CarEnterOPCItems = OPCGCarEnter.OPCItems;
                    CarEnterOPCItems.AddItem(OPCITEMID_CARENTER, 1);

                     //ERROR
                    //OPCGroupErrBegin.ConnectTo(OPCServer1.OPCGroups.Add('errBegin'));
                    OPCGroupErrBegin = ObjOPCGroups.Add("errBegin");
                    OPCGroupErrBegin.IsActive = true;
                    OPCGroupErrBegin.IsSubscribed = true;
                    ErrBeginOPCItems = OPCGroupErrBegin.OPCItems;
                    ErrBeginOPCItems.AddItem(OPCITEMID_ERRBEGIN, 1);

                    // 写入 PLC
                    //OPCGroupWrite.ConnectTo(OPCServer1.OPCGroups.Add('writePlc'));
                    OPCGroupWrite = ObjOPCGroups.Add("writePlc");
                    OPCGroupWrite.IsActive = true;
                    OPCGroupWrite.IsSubscribed = false;
                    WriteOPCItems = OPCGroupWrite.OPCItems;

                    WriteOPCItems.AddItem(OPCITEMID_WRITEHEART, 1);
                    WriteOPCItems.AddItem(OPCITEMID_WRITEROUNDMAX, 2);
                    WriteOPCItems.AddItem(OPCITEMID_WRITEGUID, 3);
                    WriteOPCItems.AddItem(OPCITEMID_WRITEOUTID, 4);
                    WriteOPCItems.AddItem(OPCITEMID_ERREND, 5);
                    WriteOPCItems.AddItem(OPCITEMID_CARLEAVE, 6);
                    WriteOPCItems.AddItem(OPCITEMID_ERRBEGIN, 7);

                    for (int i = 0; i < M_Inner.Length; i++)
                    {
                        mainitemcount = WriteOPCItems.Count;
                        WriteOPCItems.AddItem(M_Inner[i].WRITEPLC, mainitemcount + 1);


                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = WriteOPCItems.Count;
                        WriteOPCItems.AddItem(M_Outer[i].OPCMAX, mainitemcount + 1);


                    }
                    for (int i = 0; i < M_Outer.Length; i++)
                    {
                        mainitemcount = WriteOPCItems.Count;
                        WriteOPCItems.AddItem(M_Outer[i].OPCOUTEND, mainitemcount + 1);

                    }





                }
                catch (Exception ex)
                { 
                    Global.ErrorLog("监控主页面 OPC 通讯设置异常： " + ex.Message);
                }

                

                //create mainline in form
                c_carWidth = ((SystemInformation.WorkingArea.Width - 80) * 2 / M_Cars) - c_gap;
                //c_carWidth = 35;
                CreateMainLine();
                CreateIn();
                CreateOut();


                //Tcpserver 

                Tcpserver = new AsyncTcpServer(IPAddress.Any, Global.GlobalPort);
                Tcpserver.Encoding = Encoding.UTF8;
                Tcpserver.ClientConnected += new EventHandler<TcpClientConnectedEventArgs>(Tcpserver_ClientConnected);
                Tcpserver.ClientDisconnected += new EventHandler<TcpClientDisconnectedEventArgs>(Tcpserver_ClientDisconnected);
                //Tcpserver.DatagramReceived += new EventHandler<TcpDatagramReceivedEventArgs<string>>(Tcpserver_DatagramReceived);
                Tcpserver.PlaintextReceived += new EventHandler<TcpDatagramReceivedEventArgs<string>>(Tcpserver_PlaintextReceived);
                //Tcpserver.IsBackground = true;
                Tcpserver.Start();
                WriteMemo("Socket 服务启动");

                //unsafe method to use form
                //add by dendi 2016/4/29
                Control.CheckForIllegalCrossThreadCalls = false;

                //FIFO CREATE
                M_PrintQueue = new Queue<TPrint>();

                
                //PLCread
                ThreadPLC = new Thread(this.PLCexec);
                ThreadPLC.IsBackground = true;
                ThreadPLC.Priority = ThreadPriority.Highest;
                ThreadPLC.Start();  // 只要使用Start方法，线程才会运行 
                
                //Tcpclient

                Scanconnect();
                Threadscan = new Thread(this.Scanexec);
                Threadscan.IsBackground = true;
                Threadscan.Start();  // 只要使用Start方法，线程才会运行 




            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            
            
            
        
        }

        private void Formmonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
            M_PrintQueue.Clear();
            Tcpserver.Stop();
            Tcpserver.Dispose();
            Threadscan.Abort();
            ThreadPLC.Abort();
            OPCServer1.OPCGroups.RemoveAll();
            OPCServer1.Disconnect();
         

            this.Dispose();
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        private void Formmonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            M_PrintQueue.Clear();
            Tcpserver.Stop();
            Tcpserver.Dispose();
            Threadscan.Abort();
            ThreadPLC.Abort();
            OPCServer1.OPCGroups.RemoveAll();
            OPCServer1.Disconnect();


            this.Dispose();
        }


       

    }
        

      
}
