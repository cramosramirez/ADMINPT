using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.kardex
{
    public partial class UcListaKARDEX : System.Web.UI.UserControl
    {
        #region "Propiedades genericas"

        public event Action<int>Editando;

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


        public void CargarDatos()
        {
            odsLista.DataBind();
            gridLista.DataSourceID = "odsLista";
            gridLista.Selection.UnselectAll();
            gridLista.DataBind();
        }

        protected void gridLista_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "NOMBRE_BODEGA")
            {
                BODEGA lEntidad = new CBODEGA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_BODEGAD"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE;
            }
            else if (e.Column.FieldName == "NOMBRE_ESPECI")
            {
                ESPECI_MOV lEntidad = new CESPECI_MOV().ObtenerPorId((int)e.GetListSourceFieldValue("ID_ESPECI"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_ESPECI;
            }
            else if (e.Column.FieldName == "NOMBRE_ZAFRA")
            {
                ZAFRA lEntidad = new CZAFRA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_ZAFRA_PROD"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_ZAFRA;
            }
            else if (e.Column.FieldName == "NOMBRE_PRODUCTO")
            {
                PRODUCTO lEntidad = new CPRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRODUCTO"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_PRODUCTO;
            }
        }
        #endregion
    }
}
