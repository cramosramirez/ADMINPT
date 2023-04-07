using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.producto_pres_tras
{
    public partial class UcVistaPRODUCTO_PRES_TRAS : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CPRODUCTO_PRES_TRAS Controlador = new CPRODUCTO_PRES_TRAS();
        public int Identificador
        {
            get
            {
                if (ViewState["Identificador"] == null) { return 0; } else { return Convert.ToInt32(ViewState["Identificador"]); }
            }
            set
            {
                if (ViewState["Identificador"] == null)
                {
                    ViewState.Add("Identificador", value);
                }
                else
                {
                    ViewState["Identificador"] = value;
                }
                Nuevo();
                if (value > 0)
                {
                    CargarVista();
                }
            }
        }
        private void CargarVista()
        {

            ModoEdicion(true);
            PRODUCTO_PRES_TRAS Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                CargarDatos();
                txtIdentificador.Text = Entidad.ID_PROD_PRES_TRAS.ToString();
                cbProducto.Value = Entidad.ID_PRODUCTO;
                cbPresentaciontras.Value = Entidad.ID_PRESEN_TRAS;
                ckEstado.Checked = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            cbProducto.ClientEnabled = esEdicion;
            cbPresentaciontras.ClientEnabled = esEdicion;
            ckEstado.ClientEnabled = esEdicion;
        }
        public string Actualizar()
        {
            string Result = "";
            PRODUCTO_PRES_TRAS Entidad = new PRODUCTO_PRES_TRAS();
            if (Identificador > 0)
            {
                Entidad = Controlador.ObtenerPorId(Identificador);
                Entidad.USUARIO_ACT = CUTILERIAS.ObtenerUsuario();
            }
            else
            {
                Entidad.USUARIO_CREA = CUTILERIAS.ObtenerUsuario();
            }
            // Seteando la entidad con los campos de la vista y actualizando mediante el controlador
            Entidad.ID_PRODUCTO = Convert.ToInt32(cbProducto.Value);
            Entidad.ID_PRESEN_TRAS = Convert.ToInt32(cbPresentaciontras.Value);
            Entidad.ESTADO = ckEstado.Checked;
            Controlador.Actualizar(Entidad);
            Result = Controlador.sError;

            return Result;
        }
        public string Eliminar()
        {
            string Result = "";
            if (Identificador > 0)
            {
                Controlador.Eliminar(Identificador);
                Result = Controlador.sError;
            }
            return Result;
        }

        private void Nuevo()
        {
            txtIdentificador.Text = "";
            CargarDatos();
            cbProducto.SelectedIndex = -1;
            cbPresentaciontras.SelectedIndex = -1;
            ckEstado.Checked = true;
        }
        public void CargarDatos()
        {

            odsPRESENTACION_TRAS.DataBind();
            cbPresentaciontras.DataSourceID = "odsPRESENTACION_TRAS";
            cbPresentaciontras.DataBind();


            odsPRODUCTO.DataBind();
            cbProducto.DataSourceID = "odsPRODUCTO";
            cbProducto.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}