using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.reporte
{
    public partial class UcMovimientosRpt : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "MOVIMIENTOS";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
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
                llenarReporteNotas();
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void llenarTipoMovimientos()
        {
            cbxTiposMovimientos.DataSource= CDats._CB_TIPOS_GENERALES(Convert.ToInt32(1), Convert.ToInt32(1));
            cbxTiposMovimientos.DataBind();
        }
        //public void EncDt()
        //{
        //    try
        //    {
        //        if (Convert.ToString(txt_Identificador.Text) == "lbIdentificadorEncT")
        //        {
        //            _btn_nuevo_Click(null, null);
        //        }
        //        else
        //        {
        //            Conn.cn.Close();
        //            Conn.cn.Open();
        //            DataTable Dt;
        //            Dt = CDats._SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T(Convert.ToInt32(lbIdentificadorEncT.Text));
        //            if (Dt.Rows.Count > 0)
        //            {
        //                DataRow row = Dt.Rows[0];
        //                // cbEstado.SelectedValue = Convert.ToInt32(row["ID_ESTADO"].ToString());
        //                //txtNdocumento.Text = Convert.ToString(row["NUM_DOC"].ToString());
        //                cbxProducto.Value = Convert.ToInt32(row["ID_PRODUCTO"].ToString());
        //                cbxProducto_TextChanged(null, null);
        //                cbxZafraProd.Value = Convert.ToInt32(row["ID_ZAFRA_PROD"].ToString());
        //                cbxZafraActual.Value = Convert.ToInt32(row["ID_ZAFRA_ACTUAL"].ToString());
        //                cbxtipoMovimiento.Value = Convert.ToInt32(row["ID_TIPO_MOV"].ToString());

        //                cbxConceptoTM.Value = Convert.ToInt32(row["ID_CONCE"].ToString());

        //                cbxEspecifico.Value = Convert.ToInt32(row["ID_ESPECI"].ToString());

        //                cbxBodegaOrigen.Value = Convert.ToInt32(row["ID_BODEGAO"].ToString());

        //                cbxBodegaDestino.Value = Convert.ToInt32(row["ID_BODEGAD"].ToString());


        //                dteFecha.Date = DateTime.Now;

        //            }
        //            else
        //            {
        //                _btn_nuevo_Click(null, null);
        //            }

        //            Conn.cn.Close();
        //        }
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        Conn.cn.Close();
        //    }
        //}

        public void llenarReporteNotas()
        {
            if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 12)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovimentos(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(37)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 14)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovimentos(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(42)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
            else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 16)
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovimentos(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToInt32(rdOpciones.SelectedItem.Value), Convert.ToInt32(33)));
                MovimientoRpt.OpenReport(cachedReportSourceKardex);
            }
        }

        protected void cbxTiposMovimientos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}