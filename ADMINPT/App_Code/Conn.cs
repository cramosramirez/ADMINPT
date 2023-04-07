using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Web.Configuration;

namespace ADMINPT
{
    public class Conn
    {
        public static SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public static OleDbConnection cnph = new OleDbConnection(WebConfigurationManager.ConnectionStrings["PH"].ConnectionString);
       

    }
}