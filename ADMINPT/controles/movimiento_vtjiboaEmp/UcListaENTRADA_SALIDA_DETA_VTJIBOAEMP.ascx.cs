using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.movimiento_vtjiboaEmp
{
    public partial class UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP : System.Web.UI.UserControl
    {
        #region "Propiedades genericas"

        public event Action<int> Editando;

        public bool MostrarCheckUnaSeleccion
        {
            get { return gridLista.SettingsBehavior.AllowSelectSingleRowOnly; }
            set
            {
                gridLista.Columns["CheckSeleccionar"].Visible = value;
                gridLista.SettingsBehavior.AllowSelectSingleRowOnly = true;
            }
        }
        public bool MostrarCheckVariaSeleccion
        {
            get { return gridLista.Columns["CheckSeleccionar"].Visible; }
            set { gridLista.Columns["CheckSeleccionar"].Visible = value; }
        }
        public bool PermitirEditar
        {
            get
            {
                if (ViewState["PermitirEditar"] == null) { return false; } else { return Convert.ToBoolean(ViewState["PermitirEditar"]); }
            }
            set
            {
                if (ViewState["PermitirEditar"] == null) { ViewState.Add("PermitirEditar", value); } else { ViewState["PermitirEditar"] = value; }
            }
        }
        protected void gridLista_Init(object sender, EventArgs e)
        {
            gridLista.Columns["Editar"].Visible = PermitirEditar;
        }
        protected void gridLista_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "Editar")
            {
                Editando((int)e.KeyValue);
            }
        }

        public DevExpress.Web.ASPxGridView _gridLista
        {
            get { return gridLista; }
            set { gridLista = value; }
        }

        #endregion

        protected void gridLista_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "NOMBRE_PRODUCTO")
            {
                PRODUCTO lEntidad = new CPRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRODUCTO"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_KARDEX;
            }
            else if (e.Column.FieldName == "NOMBRE_PRESEN_TRAA")
            {
                PRESENTACION_TRAS lEntidad = new CPRESENTACION_TRAS().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRESEN_TRAS"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_PRESEN_TRAA;
            }
            else if (e.Column.FieldName == "NOMBRE_UNIDAD")
            {
                UNIDAD_MEDI_FAC lEntidad = new CUNIDAD_MEDI_FAC().ObtenerPorId((int)e.GetListSourceFieldValue("ID_UNIDAD_FAC"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_UNIDAD;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridLista_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //try
            //{
            //    // Lee el DataTable
            //    DataTable DT = (DataTable)Session["DT"];
            //    // Elimina el registro
            //    DT.Rows.RemoveAt((int)e.Keys[gridLista.KeyFieldName]);
            //    Session["DT"] = DT;
            //    // Muestra los registros
            //    gridLista.DataSource = DT;
            //    gridLista.DataBind();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        protected void gridLista_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }
    }
}