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
    public partial class UcViewMovProduc : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "PRODUCCION";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            txt_fecha.Date = DateTime.Now;
            llenarTipoMovimientos();
            cbxTiposMovimientos.SelectedIndex = 0;
            llenarTurno();
            cbxHorario.SelectedIndex = 0;
            llenarProductoEntSalRpt();
            cbxProductoEntSalRpt.SelectedIndex = 0;
            llenarBodegaDestino();
            cbxDestino.SelectedIndex = 1;
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
            cbxTiposMovimientos.DataSource = CDats._CB_TIPOS_GENERALES(Convert.ToInt32(2), Convert.ToInt32(1));
            cbxTiposMovimientos.DataBind();
        }
        private void llenarTurno()
        { 
            cbxHorario.DataSource = CDats._CB_TURNO();
            cbxHorario.DataBind();
        }
        private void llenarProductoEntSalRpt()
        {
            cbxProductoEntSalRpt.DataSource = CDats._CB_PRODUCTO_ENT_SAL_RPT();
            cbxProductoEntSalRpt.DataBind();
        }
        private void llenarBodegaDestino()
        {
            cbxDestino.DataSource = CDats._CB_BODEGA_DESTINO_RPT();
            cbxDestino.DataBind();
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
            if (Convert.ToString(cbxTiposMovimientos.Text) != "")
            {
                //    if (Convert.ToInt32(cbxTiposMovimientos.Value) == 1)
                //    {
                if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 1)      //AZUCAR BLANCA 
                    {
                        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarima(Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToDateTime(txt_fecha.Value), Convert.ToString(cbxHorario.Value)));  
                        ProduccionRpt.OpenReport(cachedReportSourceKardex);
                        ProduccionRpt.Visible = true;
                    }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 2)      //AZUCAR CRUDO AGRANEL
                    {
                        //var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovBascula(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(cbxHorario.Text), Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToInt32(cbxDestino.Value)));
                        //MovimientoRpt.OpenReport(cachedReportSourceKardex);
                    }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 3)      //AZUCAR MORENO EXPORTACION
                    {
                        //var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovBascula(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(cbxHorario.Text), Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToInt32(cbxDestino.Value)));
                        //MovimientoRpt.OpenReport(cachedReportSourceKardex);
                    }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 4)      //AZUCAR MORENO LOCAL
                    {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProduccionTarima(Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToDateTime(txt_fecha.Value), Convert.ToString(cbxHorario.Value)));
                    ProduccionRpt.OpenReport(cachedReportSourceKardex);
                    ProduccionRpt.Visible = true;
                }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 5)     //MELAZA
                    {
                        //var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovBascula(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(cbxHorario.Text), Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToInt32(cbxDestino.Value)));
                        //MovimientoRpt.OpenReport(cachedReportSourceKardex);
                    }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 6)     //AZUCAR MORENO JUMBO LOCAL
                    {
                    var cachedReportSourceKardex = new CachedReportSourceWeb(new RptProducJumboBulto(Convert.ToString(cbxHorario.Value), Convert.ToDateTime(txt_fecha.Value), Convert.ToInt32(cbxProductoEntSalRpt.Value)));
                    ProduccionRpt.OpenReport(cachedReportSourceKardex);
                }
                    if (Convert.ToInt32(cbxProductoEntSalRpt.Value) == 7)     //AZUCAR MORENO JUMBO EXPORTACION
                    {
                        //var cachedReportSourceKardex = new CachedReportSourceWeb(new RptMovBascula(Convert.ToDateTime(txt_fechad.Text), Convert.ToDateTime(txt_fechah.Text), Convert.ToString(cbxHorario.Text), Convert.ToInt32(cbxTiposMovimientos.Value), Convert.ToInt32(cbxProductoEntSalRpt.Value), Convert.ToInt32(cbxDestino.Value)));
                        //MovimientoRpt.OpenReport(cachedReportSourceKardex);
                    }
                //}
            }
        }
        protected void cbxTiposMovimientos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
