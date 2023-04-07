using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimientos_bulto
{
    public partial class UcViewMovientosPeriodo : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "TRASLADOS POR PERIODO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            if (Convert.ToInt32(Session["ID_BODEP"]) == 1)
            { ibog = 29; }
            else if (Convert.ToInt32(Session["ID_BODEP"]) == 2)
            { ibog = 17; }
            else if (Convert.ToInt32(Session["ID_BODEP"]) == 3)
            { ibog = 16; }
            cb_bodegaO.Value = ibog;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
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
            if (Convert.ToInt32(Session["ID_BODEP"]) == 1)
            { ibog = 29; }
            else if (Convert.ToInt32(Session["ID_BODEP"]) == 2)
            { ibog = 17; }
            else if (Convert.ToInt32(Session["ID_BODEP"]) == 3)
            { ibog = 16; }
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
            //var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviTrasladosDiariosP(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString("12,16,19"), 0));//, Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(37)));
           // Facturado.OpenReport(cachedReportSourceKardex);

        }
    }
}