using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.marca
{
    public partial class UcVistaMARCA : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CMARCA Controlador = new CMARCA();
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
            MARCA Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_MARCA.ToString();
                txtNombre.Text = Entidad.NOMBRE_MARCA;
                ckEstado.Checked = Entidad.ESTADO;
            }
        }

        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNombre.ClientEnabled = esEdicion;
            ckEstado.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            MARCA Entidad = new MARCA();
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
            Entidad.NOMBRE_MARCA = txtNombre.Text;
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
            txtNombre.Text = "";
            ckEstado.Checked = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}