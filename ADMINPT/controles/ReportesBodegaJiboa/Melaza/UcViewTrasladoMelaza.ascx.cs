using ADMINPT.controles.movimiento_traslado.traslados;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza
{
    public partial class UcViewTrasladoMelaza : System.Web.UI.UserControl
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
            cbxProducto.SelectedIndex = 4;
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
            if (Convert.ToString(Session["USUARIO"]) != "")
            {
                if (!IsPostBack)
                {
                    cbxZafra.DataBind();
                    cbxZafra.Text = ObtenerZafraActiva();
                }
                else
                {
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

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
        private string ObtenerZafraActiva()
        {
           string nombreZafra = "";
            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._CB_ZAFRA_ACTIVA();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];

                    nombreZafra = Convert.ToString(row["NOMBRE_ZAFRA"].ToString());
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
            return nombreZafra;
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
            var cachedReportSourceKardex = new CachedReportSourceWeb(new RptTrasladosMelaza(Convert.ToInt32(cb_bodegaO.Value), Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString("12,16,19"), Convert.ToInt32(cbxBodegaDestino.Value), Convert.ToInt32(cbxZafra.Value)));//, Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(37)));
            Facturado.OpenReport(cachedReportSourceKardex);

        }
        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            cbxBodegaDestino.DataBind();
        }
    }
}
