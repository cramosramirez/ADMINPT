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
    public partial class UcViewMovientosDizucarPeriodo : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "TRASLADOS A CUENTA DIZUCAR POR PERIODO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporteConta.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodega.Enabled = true; }
            else { cb_bodega.Value = ibog; }
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
                llenarReporteNotas();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void llenarReporteNotas()
        {
            var ID_CONCE = 12;
            if (Convert.ToInt32(cb_movimiento.Value) == 27)
            { ID_CONCE = 16; }
            else { ID_CONCE = 12; }

            int bd = 0;
           


                if (Convert.ToInt32(cb_bodega.Value) == 29)
            {
                if (Convert.ToInt32(cb_movimiento.Value) == 27)
                { bd = 27; }
                else { bd = Convert.ToInt32(cb_movimiento.Value); }

                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviTrasladosDiariosP(Convert.ToInt32(cb_bodega.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(ID_CONCE), Convert.ToInt32(bd)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cb_bodega.Value) == 16)
            {
                if (Convert.ToInt32(cb_movimiento.Value) == 27)
                { bd = 26; }
                else { bd = Convert.ToInt32(cb_movimiento.Value); }
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviTrasladosDiariosP(Convert.ToInt32(cb_bodega.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(ID_CONCE), Convert.ToInt32(bd)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            
           

        }
    }
}