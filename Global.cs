using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace yprfj
{
    class Global
    {
        //global var below
        public static string Globaluser;
        public static string Globaluserid;
        public static string Globalgroup;
        //static string connstr;
        public static string GlobalXMLFile = @"XML\FJDATA.XML";
        public static string GloballocalIP;
        public static string GlobalCtrlIP;
        public static string GlobalBarCode;
        public static string GlobalLength;
        public static string GlobalWidth;
        public static string GlobalHeight;
        public static string GlobalVolume;
        public static string Globalindex;
        public static string GlobalBarCodeIn;
        public static string GlobalOPCItemIn;
        public static string GlobalGuid;
        public static string GlobalOuter;
        public static string GlobalRec;
        public static string GlobalScanIP = "127.0.0.1";
        public static string GlobalIndex;
        public static string GlobalPrint_origin;
        public static string GlobalPrint_pcs;
        public static string GlobalPrint_dest;
        public static string GlobalPrint_barcode;
        public static string GlobalPrint_out;
        public static string GlobalPrint_ip;
        public static string GlobalPrint_name = "ZDesigner ZM400 300 dpi (ZPL)";
        public static int GlobalScanPort = 4321;
        public static int GlobalIsBarCodeRead;
        public static int GlobalPort=8888;


        //normal function for record log and error
        public static int RecordLog(string loginfo)
        { 
            //pass
            string sqlstr;
            
            
            try
            {
                sqlstr = string.Format("insert into USERLOG(USER00,DATE00,OPERAT) values('{0}','{1}','{2}')", Globaluser, DateTime.Now.ToString(), loginfo);
                Database.GetSqlcom(sqlstr);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public static int ErrorLog(string loginfo)
        {
            string sqlstr;


            try
            {
                sqlstr = string.Format("insert into PCALARMS(FROM00,AlarmTime,AlarmText) values('{0}','{1}','{2}')", GloballocalIP, DateTime.Now.ToString(), loginfo);
                Database.GetSqlcom(sqlstr);
                return 0;
            }
            catch
            {
                return 1;
            }
            
        }
        public static int OpenForm<T>(ref T frm,Form main) where T:Form,new()
        {
            try
            {
                if (frm == null || frm.IsDisposed)
                {
                    frm = new T();
                    frm.MdiParent = main;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.TopMost = true;
                    frm.Show();
                }
                else
                {
                    frm.BringToFront();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
            
        }

        public static string GetLocalIp()  
         {  
             string hostname = Dns.GetHostName();//得到本机名   
             //IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址   
             IPHostEntry localhost = Dns.GetHostEntry(hostname);  
             //IPAddress localaddr = localhost.AddressList[0];  
             //return localaddr.ToString();
             for (int i = 0; i < localhost.AddressList.Length; i++)
             {
                 //从IP地址列表中筛选出IPv4类型的IP地址
                 //AddressFamily.InterNetwork表示此IP为IPv4,
                 //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                 if (localhost.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                 {
                     return localhost.AddressList[i].ToString();
                 }
             }
             return "";
         }


        //drive below

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);


        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);



        // printer function below

        public static int WriteRawStringToPrinter(string Printer, string ZPLCode)
        {
       // Handle: THandle;
       // n: DWORD;
       // DocInfo1: TDocInfo1;
       // PS: ansistring;
            Int32 dwWritten = 0,dwCount;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA DocInfo = new DOCINFOA();
            IntPtr pBytes;

            DocInfo.pDocName = "PrintLabel";
            DocInfo.pDataType = "RAW";

            if (OpenPrinter(Printer.Normalize(), out hPrinter, IntPtr.Zero))
            {
               // StartDocPrinter(Handle, 1, @DocInfo1);
               // StartPagePrinter(Handle);
               // WritePrinter(Handle, PAnsiChar(PS), Length(PS), n);
              //  EndPagePrinter(Handle);
              //  EndDocPrinter(Handle);
              //  ClosePrinter(Handle);

                // How many characters are in the string?
                dwCount = ZPLCode.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(ZPLCode);
                
                StartDocPrinter(hPrinter, 1, DocInfo);
                StartPagePrinter(hPrinter);
                WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);

                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
                ClosePrinter(hPrinter);



                return 0;
            }
            
            return -1;
        }

       
        
        public static string MakeZPLCode(string O_barcode, string O_dest, string O_pcs, string GlobalPrint_origin)
        {
            string prtstr, tempstr, code, fontname;
            int fontsize1, fontsize2;

            // 字体
            fontname = "黑体";
            fontsize1 = 22;
            fontsize2 = 45;
             // 128码
            prtstr = "^XA^LL540^PW1080^IA6^XZ^FS^XA^FS^MD10^BY3,3^LH20,23^FS";
              // ^XA^LL540^PW1080^IA6^XZ setting printer
            tempstr = "^FO400,50^BC,150^FD";
            prtstr = prtstr + tempstr;
            tempstr = O_barcode + "^FS";
            prtstr = prtstr + tempstr;

            tempstr = "^FO400,280^BC,150^FD";
            prtstr = prtstr + tempstr;
            tempstr = O_barcode + "^FS";
            prtstr = prtstr + tempstr;

            prtstr = prtstr + PrtChnStr(50, 50, fontname, fontsize1, 1, 2, "目的地");
            prtstr = prtstr + PrtChnStr(50, 120, fontname, fontsize1, 1, 2, "Destination");
            prtstr = prtstr + PrtChnStr(180, 50, fontname, fontsize2, 1, 2, O_dest);

            prtstr = prtstr + PrtChnStr(50, 280, fontname, fontsize1, 1, 2, "件数");
            prtstr = prtstr + PrtChnStr(50, 320, fontname, fontsize1, 1, 2, "Pcs");
            prtstr = prtstr + PrtChnStr(180, 280, fontname, fontsize2, 1, 2, O_pcs);

            prtstr = prtstr + PrtChnStr(50, 400, fontname, fontsize1, 1, 2, "始发地");
            prtstr = prtstr + PrtChnStr(50, 450, fontname, fontsize1, 1, 2, "Origin");
            prtstr = prtstr + PrtChnStr(180, 400, fontname, fontsize2, 1, 2, GlobalPrint_origin);

            tempstr = "^PQ1^FS"; // 打印1份
            prtstr = prtstr + tempstr;

            tempstr = "^PRC^FS^XZ^FS^XA^EG^XZ"; // 打印结束
            prtstr = prtstr + tempstr;

            return prtstr;
        }

        [DllImport("fnthex32.dll", EntryPoint = "GETFONTHEX", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int GETFONTHEX(string chnstr, string fontname, int orient, int height, int weight, int bold, int italic, StringBuilder ReturnBarcodeCMD);
        
        
        public static string PrtChnStr(int X, int Y, string Fontname, int Height, int Xmf, int Ymf, string Chnstr)
        {
            string Ret, Ans="";
            int Count;
            StringBuilder Buf = new StringBuilder(21 * 1024);

            
            if (Chnstr != "")
            {
                Count = GETFONTHEX(Chnstr, Fontname,0, Height, 0, 1, 0, Buf);//must be allocate first add by dendi
                //orient=0 height=height width=0 bold=1 italic=0 buf=buf
                if (Count > 0)
                {
                    //Ret = Buf.Substring(0, Count);
                    Ret = Buf.ToString();
                    Ans = Ret + "^FO" + X.ToString() + "," + Y.ToString() + "^XGOUTSTR01," + Xmf.ToString() + "," +
                    Ymf.ToString() + "^FS";
                }
            }
            

            return Ans;
        }

        public static int CheckForMsg(string S)
        {
            string sCommand, msg, tmpStr;
            int p1, p2, p3;
            if (S != "")
            { 
                sCommand = S;
                GlobalRec = "接收：" + sCommand;

                p1 = sCommand.IndexOf("[STX]");
                p2 = sCommand.IndexOf("[ETX]");
                if (p1 >= 0 && p2 - p1 > 5)
                {
                    msg = sCommand.Substring(p1 + 5, p2 - p1 - 5);
                    //msg = msg.ToUpper();
                    if (msg.ToUpper() == "NOREAD")// 控制器 未读取条码已经不用
                    {
                        return 1;   
                    
                    }
                    else if (msg.ToUpper().StartsWith("BC:"))
                    {
                        tmpStr = msg.Substring(3, msg.Length - 3);
                        try
                        { 
                            p3 = tmpStr.IndexOf(',');
                            GlobalOPCItemIn = tmpStr.Substring(0, p3);
                            GlobalBarCodeIn = tmpStr.Substring(p3+1, tmpStr.Length-p3-1);


                        }
                        catch(Exception ex)
                        { 
                            ErrorLog("入口数据解析：" + msg + " -> " + ex.Message);
                        }


                        return 2;
                    }
                    else if (msg.ToUpper().StartsWith("BM:"))
                    {
                        tmpStr = msg.Substring(3, msg.Length - 3);
                        try
                        {
                            p3 = tmpStr.IndexOf(',');
                            GlobalGuid = tmpStr.Substring(0, p3);
                            GlobalOuter = tmpStr.Substring(p3 + 1, tmpStr.Length - p3 - 1);


                        }
                        catch (Exception ex)
                        {
                            ErrorLog("条码未识别，补录入数据解析：" + msg + " -> " + ex.Message);
                        }
                        
                        
                        return 3;
                    }
                    else
                    {
                        return 4;
                    }


                    
                }

                return 5;
            }
            
            return 0;
        }
    }
}
