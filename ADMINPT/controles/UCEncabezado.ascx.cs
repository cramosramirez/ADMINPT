using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UCEncabezado : System.Web.UI.UserControl
    {       
       public string Titulo
        {
            get { return lblTitulo.Text; }
            set { lblTitulo.Text = value;}
        }
    }
}