using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.forms
{
    public partial class wfViewMorenaLocalFiscal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_MENUPERFIL"] != null) { }
            else { Response.Redirect("~/Login.aspx"); }
        }
    }
}