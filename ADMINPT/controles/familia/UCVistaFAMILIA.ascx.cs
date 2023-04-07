using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.familia
{
    public partial class UCVistaFAMILIA : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CFAMILIA Controlador = new CFAMILIA();
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
            FAMILIA Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_FAMILIA.ToString();
                txtNOMBRE_FAMILIA.Text = Entidad.NOMBRE_FAMILIA;
                chkESTADO.Value = Entidad.ESTADO;  
            }
        }

        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNOMBRE_FAMILIA.ClientEnabled = esEdicion;
            chkESTADO.ClientEnabled = esEdicion;  
        }

        public string Actualizar()
        {
            string Result = "";
            FAMILIA Entidad = new FAMILIA();
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
            Entidad.NOMBRE_FAMILIA = txtNOMBRE_FAMILIA.Text;
            Entidad.ESTADO = Convert.ToBoolean(chkESTADO.Value); 
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
            txtNOMBRE_FAMILIA.Text = "";
            chkESTADO.Value=true; 
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}