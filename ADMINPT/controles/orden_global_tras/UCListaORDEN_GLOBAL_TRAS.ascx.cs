using ADMINPT.BL;
using ADMINPT.DL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.orden_global_tras
{
     public partial class UCListaORDEN_GLOBAL_TRAS : System.Web.UI.UserControl
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
            //gridLista.DataSourceID = "odsLista";
            gridLista.Selection.UnselectAll();
            gridLista.DataBind();
            
        }

        #endregion

        protected void gridLista_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
        //    ORDEN_GLOBAL_TRAS lEntidad = new CORDEN_GLOBAL_TRAS().ObtenerPorId((int)e.GetListSourceFieldValue("ID_ORDEN_TRAS"));
        //    if (lEntidad != null) { if (lEntidad.ESTADO == true) { e.Value = true; } else { e.Value = false; } } else { e.Value = false; }
        //}
            if (e.Column.FieldName == "AC")
            { if ((Boolean)e.GetListSourceFieldValue("ESTADO") == true) { e.Value = true; } else { e.Value = false; }
            }        
            else if (e.Column.FieldName == "FN")
            {  if ((int) e.GetListSourceFieldValue("ID_ESTADO") == 10) { e.Value = true; } else { e.Value = false; } 
            }
            else if (e.Column.FieldName == "TPREF")
            {
                TIPO_REF_TRAS lEntidad = new CTIPO_REF_TRAS().ObtenerPorId((int)e.GetListSourceFieldValue("ID_REF"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE;
            }
            else if (e.Column.FieldName == "BODEGAO")
            {
                BODEGA lEntidad = new CBODEGA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_BODEGAO"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE;
            }
            else if (e.Column.FieldName == "PRODUCTO")
            {
                PRODUCTO lEntidad = new CPRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRODUCTO"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_PRODUCTO;
            }
            else if (e.Column.FieldName == "BODEGAD")
            {
                BODEGA lEntidad = new CBODEGA().ObtenerPorId((int)e.GetListSourceFieldValue("ID_BODEGAD"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE;
            }
        }
    }
}
