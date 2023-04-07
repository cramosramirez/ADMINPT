using ADMINPT.controles.movimiento_traslado.traslados;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimiento_traslado
{
    public partial class UcViewMovientosCriterios : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "TRASLADOS POR PRODUCTO";
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

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.ReporteConta_Click += _btn_reporte_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
             ibog = Convert.ToInt32(Session["ID_BODEP"]); 
            cb_bodegaO.Value = ibog;

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
        public void llenarReporteNotas()
        {
            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviTrasladosDiariosPCriterios(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString("12,16,19"), Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxBodegaDestino.Value)));//, Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(37)));
            Facturado.OpenReport(cachedReportSourceKardex);

        }
        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            cbxBodegaDestino.SelectedIndex = -1;
        }
    }
}