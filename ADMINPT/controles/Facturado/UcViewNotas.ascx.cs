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
    public partial class UcViewNotas : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "CONSULTA DE DOCUMENTOS";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
           
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

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats.VIEW_ID_ENTRADA_SALIDA_ENCA(Convert.ToDateTime(txt_fechad.Text),Convert.ToInt32(txtNDocumento.Text));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];

                    llenarReporteNotas(Convert.ToInt32(row["ID_ES_ENCA"].ToString()));

                }
                else
                {

                }

                Conn.cn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void llenarReporteNotas(int id)
        {
            if (Convert.ToInt32(rdOpciones.SelectedItem.Value)==1) //TRASLADO
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaMelaza(Convert.ToInt32(id)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 2) // AZUCAR JIBOA
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboa(Convert.ToInt32(id)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 3) // AZUCAR JIBOA EMPACADA
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboa(Convert.ToInt32(id)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 4) // MELAZA JIBOA
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboa(Convert.ToInt32(id)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 5) // TRASLADO - DIZUCAR CENTRAL
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaDizucar(Convert.ToInt32(id)));
                Facturado.OpenReport(cachedReportSourceKardex);
            }

        }
    }
}