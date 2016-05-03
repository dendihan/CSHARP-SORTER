using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace yprfj
{
    class Database
    {
        public static SqlConnection My_con;
        public static string M_str_sqlcon = "";

        public static string GetConStr()
        {
            string Connstr;
            //StreamReader sr;
            try
            {
                StreamReader sr = new StreamReader("Para.ini", Encoding.Default);
                //String line;
                Connstr = sr.ReadLine();
                sr.Dispose();
            }
            catch
            {
                //sr.Dispose();
                Connstr = "";
            }

            return Connstr;
        }

        //for sqlconnection open
        public static SqlConnection GetCon()
        {
            My_con = new SqlConnection(M_str_sqlcon);
            try
            {
                My_con.Open();
            }
            catch
            {
                My_con.Close();
            }
            return My_con;            
        }
        //sqlconnection close
        public static void ConClose()
        {
            if (My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose();
            }
        }

        //return data reader(read only)
        public static SqlDataReader GetCom(string Sqlstr)
        {
            GetCon();
            SqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = Sqlstr;
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }
        //insert/update/delete
        public static void GetSqlcom(string Sqlstr)
        {
            GetCon();
            SqlCommand Sqlcom = new SqlCommand(Sqlstr,My_con);
            Sqlcom.ExecuteNonQuery();
            Sqlcom.Dispose();
            ConClose();        
        }
        //get dataset for table
        public static DataSet GetDataset(string Sqlstr,string Tablename)
        {
            GetCon();
            SqlDataAdapter Sqlda = new SqlDataAdapter(Sqlstr, My_con);
            DataSet My_dataset = new DataSet();
            Sqlda.Fill(My_dataset, Tablename);
            ConClose();
            return My_dataset;
        }









    }
}
