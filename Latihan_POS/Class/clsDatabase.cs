using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Latihan_POS
{
    class clsDatabase
    {
        private static string conn = "Server=localhost;Port=3306;Database=db_pos;Uid=root;password='';Convert zero datetime=true";
        public static MySqlConnection con = new MySqlConnection(conn);
        public static void openDB()
        {
            try
            {
                con.Open();
            }
            catch(MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void closeDB()
        {
            try
            {
                con.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
