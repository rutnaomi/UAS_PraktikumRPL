using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemTugas
{
    public static class DBHelper
    {
        private static string ConnectionString = "Server=localhost;port=3306;Database=sistemtugas;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
    //internal class DBHelper
    //{

    //}

}
