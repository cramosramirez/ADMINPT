using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.tipo_concepto
{
    public partial class UcVistaTIPO_CONCEPTO : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CTIPO_CONCEPTO Controlador = new CTIPO_CONCEPTO();
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
            TIPO_CONCEPTO Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_TIPO_CONCEPTO.ToString();
                txtNombreConcepto.Text = Entidad.NOMBRE_CONCEPTO;
                ckEsEntrada.Checked = Entidad.ES_ENTRADA;
                ckEsSalida.Checked = Entidad.ES_SALIDA;
                ckEstado.Checked = Entidad.ESTADO;
            }
        }

        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtNombreConcepto.ClientEnabled = esEdicion;
            ckEsEntrada.ClientEnabled = esEdicion;
            ckEsSalida.ClientEnabled = esEdicion;
            ckEstado.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            TIPO_CONCEPTO Entidad = new TIPO_CONCEPTO();
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
            Entidad.NOMBRE_CONCEPTO = txtNombreConcepto.Text;
            Entidad.ES_ENTRADA = ckEsEntrada.Checked;
            Entidad.ES_SALIDA = ckEsSalida.Checked;
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
            txtNombreConcepto.Text = "";
            ckEsEntrada.Checked = false;
            ckEsSalida.Checked = false;
            ckEstado.Checked = true;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}