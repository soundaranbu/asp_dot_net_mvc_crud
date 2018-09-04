using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ASPMVC.Manager
{
    public class DataBase
    {
        private static String ConnectionString = WebConfigurationManager.AppSettings["ConnectionString"];
        public SqlConnection Connection = new SqlConnection(ConnectionString);

        public static DataBase Instance = new DataBase();

        DataBase()
        {
            Connection = new SqlConnection(ConnectionString);
        }
    }
}