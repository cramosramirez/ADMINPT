using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADMINPTWIN
{
   public static class Cnn
    {
         public static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADMINPTWIN.Properties.Settings.ConWin"].ConnectionString);
    }

}
