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
    public partial class UcViewMovIngProd : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "REPORTE DE INGRESOS DE PRODUCCION";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporteConta.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
            //llenarTipoMovimientos();
            //llenarTurno();
            //cbxHorario.SelectedIndex = 0;
            //llenarProductoEntSalRpt();
            //cbxProductoEntSalRpt.SelectedIndex = 0;
            //llenarBodegaDestino();
            //cbxDestino.SelectedIndex = 0;
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
            cbxTiposMovimientos.SelectedIndex = 0;
        }
        public void llenarReport()
        {
            //if (Convert.ToString(txt_fechad.Text) != "" && Convert.ToString(txt_fechad.Text) != "")
            //{
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovIngProd(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            //}
            //else if (Convert.ToString(txt_fechah.Text) != "")
            //{

            //}
        }
        protected void cbxTiposMovimientos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
