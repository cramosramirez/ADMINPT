using DevExpress.Web;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza.TanqueNivel
{
    public partial class UcMantNivel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["USUARIO"]) != "")
            {
                UCBarraNavegacion.Salir_Click += _btn_salir_Click;
                UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
                if (!IsPostBack)
                {
                    UCBarraNavegacion.btn_nuevo.Visible = false;
                    UCBarraNavegacion.btn_reporte.Visible = true;
                    UCEncabezado.Titulo = "MEDIDAS DE TANQUE MELAZA";

                    UCCriterios.ContFechas.Visible = true;
                    UCCriterios.dteFechaInicial.Value = DateTime.Now;
                    UCCriterios.dteFechaFinal.Value = DateTime.Now;
                    BodeRpt.Visible = false;
                }
                else
                {
                    if (Convert.ToString(Session["VER_RPT"]) == "SI")
                    {

                        llenarReporteNotas();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            Session["VER_RPT"] = "SI";
            if (Convert.ToString(Session["VER_RPT"]) == "SI")
            {

                llenarReporteNotas();
            }
        }
        public void llenarReporteNotas()
        {
            if (Convert.ToString(UCCriterios.dteFechaInicial.Text) != "" && Convert.ToString(UCCriterios.dteFechaFinal.Text) != "")
            {
                var cachedReportSourceKardex = new CachedReportSourceWeb(new RptNivelTanqueMelaza(Convert.ToDateTime(UCCriterios.dteFechaInicial.Value), Convert.ToDateTime(UCCriterios.dteFechaFinal.Value)));
                BodeRpt.OpenReport(cachedReportSourceKardex);
                BodeRpt.Visible = true;
            }
        }
        protected void dgvNivel_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            if (e.NewValues["FECHA"] != null) { }
            else
            { throw new cCallbackException("Fecha Requerido!!!!"); }
            if (e.NewValues["HORA"] != null) { }
            else
            { throw new cCallbackException("Hora Requerido!!!!"); }
            if (e.NewValues["NIVEL"] != null) { }
            else
            { throw new cCallbackException("Nivel Requerido!!!!"); }

            if (e.NewValues["TEMP1"] != null) { }
            else
            { throw new cCallbackException("Temperatura 1 Requerido!!!!"); }

            if (e.NewValues["TEMP2"] != null) { }
            else
            { throw new cCallbackException("Temperatura 2 Requerido!!!!"); }

            //if (e.NewValues["PROMEDIO"] != null) { }
            //else
            //{ throw new cCallbackException("Promedio Requerido!!!!"); }
        }

        protected void dgvNivel_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            dgvNivel.SettingsText.PopupEditFormCaption = "Nueva Medida";
            ASPxGridView gridView = sender as ASPxGridView;

            foreach (GridViewColumn col in gridView.Columns)
            {
                if (col is GridViewDataCheckColumn)
                {
                    GridViewDataColumn column = col as GridViewDataColumn;
                    e.NewValues[column.FieldName] = true;
                }
            }
        }
        protected void dgvNivel_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            dgvNivel.SettingsText.PopupEditFormCaption = "Editar Medida";
        }

    }
}