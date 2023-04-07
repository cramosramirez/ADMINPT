using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;


namespace ADMINPT.controles.tipo_producto
{
    public partial class UcVistaTIPO_PRODUCTO : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CTIPO_PRODUCTO Controlador = new CTIPO_PRODUCTO();
        public int Identificador
        {
            get
            {
                if (ViewState["Identificador"] == null) { return 0; } else { return Convert.ToInt32(ViewState["Identificador"]); }
            }
            set
            {
                if (ViewState["Identificador"] == null)
                    ViewState.Add("Identificador", value);
                else
                    ViewState["Identificador"] = value;
                Nuevo();
                if (value > 0)
                {
                    CargarVista();
                }
            }
        }

        private void CargarFamilias()
        {
            odsFAMILIA.DataBind();
            cbxFAMILIA.DataSourceID = "odsFAMILIA";
            cbxFAMILIA.DataBind();
             
        }
        private void CargarVista()
        {

            ModoEdicion(true);
            TIPO_PRODUCTO Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {               
                txtIdentificador.Text = Entidad.ID_FAMILIA.ToString();
                txtNOMBRE_TIPO.Text = Entidad.NOMBRE_TIPO;
                cbxFAMILIA.Value = Entidad.ID_FAMILIA;
                ckEstado.Value = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNOMBRE_TIPO.ClientEnabled = esEdicion;
            cbxFAMILIA.ClientEnabled = esEdicion;
            ckEstado.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            TIPO_PRODUCTO Entidad = new TIPO_PRODUCTO();
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
            Entidad.NOMBRE_TIPO = txtNOMBRE_TIPO.Text;
            Entidad.ID_FAMILIA = (int)(cbxFAMILIA.Value);
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
            txtNOMBRE_TIPO.Text = "";
            ckEstado.Checked = true;
            CargarFamilias();
            cbxFAMILIA.Value = null;            
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}