using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.tipo_concepto_prod
{
    public partial class UcVistaTIPO_CONCEPTO_PROD : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CTIPO_CONCEPTO_PROD Controlador = new CTIPO_CONCEPTO_PROD();
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

        private void CargarListas()
        {
            odsTIPO_CONCEPTO.DataBind();
            cbxTipoConcepto.DataSourceID = "odsTIPO_CONCEPTO";
            cbxTipoConcepto.DataBind();

            odsTIPO_PRODUCTO.DataBind();
            cbxTipoProducto.DataSourceID = "odsTIPO_PRODUCTO";
            cbxTipoProducto.DataBind();
        }
        private void CargarVista()
        {
            ModoEdicion(true);
            TIPO_CONCEPTO_PROD Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_CONCEPTO_PROD.ToString();
                cbxTipoConcepto.Value = Entidad.ID_TIPO_CONCEPTO;
                cbxTipoProducto.Value = Entidad.ID_TIPO_PROD;
                chkESTADO.Checked = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            cbxTipoConcepto.ClientEnabled = esEdicion;
            cbxTipoProducto.ClientEnabled = esEdicion;
            chkESTADO.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            TIPO_CONCEPTO_PROD Entidad = new TIPO_CONCEPTO_PROD();
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
            Entidad.ID_TIPO_CONCEPTO = (int)cbxTipoConcepto.Value;
            Entidad.ID_TIPO_PROD = (int)cbxTipoProducto.Value;
            Entidad.ESTADO = chkESTADO.Checked;

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
            CargarListas();
            txtIdentificador.Text = "";
            cbxTipoConcepto.Value = null;
            cbxTipoProducto.Value = null;
            chkESTADO.Checked = true;
        }
        #endregion
    }
}