using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.controlesReportes
{
    public partial class UcViewMovEstraBpProd : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "REPORTES ESTRATEGICO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fecha.Date = DateTime.Now;
            llenarTipoMovimientos();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
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
            try
            {
                llenarReporteNotas();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void llenarTipoMovimientos()
        {
            cbxTiposMovimientos.DataSource = CDats._CB_TIPOS_GENERALES(Convert.ToInt32(3), Convert.ToInt32(1));
            cbxTiposMovimientos.DataBind();
        }
        public void llenarReporteNotas()
        {
            if (Convert.ToString(txt_fecha.Text) != "")
            {
                if (Convert.ToInt32(cbxTiposMovimientos.Value) == 1)
                {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptEstExistenciaGeneral(Convert.ToDateTime(txt_fecha.Text)));
                    MovimientoRpt.OpenReport(cachedReportSourceKardex);
                }
                if (Convert.ToInt32(cbxTiposMovimientos.Value) == 2)
                {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptEstExistenciaBodeZafraBpProd(Convert.ToDateTime(txt_fecha.Text), Convert.ToInt32(Session["ID_BODEP"]), Convert.ToInt32(Session["ID_TIPO_PROD"])));
                    MovimientoRpt.OpenReport(cachedReportSourceKardex);
                }
                if (Convert.ToInt32(cbxTiposMovimientos.Value) == 3)
                {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptEstExistenciaBodePrestBpProd(Convert.ToDateTime(txt_fecha.Text),Convert.ToInt32(Session["ID_BODEP"]),Convert.ToInt32(Session["ID_TIPO_PROD"])));
                    MovimientoRpt.OpenReport(cachedReportSourceKardex);
                }
            }
        }
    }
}
