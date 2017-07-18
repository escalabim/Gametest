using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.Data
{
    class WriteLogsBD
    {
        /// <summary>
        /// Event Log registers
        /// </summary>
        /// <param name="error"></param>
        /// <param name="layer"></param>
        public static void RegisterLogs(string error, string layer)
        {
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.cs1))
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "RegisterLogs";
                com.Parameters.Add("@error", SqlDbType.Int).Value = error;
                com.Parameters.Add("@layer", SqlDbType.Int).Value = layer;                
                com.Connection = cn;
                cn.Open();
                com.ExecuteNonQuery();
                cn.Close();
                
            }
        }
    }
}
