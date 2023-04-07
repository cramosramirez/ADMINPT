﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.producto
{
    public partial class UcListaPRODUCTO : System.Web.UI.UserControl
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
            if (e.Column.FieldName == "TIPO_PRODUCTO")
            {
                TIPO_PRODUCTO lEntidad = new CTIPO_PRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_TIPO_PROD"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_TIPO;
            }
            else if (e.Column.FieldName == "UNIDAD_CONSAA")
            {
                UNIDAD_MEDI_CONSAA lEntidad = new CUNIDAD_MEDI_CONSAA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_UNIDAD_CONSAA"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_UNIDAD;
            }
            else if (e.Column.FieldName == "UNIDAD_FAC")
            {
                UNIDAD_MEDI_FAC lEntidad = new CUNIDAD_MEDI_FAC().ObtenerPorId((int)e.GetListSourceFieldValue("ID_UNIDAD_FAC"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_UNIDAD;
            }
            else if (e.Column.FieldName == "MARCA")
            {
                MARCA lEntidad = new CMARCA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_MARCA"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_MARCA;
            }
        }
    }
}