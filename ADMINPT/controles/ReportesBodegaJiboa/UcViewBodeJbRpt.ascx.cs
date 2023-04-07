using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.ReportesBodegaJiboa
{
    public partial class UcViewBodeJbRpt : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            //UCEncabezado.Titulo = "DOCUMENTO DIGITALIZADO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = false;
            UCBarraNavegacion.btn_salir.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;

            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _btn_reporte_Click(null, null);
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/forms/DigitalizacionRpt/wfConsultaDoc.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            llenarReporteNotas(Convert.ToInt32(Request.QueryString["id"]));
        }
        public void llenarReporteNotas(int id)
        {
            //if (Convert.ToInt32(Request.QueryString["tp"]) == 1) //TRASLADO
            //{
            //    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaMelazaD(Convert.ToInt32(id)));
            //    Facturado.OpenReport(cachedReportSourceKardex);
            //}
            //if (Convert.ToInt32(Request.QueryString["tp"]) == 2 && Convert.ToInt32(Request.QueryString["tpd"]) == 2) //VENTA FACTURA
            //{
            //    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboaFC(Convert.ToInt32(id)));
            //    Facturado.OpenReport(cachedReportSourceKardex);
            //}
            //if (Convert.ToInt32(Request.QueryString["tp"]) == 2 && Convert.ToInt32(Request.QueryString["tpd"]) == 3) //VENTA CREDITO FISCAL
            //{
            //    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboaCFFD(Convert.ToInt32(id)));
            //    Facturado.OpenReport(cachedReportSourceKardex);
            //}
            //if (Convert.ToInt32(Request.QueryString["tp"]) == 3) //VENTA DIZUCAR
            //{
            //    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaMelazaD(Convert.ToInt32(id)));
            //    Facturado.OpenReport(cachedReportSourceKardex);
            //}
        }
    }
}
