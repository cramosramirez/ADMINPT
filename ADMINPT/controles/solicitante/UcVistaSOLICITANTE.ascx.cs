using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.solicitante
{
      public partial class UcVistaSOLICITANTE : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CSOLICITANTE Controlador = new CSOLICITANTE();
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
            SOLICITANTE Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_SOLICITANTE.ToString();
                txtNombre.Text = Entidad.NOMBRE;
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
            SOLICITANTE Entidad = new SOLICITANTE();
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
            Entidad.NOMBRE = txtNombre.Text;
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
