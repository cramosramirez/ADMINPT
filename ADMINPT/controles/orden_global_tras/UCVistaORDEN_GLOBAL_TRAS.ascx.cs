using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Modelo;

namespace ADMINPT.controles.orden_global_tras
{
    public partial class UCVistaORDEN_GLOBAL_TRAS : System.Web.UI.UserControl
    {
        #region "Propiedades"

        private CORDEN_GLOBAL_TRAS Controlador = new CORDEN_GLOBAL_TRAS();
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
            ORDEN_GLOBAL_TRAS Entidad = Controlador.ObtenerPorId(Identificador, Convert.ToInt32(Session["ID_BODEP"]));
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_ORDEN_TRAS.ToString();
                //txt_CodCaptura.Text = Entidad.COD_CAPTURA.ToString();
                dteFecha.Value = Entidad.FECHA;
                cbxSolicitante.Value = Entidad.ID_SOLICITANTE;
                cbxBodegaOrigen.Value = Entidad.ID_BODEGAO;
                //cbxBodegaOrdenG.Value = Entidad.ID_BODEGAD;
                cbxtipoMovimiento.Value = Entidad.ID_TIPO_MOV;
                cbxConceptoTM.Value = Entidad.ID_CONCE;
                cbxEspecifico.Value = Entidad.ID_ESPECI;
                cbxTIPO_REF_TRAS.Value = Entidad.ID_REF;
                txtDocumento.Value = Entidad.NUMREF;
                cbxZafraProd.Value = Entidad.ID_ZAFRA_PROD;
                cbxProducto.Value = Entidad.ID_PRODUCTO;
                txtAsignacionO.Value = Convert.ToDouble(Entidad.ASIGNACIONO);
                txtAmpliaciones.Value = Convert.ToDouble(Entidad.AMPLIACIONES);
                txtAsignacionT.Value = Convert.ToDouble(Entidad.ASIGNACIONT);
                txtEjecutado.Value = Convert.ToDouble(Entidad.EJECUTADO);
                txtSaldo.Value = Convert.ToDouble(Entidad.SALDO);
                ckEstado.Value = Entidad.ESTADO;
                txtObservacion.Text = Entidad.OBSERVACION;
                rb_propio.Value = Entidad.ES_PROPIO;
                rb_Ajeno.Value = Entidad.ES_AJENO;
                cbxestado.Value = Entidad.ID_ESTADO;
            }
        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;

           // txt_CodCaptura.ClientEnabled = esEdicion;
            dteFecha.ClientEnabled = esEdicion;
            cbxSolicitante.ClientEnabled = esEdicion;
            cbxBodegaOrigen.ClientEnabled = esEdicion;
            cbxBodegaDestino.ClientEnabled = esEdicion;
            cbxtipoMovimiento.ClientEnabled = esEdicion;
            cbxConceptoTM.ClientEnabled = esEdicion;
            cbxEspecifico.ClientEnabled = esEdicion;
            cbxTIPO_REF_TRAS.ClientEnabled = esEdicion;
            txtDocumento.ClientEnabled = esEdicion;
            cbxZafraProd.ClientEnabled = esEdicion;
            cbxProducto.ClientEnabled = esEdicion;
            
