using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.controles.movimiento_auto;
using DevExpress.XtraReports.Web;

namespace ADMINPT.forms.movimiento_auto
{
    public partial class wfViewReportesBP : System.Web.UI.Page
    {
        public void View_rpt()
        {
            if (Convert.ToString(Request.QueryString["rpt"]) == "1")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptReportBP(Convert.ToInt32(Session["ID_EMPRESA"]), Convert.ToInt32(Request.QueryString["idz"]), Convert.ToInt32(Request.QueryString["iddz"]), Convert.ToInt32(Request.QueryString["idt"])));
                Produccion.OpenReport(cachedReportSourceKardex);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["USUARIO"]) != "")
            {
                if (!IsPostBack)
                {

                    View_rpt();
                }
                else
                {
                    View_rpt();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}