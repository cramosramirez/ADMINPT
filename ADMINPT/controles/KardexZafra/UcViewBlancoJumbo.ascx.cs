using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ADMINPT.controles.KardexZafra
{
    public partial class UcViewBlancoJumbo : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "KARDEX ZAFRA DE AZUCAR BLANCA JUMBO 27.18 QQ";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporteConta.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
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

                Conn.cn.Close();
                llenarReporteNotas(txt_fechad.Date, txt_fechah.Date);
                Conn.cn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void llenarReporteNotas(DateTime fde, DateTime fht)
        {

            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptBlancoJumboZafra(Convert.ToDateTime(fde), Convert.ToDateTime(fht), Convert.ToInt32(cb_bodegaO.Value), Convert.ToInt32(cb_zafra.Value), Convert.ToInt32(8)));
            Facturado.OpenReport(cachedReportSourceKardex);



        }
    }
}