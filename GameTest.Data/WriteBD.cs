using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.Data
{
    public class WriteBD
    {

        public static bool RunBd(SqlCommand cm)
        {
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.cs1))
            {
                try
                {
                    SqlCommand c = new SqlCommand();
                    c = cm;
                    c.Connection = cn;
                    cn.Open();
                    c.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    WriteLogsBD.RegisterLogs(ex.ToString(), "DATA");
                    return false;
                }

                return true;
            }

        }


        public static object SelectValue(SqlCommand cm)
        {
            using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.cs1))
            {
                object ob = string.Empty;
                try
                {
                    SqlCommand c = new SqlCommand();
                    c = cm;
                    c.Connection = cn;
                    cn.Open();
                    ob = c.ExecuteScalar();
                    cn.Close();
                    if (ob == null)
                    {
                        ob = "null";
                    }

                }

                catch (Exception ex)
                {
                    WriteLogsBD.RegisterLogs(ex.ToString(), "DATA");
                    return ob;

                }
                return ob;
            }
        }
    }
}