            ckEstado.ClientEnabled = esEdicion;
            txtObservacion.ClientEnabled = esEdicion;
            rb_propio.ClientEnabled = esEdicion;
            rb_Ajeno.ClientEnabled = esEdicion;
            cbxestado.ClientEnabled = false;
        }
        public string Actualizar()
        {
            string Result = "";
            ORDEN_GLOBAL_TRAS Entidad = new ORDEN_GLOBAL_TRAS();
            if (Identificador > 0)
            {
                Entidad = Controlador.ObtenerPorId(Identificador, Convert.ToInt32(Session["ID_BODEP"]));
                Entidad.USUARIO_ACT = Convert.ToString(Session["USUARIO"]);
            }
            else
            {
                Entidad.USUARIO_CREA = Convert.ToString(Session["USUARIO"]);
            }
            // Seteando la entidad con los campos de la vista y actualizando mediante el controlador

            //Entidad.ID_ORDEN_TRAS
           
            Entidad.FECHA = Convert.ToDateTime(dteFecha.Value);
            Entidad.ID_SOLICITANTE = Convert.ToInt32(cbxSolicitante.Value);
            Entidad.ID_BODEGAO = Convert.ToInt32(cbxBodegaOrigen.Value);
            Entidad.ID_BODEGAD = Convert.ToInt32(cbxBodegaDestino.Value);
            Entidad.ID_TIPO_MOV = Convert.ToInt32(cbxtipoMovimiento.Value);
            Entidad.ID_CONCE = Convert.ToInt32(cbxConceptoTM.Value);
            Entidad.ID_ESPECI = Convert.ToInt32(cbxEspecifico.Value);
            Entidad.ID_REF = Convert.ToInt32(cbxTIPO_REF_TRAS.Value);
            Entidad.NUMREF = Convert.ToInt32(txtDocumento.Text);
            Entidad.ID_ZAFRA_PROD = Convert.ToInt32(cbxZafraProd.Value);
            Entidad.ID_PRODUCTO = Convert.ToInt32(cbxProducto.Value);
            Entidad.ASIGNACIONO = Convert.ToDouble(txtAsignacionO.Value);
            Entidad.AMPLIACIONES = Convert.ToDouble(txtAmpliaciones.Value);
            Entidad.ASIGNACIONT = Convert.ToDouble(txtAsignacionT.Value);
            Entidad.EJECUTADO = Convert.ToDouble(txtEjecutado.Value);
            Entidad.SALDO = Convert.ToDouble(txtSaldo.Value);
            Entidad.ESTADO = ckEstado.Checked;
            Entidad.OBSERVACION = txtObservacion.Text;

            Entidad.ES_PROPIO = Convert.ToBoolean(rb_propio.Value);
            Entidad.ES_AJENO = Convert.ToBoolean(rb_Ajeno.Value);
            Entidad.ID_ESTADO = Convert.ToInt32(cbxestado.Value);

           
            //Entidad.USUARIO_ACT =
            //            Entidad.FECHA_ACT =
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
            cbxestado.SelectedIndex = 0;
            speCantidad.Value = 0;
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



            odsESTADO_MOVIMIENTOS.DataBind();
            cbxestado.DataSourceID = "odsESTADO_MOVIMIENTOS";
            odsESTADO_MOVIMIENTOS.DataBind();

            odsZAFRA_PROD.DataBind();
            cbxZafraProd.DataSourceID = "odsZAFRA_PROD";
            cbxZafraProd.DataBind();



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
        //    if (Convert.ToString(cbxProducto.Text) == "" & Convert.ToString(cbxZafraProd.Text) == "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
        //    { }
        //    else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) == "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
        //    { }
        //    else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) != "" & Convert.ToString(cbxBodegaOrigen.Text) == "")
        //    { }
        //    else if (Convert.ToString(cbxProducto.Text) != "" & Convert.ToString(cbxZafraProd.Text) != "" & Convert.ToString(cbxBodegaOrigen.Text) != "")
        //    {
        //        KARDEX lEntidadK = new CKARDEX().ObtenerPorIdBodegaExist(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxZafraProd.Value), Convert.ToInt32(cbxBodegaOrigen.Value),Convert.ToDateTime(dteFecha.Text));
        //        if (lEntidadK != null)
        //        {
        //            lblSaldo.Value = lEntidadK.EXISTENCIA_BODE;
        //            lblSaldo.Visible = true;
        //            lblPresentacion.Value = lEntidadK.PRESENTACION;
        //        }
        //        if (lEntidadK == null)
        //        {
        //            lblSaldo.Value = 0.00;
        //            lblPresentacion.Value = string.Empty;
        //            lblSaldo.Visible = true;
        //        }
        //    }
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
        protected void cbxTipoConcept_TextChanged(object sender, EventArgs e)
        {

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

        protected void speCantidad_ValueChanged(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // La variable 'CantMax' está asignada pero su valor nunca se usa
            double CantMax = 0;
#pragma warning restore CS0219 // La variable 'CantMax' está asignada pero su valor nunca se usa
            //CantMax = (Convert.ToDouble(lblSaldo.Value));
            //if (Convert.ToDouble(speCantidad.Value) > CantMax)
            //{
            //    lbl_mensaje.Text = "LA CANTIDAD MAXIMA ES : " + Convert.ToString(lblSaldo.Value) + " " + Convert.ToString(lblPresentacion.Text);
            //    lbl_mensaje.Visible = true;
            //    speInicial.Value = 0; speSaldo.Value = 0;
            //}
            //else { speInicial.Value = speCantidad.Value; speSaldo.Value = speCantidad.Value; }

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
        #endregion
        protected void speCantidad_ValueChanged1(object sender, EventArgs e)
        {

            txtAsignacionO.Value = speCantidad.Value;

txtAsignacionT.Value = speCantidad.Value;
           
txtSaldo.Value = speCantidad.Value;
        }
    }
}