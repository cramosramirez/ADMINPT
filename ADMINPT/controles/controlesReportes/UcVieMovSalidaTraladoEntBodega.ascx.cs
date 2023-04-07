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
    public partial class UcVieMovSalidaTraladoEntBodega : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "TRASLADO ENTRE BODEGAS - SALIDAS";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporteConta.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
            llenarTipoMovimientos();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            UCBarraNavegacion.ReporteConta_Click += _btn_reporte_Click;
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
                llenarReport();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void llenarTipoMovimientos()
        {
            cbxTiposMovimientos.DataSource = CDats._CB_TIPOS_GENERALES(Convert.ToInt32(5), Convert.ToInt32(1));
            cbxTiposMovimientos.DataBind();
        }
        public void llenarReport()
        {

            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovSalidaTraladoEntBodega(Convert.ToInt32(cb_bodegaO.Value), Convert.ToInt32(cbxBodegaDestino.Value), Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value),Convert.ToString(cb_zafra.Text)));
            MovimientoRpt.OpenReport(cachedReportSourceKardex);

        }
        protected void cbxTiposMovimientos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
