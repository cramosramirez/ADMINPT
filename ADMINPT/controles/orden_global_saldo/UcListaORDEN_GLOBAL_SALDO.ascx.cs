using ADMINPT.BL;
using ADMINPT.DL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.orden_global_saldo
{
    public partial class UcListaORDEN_GLOBAL_SALDO : System.Web.UI.UserControl
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


        public void CargarDatos()
        {
            odsLista.DataBind();
            gridLista.DataSourceID = "odsLista";
            gridLista.Selection.UnselectAll();
            gridLista.DataBind();
        }

        #endregion

        protected void gridLista_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "NOMBRE")
            {
                SOLICITANTE lEntidad = new CSOLICITANTE().ObtenerPorId((int)e.GetListSourceFieldValue("ID_SOLICITANTE"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE;
            }
            //else if (e.Column.FieldName == "NOMBRE_PRODUCTO")
            //{
            //    PRODUCTO lEntidad = new CPRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRODUCTO"));
            //    if (lEntidad != null)
            //        e.Value = lEntidad.NOMBRE_PRODUCTO;
            //}
        }
    }
}
