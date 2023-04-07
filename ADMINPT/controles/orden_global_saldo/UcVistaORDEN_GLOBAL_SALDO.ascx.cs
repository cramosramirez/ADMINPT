using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.orden_global_saldo
{
    public partial class UcVistaORDEN_GLOBAL_SALDO : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CORDEN_GLOBAL_SALDO Controlador = new CORDEN_GLOBAL_SALDO();
        private CORDEN_GLOBAL_TRAS ControladorTras = new CORDEN_GLOBAL_TRAS();
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
            //ModoEdicion(true);
            //ORDEN_GLOBAL_SALDO Entidad = Controlador.ObtenerPorId(Identificador);
            //if (Entidad != null)
            //{
            //    txtIdentificador.Text = Entidad.ID_ORDEN_SALDO.ToString();
            //    cbxORDEN_GLOBAL_TRAS.Value = Entidad.ID_ORDEN_TRAS;
            //    cbxSolicitante.Value = Entidad.ID_SOLICITANTE;
            //    dteFecha.Value = Entidad.FECHA;
            //    speCantidadInicial.Value = Entidad.CANTIDAD_INICIAL;
            //    speSaldoAnterior.Value = Entidad.SALDO_ANTERIOR;
            //    speNuevoIngreso.Value = Entidad.NUEVO_INGRESO;
            //    speNuevoSaldo.Value = Entidad.NUEVO_SALDO;
            //    cbxestado.Value = Entidad.ID_ESTADO;
            //    ckEstado.Value = Entidad.ESTADO;
            //    txtObservacion.Text = Entidad.OBSERVACION;
            //}
            //ORDEN_GLOBAL_TRAS EntidadTras = ControladorTras.ObtenerPorId(Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value));
            //if (EntidadTras != null)
            //{
            //    //txtIdentificador.Text = EntidadTras.ID_ORDEN_TRAS.ToString();
            //    cbxProducto.Value = EntidadTras.ID_PRODUCTO;
            //    cbxTIPO_REF_TRAS.Value= EntidadTras.ID_REF;
            //    txtDocumento.Value = EntidadTras.NUMREF;
            //    cbxZafraProd.Value = EntidadTras.ID_ZAFRA_PROD;
            //}
            //cbxORDEN_GLOBAL_TRAS.ClientEnabled = false;
            ////txt_CodCaptura.Text = "0";
            //txtIdentificador.ClientEnabled = false;
            //dteFecha.ClientEnabled = false;
            //cbxSolicitante.ClientEnabled = false;
            //cbxProducto.ClientEnabled = false;
            //cbxTIPO_REF_TRAS.ClientEnabled = false;
            //cbxZafraProd.ClientEnabled = false;
            //speCantidadInicial.ClientEnabled = false;
            //speSaldoAnterior.ClientEnabled = false;
            //speNuevoIngreso.ClientEnabled = false;
            //speNuevoSaldo.ClientEnabled = false;
            //txtObservacion.ClientEnabled = false;
            //txtDocumento.ClientEnabled = false;
            //cbxestado.ClientEnabled = false;
        }
        private void CargarVistaOT()
        {

            ORDEN_GLOBAL_TRAS Entidad = ControladorTras.ObtenerPorId(Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value), Convert.ToInt32(Session["ID_BODEP"]));
            if (Entidad != null)
            {
                //txtIdentificador.Text = Entidad.ID_ORDEN_TRAS.ToString();
                //txt_CodCaptura.Text = Entidad.COD_CAPTURA.ToString();
                dteFecha.Value = Entidad.FECHA;
                cbxSolicitante.Value = Entidad.ID_SOLICITANTE;

                cbxProducto.Value = Entidad.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);




                cbxBodegaOrigen.Value = Entidad.ID_BODEGAO;
                cbxBodegaDestino.Value = Entidad.ID_BODEGAD;
                cbxtipoMovimiento.Value = Entidad.ID_TIPO_MOV;
                cbxConceptoTM.Value = Entidad.ID_CONCE;
                cbxEspecifico.Value = Entidad.ID_ESPECI;
                cbxTIPO_REF_TRAS.Value = Entidad.ID_REF;
                txtDocumento.Value = Entidad.NUMREF;
                cbxZafraProd.Value = Entidad.ID_ZAFRA_PROD;
                
                txtAsignacionO.Value = Convert.ToDouble(Entidad.ASIGNACIONO);
                txtAmpliaciones.Value = Convert.ToDouble(Entidad.AMPLIACIONES);
                txtAsignacionT.Value = Convert.ToDouble(Entidad.ASIGNACIONT);
                txtEjecutado.Value = Convert.ToDouble(Entidad.EJECUTADO);
                txtSaldo.Value = Convert.ToDouble(Entidad.SALDO);
                ckEstado.Value = Entidad.ESTADO;
                txtObservacion.Text = Entidad.OBSERVACION;
                rb_propio.Value = Entidad.ES_PROPIO;
                rb_Ajeno.Value = Entidad.ES_AJENO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;
           // txt_CodCaptura.ClientEnabled = esEdicion;
            dteFecha.ClientEnabled = esEdicion;
            cbxSolicitante.ClientEnabled = esEdicion;
            cbxTIPO_REF_TRAS.ClientEnabled = esEdicion;
            txtDocumento.ClientEnabled = esEdicion;
            cbxZafraProd.ClientEnabled = esEdicion;
            cbxProducto.ClientEnabled = esEdicion;
            ckEstado.ClientEnabled = esEdicion;
            txtObservacion.ClientEnabled = esEdicion;
        }
        public string Actualizar()
        {
            string Result = "";
            ORDEN_GLOBAL_SALDO Entidad = new ORDEN_GLOBAL_SALDO();
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


            Entidad.ID_ORDEN_TRAS = Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value);
            Entidad.FECHA = Convert.ToDateTime(dteFecha.Value);
            Entidad.NASIGNACIONO = Convert.ToInt32(speCantidad.Value);
            Entidad.ASIGNACIONO = Convert.ToDouble(txtAsignacionO.Value);
            Entidad.AMPLIACIONES = Convert.ToDouble(txtAmpliaciones.Value);
            Entidad.ASIGNACIONT = Convert.ToDouble(txtAsignacionT.Value);
            Entidad.EJECUTADO = Convert.ToDouble(txtEjecutado.Value);
            Entidad.SALDO = Convert.ToInt32(txtSaldo.Value);
            Entidad.OBSERVACION = txtObservacion.Text;


            Controlador.Actualizar(Entidad);
            Result = Controlador.sError;

            return Result;
        }
        private void Nuevo()
        {
            CargarListas();

            txtIdentificador.Text = "0";
            // txt_CodCaptura.Text = "0";
            dteFecha.Value = DateTime.Now;
            cbxSolicitante.Text = "";
            cbxBodegaOrigen.Text = "";
            cbxBodegaDestino.Text = "";
            //cbxtipoMovimiento.Text = "";
            //cbxConceptoTM.Text = "";
            //cbxEspecifico.Text = "";
            cbxTIPO_REF_TRAS.Text = "";
            txtDocumento.Text = "0";
            cbxZafraProd.Text = "";
            cbxProducto.Text = "";
            txtAsignacionO.Value = 0;
            txtAmpliaciones.Value = 0;
            txtAsignacionT.Value = 0;
            txtEjecutado.Value = 0;
            txtSaldo.Value = 0;
            //ckEstado.Text = "";
            txtObservacion.Text = "";
            // txt_CodCaptura.Focus();
            
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

        private void CargarListas()
        {
            odsSOLICITANTE.DataBind();
            cbxSolicitante.DataSourceID = "odsSOLICITANTE";
            cbxSolicitante.DataBind();
            cbxSolicitante.SelectedIndex = 1;

            odsTIPO_REF_TRAS.DataBind();
            cbxTIPO_REF_TRAS.DataSourceID = "odsTIPO_REF_TRAS";
            odsTIPO_REF_TRAS.DataBind();



            odsZAFRA_PROD.DataBind();
            cbxZafraProd.DataSourceID = "odsZAFRA_PROD";
            cbxZafraProd.DataBind();

            odsORDEN_GLOBAL_TRAS.DataBind();
            cbxORDEN_GLOBAL_TRAS.DataSourceID = "odsORDEN_GLOBAL_TRAS";
            cbxORDEN_GLOBAL_TRAS.DataBind();

            //DETALLE
            odsPRODUCTO.DataBind();
            cbxProducto.DataSourceID = "odsPRODUCTO";
            cbxProducto.DataBind();

            odsTIPO_MOVIMIENTO.DataBind();
            cbxtipoMovimiento.DataSourceID = "odsTIPO_MOVIMIENTO";
            cbxtipoMovimiento.DataBind();


            ZafraACtual();


        }

        private void ZafraACtual()
        {
            odsZAFRA_ACTUAL.DataBind();
            cbxZafraActual.DataSourceID = "odsZAFRA_ACTUAL";
            cbxZafraActual.DataBind();
            cbxZafraActual.SelectedIndex = 1;
        }
        //*******ASIGNA LA BODEGA QUE TIENE SALDO***//
        private void IdBodegaOrigen()
        {
            if (Convert.ToString(cbxProducto.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "")
            {
                odsBodegaOUser.DataBind();
               cbxBodegaOrigen.DataSourceID = "odsBodegaOUser";
                odsBodegaOUser.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
                cbxBodegaOrigen.DataBind();
                 cbxBodegaOrigen.SelectedIndex = 1;
            }
            else { }
        }
        private void IdBodegaDestino()
        {
            if (Convert.ToString(cbxProducto.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "")
            {
                odsBodegaDUser.DataBind();
                cbxBodegaDestino.DataSourceID = "odsBodegaDUser";
                odsBodegaDUser.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
                cbxBodegaDestino.DataBind();
                cbxBodegaDestino.SelectedIndex = -1;
            }
            else { }
        }

        private void CargarEspecificoMov()
        {
            cbxEspecifico.DataSourceID = "odsESPECI_MOV";
            odsESPECI_MOV.SelectParameters["id"].DefaultValue = cbxConceptoTM.Value.ToString();
            odsESPECI_MOV.DataBind();
            cbxEspecifico.DataBind();
            cbxEspecifico.SelectedIndex = 3;
        }

        private void CargarConceptosMovi()
        {
            if (Convert.ToString(cbxProducto.Text) == "" & Convert.ToString(cbxtipoMovimiento.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxtipoMovimiento.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxtipoMovimiento.Text) != "")
            {
                cbxConceptoTM.DataSourceID = "odsCONCEPTO_MOVI";
                odsCONCEPTO_MOVI.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
                odsCONCEPTO_MOVI.SelectParameters["ID_TIPO_MOV"].DefaultValue = cbxtipoMovimiento.Value.ToString();
                odsCONCEPTO_MOVI.DataBind();
                cbxConceptoTM.DataBind();
                cbxConceptoTM.SelectedIndex = 1;
                cbxConceptoTM_TextChanged(null, null);
            }
            else { }
        }
        private void CargarUnidida_Fac()
        {
            cbxUnidad.DataSourceID = "odsUNIDAD_MEDI_FAC";
            odsUNIDAD_MEDI_FAC.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsUNIDAD_MEDI_FAC.DataBind();
            cbxUnidad.DataBind();
            cbxUnidad.SelectedIndex = 1;
        }

        private void CargarPresentacion_tras()
        {
            cbxPrestanciontras.DataSourceID = "odsPRESENTACION_TRAS";
            odsPRESENTACION_TRAS.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsPRESENTACION_TRAS.DataBind();
            cbxPrestanciontras.DataBind();
            cbxPrestanciontras.SelectedIndex = 1;
        }

        protected void ObtenerFactor()
        {
            PRESENTACION_TRAS lEntidad = new CPRESENTACION_TRAS().ObtenerPorId(Convert.ToInt32(cbxPrestanciontras.Value));
            if (lEntidad != null)
            {

                speFactor.Value = lEntidad.FQQ;
                speFactorKg.Value = lEntidad.FKG;

            }
            if (lEntidad == null)
            {
                speFactor.Value = 0;
                speFactorKg.Value = 0;
            }
        }
        protected void ObtenerExistencia()
        {
            if (Convert.ToString(cbxProducto.Text) == "" & Convert.ToString(cbxZafraProd.Text) == "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) == "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) != "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) != "" & Convert.ToString(cbxBodegaOrigen.Text) != "")
            {
                KARDEX lEntidadK = new CKARDEX().ObtenerPorIdBodegaExist(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxZafraProd.Value), Convert.ToInt32(cbxBodegaOrigen.Value),Convert.ToDateTime(dteFecha.Text));
                if (lEntidadK != null)
                {
                    lblSaldo.Value = lEntidadK.EXISTENCIA_BODE;
                    lblSaldo.Visible = true;
                    lblPresentacion.Value = lEntidadK.PRESENTACION;
                }
                if (lEntidadK == null)
                {
                    lblSaldo.Value = 0.00;
                    lblPresentacion.Value = string.Empty;
                    lblSaldo.Visible = true;
                }
            }
        }

        protected void ObtenerdtBGDestino()
        {
            //PRESENTACION_TRAS lEntidad = new CPRESENTACION_TRAS().ObtenerPorId(Convert.ToInt32(cbxPrestanciontras.Value));
            BODEGA lEntidad = new CBODEGA().ObtenerPorId(Convert.ToInt32(cbxBodegaDestino.Value));
            if (lEntidad != null)
            {
                //txtNit.Text = lEntidad.NIT;
                //txtNrc.Text = lEntidad.NRC;
                //txtGiro.Text = lEntidad.GIRO;
                //txtDireccion.Text = lEntidad.DIRECCION;
                //txtDepartamento.Text = lEntidad.NOMDEPARTAMENTO;
                //txtMunicipio.Text = lEntidad.NOMMUNICIPIO;
            }
            if (lEntidad == null)
            {
                //txtNit.Text = string.Empty;
                //txtNrc.Text = string.Empty;
                //txtGiro.Text = string.Empty;
                //txtDireccion.Text = string.Empty;
                //txtDepartamento.Text = string.Empty;
                //txtMunicipio.Text = string.Empty;
            }
        }

        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            CargarUnidida_Fac();
            CargarPresentacion_tras();
            ObtenerFactor();
            IdBodegaOrigen();
            IdBodegaDestino();
            CargarConceptosMovi();
            ObtenerExistencia();
            cbxtipoMovimiento.SelectedIndex = 1;
            cbxtipoMovimiento_TextChanged(null, null);
        }
       
        protected void cbxtipoMovimiento_TextChanged(object sender, EventArgs e)
        {
            CargarConceptosMovi();
        }
        protected void cbxConceptoTM_TextChanged(object sender, EventArgs e)
        {
            CargarEspecificoMov();
        }

        protected void cbxBodegaOrigen_TextChanged(object sender, EventArgs e)
        {
            ObtenerExistencia();
        }

        protected void cbxBodegaDestino_TextChanged(object sender, EventArgs e)
        {
            ObtenerdtBGDestino();
        }
        protected void cbxZafraProd_TextChanged(object sender, EventArgs e)
        {
            IdBodegaOrigen();
            ObtenerExistencia();
        }
        protected void cbxTIPO_REF_TRAS_TextChanged(object sender, EventArgs e)
        {
            txtDocumento.Focus();
        }

        protected void cbxORDEN_GLOBAL_TRAS_TextChanged(object sender, EventArgs e)
        {
            CargarVistaOT();
        }
        #endregion
    }
}
