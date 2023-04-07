using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.producto
{
    public partial class UcVistaPRODUCTO : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CPRODUCTO Controlador = new CPRODUCTO();
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
            odsMARCA.DataBind();
            cbxMARCA.DataSourceID = "odsMARCA";
            cbxMARCA.DataBind();

            odsUNIDAD_MEDI_CONSAA.DataBind();
            cbxUNIDAD_MEDI_CONSAA.DataSourceID = "odsUNIDAD_MEDI_CONSAA";
            cbxUNIDAD_MEDI_CONSAA.DataBind();

            odsUNIDAD_MEDI_FAC.DataBind();
            cbxUNIDAD_MEDI_FAC.DataSourceID = "odsUNIDAD_MEDI_FAC";
            cbxUNIDAD_MEDI_FAC.DataBind();

            odsTIPO_PRODUCTO.DataBind();
            cbxTIPO_PRODUCTO.DataSourceID = "odsTIPO_PRODUCTO";
            cbxTIPO_PRODUCTO.DataBind();
        }
        private void CargarVista()
        {

            ModoEdicion(true);
            PRODUCTO Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_PRODUCTO.ToString();
                txtCODI_PRODUCTO.Text = Entidad.CODI_PRODUCTO;
                txtNOMBRE_PRODUCTO.Text = Entidad.NOMBRE_PRODUCTO;
                txtNOMBRE_KARDEX.Text = Entidad.NOMBRE_KARDEX;
                txtNOMBRE_VENTA.Text = Entidad.NOMBRE_VENTA;
                cbxTIPO_PRODUCTO.Value = Entidad.ID_TIPO_PROD;
                cbxUNIDAD_MEDI_CONSAA.Value = Entidad.ID_UNIDAD_CONSAA;
                cbxUNIDAD_MEDI_FAC.Value = Entidad.ID_UNIDAD_FAC;
                cbxMARCA.Value = Entidad.ID_MARCA;
                chkAPLICA_VTA.Checked = Entidad.APLICA_VTA;
                chkAPLICA_TRAS.Checked = Entidad.APLICA_TRAS;
                chkESTADO.Checked = Entidad.ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
            txtCODI_PRODUCTO.ClientEnabled = esEdicion;
            txtNOMBRE_PRODUCTO.ClientEnabled = esEdicion;
            txtNOMBRE_KARDEX.ClientEnabled = esEdicion;
            txtNOMBRE_VENTA.ClientEnabled = esEdicion;
            cbxTIPO_PRODUCTO.ClientEnabled = esEdicion;
            cbxUNIDAD_MEDI_CONSAA.ClientEnabled = esEdicion;
            cbxUNIDAD_MEDI_FAC.ClientEnabled = esEdicion;
            cbxMARCA.ClientEnabled = esEdicion;
            chkAPLICA_VTA.ClientEnabled = esEdicion;
            chkAPLICA_TRAS.ClientEnabled = esEdicion;
            chkESTADO.ClientEnabled = esEdicion;
        }

        public string Actualizar()
        {
            string Result = "";
            PRODUCTO Entidad = new PRODUCTO();
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
            Entidad.CODI_PRODUCTO = txtCODI_PRODUCTO.Text;
            Entidad.NOMBRE_PRODUCTO = txtNOMBRE_PRODUCTO.Text;
            Entidad.NOMBRE_KARDEX = txtNOMBRE_KARDEX.Text;
            Entidad.NOMBRE_VENTA = txtNOMBRE_VENTA.Text;
            Entidad.ID_TIPO_PROD = (int)cbxTIPO_PRODUCTO.Value;
            Entidad.ID_UNIDAD_CONSAA = (int)cbxUNIDAD_MEDI_CONSAA.Value;
            Entidad.ID_UNIDAD_FAC = (int)cbxUNIDAD_MEDI_FAC.Value;
            Entidad.ID_MARCA = (int)cbxMARCA.Value;
            Entidad.APLICA_TRAS = chkAPLICA_TRAS.Checked;
            Entidad.APLICA_VTA = chkAPLICA_VTA.Checked;
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
            txtCODI_PRODUCTO.Text = "";
            txtNOMBRE_PRODUCTO.Text = "";
            txtNOMBRE_KARDEX.Text = "";
            txtNOMBRE_VENTA.Text = "";
            cbxTIPO_PRODUCTO.Value = null;
            cbxUNIDAD_MEDI_CONSAA.Value = null;
            cbxUNIDAD_MEDI_FAC.Value = null;
            cbxMARCA.Value = null;
            chkAPLICA_VTA.Checked = false;
            chkAPLICA_TRAS.Checked = false;
        }
        #endregion
    }
}