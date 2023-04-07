using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ADMINPT.controles.Facturado
{
    public partial class UcViewMovientosSalida : System.Web.UI.UserControl
    {
      

        private void Inicializar()
        {
            UCEncabezado.Titulo = "MOVIMIENTOS DE SALIDA DE BODEGA";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
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
                System.Threading.Thread.Sleep(8000);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void llenarReporteNotas()
        {
           
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMoviSalidas(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text)));//, Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(37)));
                Facturado.OpenReport(cachedReportSourceKardex);
          
        }
    }
}