using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.Facturado
{
    public partial class UcViewFacturado : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "MOVIMIENTOS FACTURADOS";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
        }
        protected void Page_Init(object sender, EventArgs e)
        { Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {

            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptFacturado(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text),Convert.ToInt32(rdOpciones.SelectedItem.Value)));
            Facturado.OpenReport(cachedReportSourceKardex);

        }
    }
}