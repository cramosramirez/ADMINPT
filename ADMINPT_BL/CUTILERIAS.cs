using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADMINPT.BL
{
    public static class CUTILERIAS
    {
        public static string ObtenerUsuario()
        {
            string usuario = "admin";//System.Threading.Thread.CurrentPrincipal.Identity.Name;
            if (usuario == null)
            {
                return "";
            }
            else
            {
                return usuario;
            }            
        }
    }
}
