using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.unidad_medi_consaa
{
    public partial class UCVistaUNIDAD_MEDI_CONSAA : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CUNIDAD_MEDI_CONSAA Controlador = new CUNIDAD_MEDI_CONSAA();
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
            UNIDAD_MEDI_CONSAA Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_UNIDAD_CONSAA.ToString();
                txtNOMBRE_UNIDAD.Text = Entidad.NOMBRE_UNIDAD;
                speFACTOR.Value= Convert.ToDouble(Entidad.FACTOR);
                chkESTADO.Value = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNOMBRE_UNIDAD.ClientEnabled = esEdicion;
            speFACTOR.ClientEnabled= esEdicion;
            chkESTADO.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            UNIDAD_MEDI_CONSAA Entidad = new UNIDAD_MEDI_CONSAA();
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
            Entidad.NOMBRE_UNIDAD = txtNOMBRE_UNIDAD.Text;
            Entidad.FACTOR = Convert.ToDouble(speFACTOR.Value);
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
            txtNOMBRE_UNIDAD.Text = "";
            speFACTOR.Value = 0;
            chkESTADO.Value = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}