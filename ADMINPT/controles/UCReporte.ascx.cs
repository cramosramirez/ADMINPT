using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UCReporte : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DevExpress.XtraReports.Web.ASPxWebDocumentViewer dv_Reporte
        {
            get { return _dv_Reporte; }
            set { _dv_Reporte = value; }
        }
    }
}