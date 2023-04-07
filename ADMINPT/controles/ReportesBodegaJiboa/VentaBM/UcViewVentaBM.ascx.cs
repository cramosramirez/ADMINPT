using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.ReportesBodegaJiboa.VentaBM
{
    public partial class UcViewVentaBM : System.Web.UI.UserControl
    {
        private void Inicializar()
        {

            if (Convert.ToString(Session["USUARIO"]) != "")
            {
                UCEncabezado.Titulo = "VENTA Y TRASLADO DE AZUCAR  BLANCA Y MORENA";
                UCBarraNavegacion.btn_nuevo.Visible = false;
                UCBarraNavegacion.btn_reporte.Visible = true;
                dteFechaInicial.Date = DateTime.Now;
                dteFechaFinal.Date = DateTime.Now;
              
                llenarZafra();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
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
                llenarReporte();
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        private void llenarZafra()
        {
            cbxZafra.DataSource = CDats._CB_ZAFRA();
            cbxZafra.DataBind();
            ObtenerZafraActiva();
        }

        private void ObtenerZafraActiva()
        {
            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._CB_ZAFRA_ACTIVA();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    cbxZafra.Text = Convert.ToString(row["NOMBRE_ZAFRA"].ToString());
                }
                else
                {
                    //txtProducto.Text = string.Empty;
                }

                Conn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
            }
            catch (Exception sqlEx)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
            }
            finally
            {
                Conn.cn.Close();
            }
        }
        public void llenarReporte()
        {
            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptVentasBM(29,Convert.ToDateTime(dteFechaInicial.Value), Convert.ToDateTime(dteFechaFinal.Value), "12,14,16",Convert.ToInt32(cbxZafra.Value)));
            MovimientoRpt.OpenReport(cachedReportSourceKardex);
        }
    }
}
