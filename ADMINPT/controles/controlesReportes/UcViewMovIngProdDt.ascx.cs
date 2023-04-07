using ADMINPT.controles.movimientos_bulto.dsproduccion;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.controles.movimientos_bulto.dsproduccion;

namespace ADMINPT.controles.controlesReportes
{
    public partial class UcViewMovIngProdDt : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "REPORTE DE INGRESOS DE PRODUCCION DETALLE";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
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
                llenarReport();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void llenarTipoMovimientos()
        {
            cbxTiposMovimientos.DataSource = CDats._CB_PRODUCTO_PRODUCIONDT();
            cbxTiposMovimientos.DataBind();
            cbxTiposMovimientos.SelectedIndex = 0;
        }
        public void llenarReport()
        {
            if ((Convert.ToInt32(cbxTiposMovimientos.Value)==1) || (Convert.ToInt32(cbxTiposMovimientos.Value) == 20) || (Convert.ToInt32(cbxTiposMovimientos.Value) == 21))
            {
            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarimadt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
            MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 2)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new Rpt_ProdCrudaCamionF(Convert.ToInt32(29), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value), Convert.ToString(0)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 3)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarimadt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 4)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarimadt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 5) //MELAZA
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionMelazadt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 6) //JUMBO
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProducJumboBultodt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 7) //JUMBO
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProducJumboBultodt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(cbxTiposMovimientos.Value) == 8) //JUMBO
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProducJumboBultodt(Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToDateTime(txt_fechad.Value), Convert.ToDateTime(txt_fechah.Value)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
        }
        protected void cbxTiposMovimientos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
