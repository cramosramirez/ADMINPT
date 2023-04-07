using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ADMINPT.RptDia
{
    public partial class UcRptDia : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "INFORME DIARIO DE MOVIMIENTOS DE INVENTARIOS - POR ZAFRA";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporteConta.Visible = true;
            txt_fechad.Date = DateTime.Now;
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
               llenarReporteNotas(txt_fechad.Date);
                Conn.cn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void llenarReporteNotas(DateTime fde)
        {
            if (chk_consolidado.Checked==false)
                { 
            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovDiaZafra(Convert.ToInt32(cb_bodegaO.Value), Convert.ToInt32(cb_zafra.Value), Convert.ToDateTime(fde)));
            Facturado.OpenReport(cachedReportSourceKardex);
            } else
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovDiaZafraF( Convert.ToInt32(cb_zafra.Value), Convert.ToDateTime(fde)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }



        }
    }
}