using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.DigitalizacionRpt
{
    public partial class UcConsultaDoc : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "CONSULTA DE DOCUMENTOS DIGITALES";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_buscar.Visible = true;

            txt_fechad.Date = DateTime.Now;
            txt_fechah.Date = DateTime.Now;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Buscar_Click += _btn_buscar_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_buscar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }
        private void llenarGrid()
        {
            SqlDataAdapter Da = new SqlDataAdapter("LIST_DOC_MOV", Conn.cn);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.AddWithValue("@ID_TIPO", rdOpciones.SelectedItem.Value);
            Da.SelectCommand.Parameters.AddWithValue("@BODEGA",Convert.ToInt32(Session["ID_BODEP"]));
            Da.SelectCommand.Parameters.AddWithValue("@FECHAD", Convert.ToDateTime(txt_fechad.Value));
            Da.SelectCommand.Parameters.AddWithValue("@FECHAH", Convert.ToDateTime(txt_fechah.Value));
            DataTable datos = new DataTable();
            Da.Fill(datos);
            Dgv_List.DataSource = datos;
            Dgv_List.DataBind();
        }
        //protected void _btn_reporte_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //        Conn.cn.Close();
        //        Conn.cn.Open();
        //        DataTable Dt;
        //        Dt = CDats.VIEW_ID_ENTRADA_SALIDA_ENCA(Convert.ToDateTime(txt_fechad.Text), Convert.ToInt32(txtNDocumento.Text));
        //        if (Dt.Rows.Count > 0)
        //        {
        //            DataRow row = Dt.Rows[0];

        //            llenarReporteNotas(Convert.ToInt32(row["ID_ES_ENCA"].ToString()));

        //        }
        //        else
        //        {

        //        }

        //        Conn.cn.Close();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //public void llenarReporteNotas(int id)
        //{
        //    if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 1) //TRASLADO
        //    {
        //        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaMelazaD(Convert.ToInt32(id)));
        //        Facturado.OpenReport(cachedReportSourceKardex);
        //    }
        //    else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 2) // AZUCAR JIBOA
        //    {
        //        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboaD(Convert.ToInt32(id)));
        //        Facturado.OpenReport(cachedReportSourceKardex);
        //    }
        //    else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 3) // AZUCAR JIBOA EMPACADA
        //    {
        //        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboaD(Convert.ToInt32(id)));
        //        Facturado.OpenReport(cachedReportSourceKardex);
        //    }
        //    else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 4) // MELAZA JIBOA
        //    {
        //        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaVJiboaD(Convert.ToInt32(id)));
        //        Facturado.OpenReport(cachedReportSourceKardex);
        //    }
        //    else if (Convert.ToInt32(rdOpciones.SelectedItem.Value) == 5) // TRASLADO - DIZUCAR CENTRAL
        //    {
        //        var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNotaDizucarD(Convert.ToInt32(id)));
        //        Facturado.OpenReport(cachedReportSourceKardex);
        //    }

        //}
    }
}
