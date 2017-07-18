using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.Data
{
   public class DataSetBD
    {
       public static DataSet GetDataSearch(SqlCommand c)
       {
           DataSet SearchData = new DataSet();
           try
           {
               using (SqlConnection con = new SqlConnection(Properties.Settings.Default.cs1))
               {
                   SqlCommand com = new SqlCommand();
                   com = c;
                   SqlDataAdapter da = new SqlDataAdapter();
                   da.SelectCommand = com;
                   com.Connection = con;
                   da.Fill(SearchData, "table");
                   return SearchData;
               }
           }
           catch (Exception ex)
           {
               WriteLogsBD.RegisterLogs(ex.ToString(), "DATA");
               return SearchData;
           }
       }

    }
}
