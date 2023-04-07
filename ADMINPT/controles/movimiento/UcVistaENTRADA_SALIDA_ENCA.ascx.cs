using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
namespace ADMINPT.controles.movimiento
{
    public partial class UcVistaENTRADA_SALIDA_ENCA : System.Web.UI.UserControl
    {
        #region "Propiedades"
        private CENTRADA_SALIDA_ENCA  Controlador = new CENTRADA_SALIDA_ENCA();
        private CENTRADA_SALIDA_DETA  ControladorDt = new CENTRADA_SALIDA_DETA();
       
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
       // public Guid Vargui;

        private void CargarVista()
        {
            ModoEdicion(true);


            ENTRADA_SALIDA_ENCA Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_ES_ENCA.ToString();
                txt_CodCaptura.Text= Entidad.COD_CAPTURA.ToString();
                //ENCABEZADO
                dteFecha.Value = Entidad.FECHA;
                //txtIdentificador.Text = "0";
                cbxBodegaOrigen.Value = Entidad.ID_BODEGAO;
                cbxBodegaDestino.Value = Entidad.ID_BODEGAD;
                cbxZafraProd.Value = Entidad.ID_ZAFRA_PROD;
                cbxZafraActual.Value = Entidad.ID_ZAFRA_ACTUAL;
                cbxtipoMovimiento.Value = Entidad.ID_TIPO_MOV;
                cbxtipoMovimiento_TextChanged(null, null);
                cbxConceptoTM.Value = Entidad.ID_CONCE;
                cbxConceptoTM_TextChanged(null, null);
                cbxEspecifico.Value = Entidad.ID_ESPECI;
                cbxestado.Value = Entidad.ID_ESTADO;
                cbxORDEN_GLOBAL_TRAS.Value = Entidad.ID_ORDEN_TRAS;

                cbxProveedorTrans.Value = Entidad.ID_PROV_TRAS;
                cbxTransporte.Value = Entidad.ID_TRANSPORTE;
                txtMotoritsta.Text = Entidad.MOTORISTA;
                txtNitMotor.Text = Entidad.NIT;
                txtplacaCabezal.Text = Entidad.PLACA_CABEZAL;
                txtPlacaRemolque.Text = Entidad.PLACA_REMOLQUE;
                txtContenedor.Text = Entidad.CONTENEDOR;
                txtMarchamos.Text = Entidad.MARCHAMOS;
                txtObservacion.Text = Entidad.OBSERVACION;


                //txtIdentificador.ClientEnabled = false;
                //txtIdentificador.ClientEnabled = false;

                cbxBodegaDestino.Enabled = false;
                cbxBodegaOrigen.Enabled = false;
                dteFecha.Enabled = false;
                cbxZafraActual.Enabled = false;
                cbxZafraProd.Enabled = false;
                cbxtipoMovimiento.Enabled = false;
                cbxEspecifico.Enabled = false;
                txt_CodCaptura.Enabled = false;
                speFactor.Enabled = false;
                //cbxDiaZafra.Enabled=false;
                //cbxTurno.Enabled=false;
                //cbxTipoConcepto.Enabled=false;
                //mmoObservaciones.Enabled=false;


                cbxProducto.Enabled = false;
                //cbxTipoConcept.Enabled=false;
                cbxPrestanciontras.Enabled = false;
                //cbxPrestancionvta.Enabled=false;
                cbxUnidad.Enabled = false;
                //cbxUNIDAD_MEDI_FAC.Enabled=false;
                //speFACTORQQ.Enabled=false;
                //speFACTORKG.Enabled=false;
                //speTARIMA.Enabled=false;
                //speSACOS.Enabled=false;
                speCantidad.Enabled = false;
                //speKilogramos.Enabled=false;
                //speGalones.Enabled=false;
                cbxBodegaOrigen.Enabled = false;
                cbxConceptoTM.Enabled = false;
                cbxestado.Value = false;

                cbxProveedorTrans.Enabled = false;
                cbxTransporte.Enabled = false;
                txtMotoritsta.Enabled = false;
                txtNitMotor.Enabled = false;
                txtplacaCabezal.Enabled = false;
                txtPlacaRemolque.Enabled = false;
                txtContenedor.Enabled = false;
                txtMarchamos.Enabled = false;
                txtObservacion.Enabled = false;
            }

            ENTRADA_SALIDA_DETA EntidadDt = ControladorDt.ObtenerPorIdEnc(Identificador);
            if (EntidadDt != null)
            {
                //txtIdentificador.Text = EntidadDt.ID_ES_ENCA.ToString();

                //DETALLE
                cbxProducto.Value = EntidadDt.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);
                speCantidad.Value = EntidadDt.CANTIDAD;

                llenarGridOrigenCPT(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToDouble(speCantidad.Value), Convert.ToDouble(speFactor.Value), Convert.ToString(lbGuid.Text));

                //EntidadDt.ID_PRODUCTO = (int)cbxProducto.Value;
                //EntidadDt.ID_TIPO_CONCEPTO = (int)cbxTipoConcept.Value;
                //EntidadDt.ID_PRESEN_TRAS = (int)cbxPrestanciontras.Value;
                //EntidadDt.ID_PRESEN_VTA = (int)cbxPrestancionvta.Value;
                
                //EntidadDt.ID_UNIDAD_FAC = (int)cbxUNIDAD_MEDI_FAC.Value;
                //EntidadDt.FACTOR_QQ = Convert.ToDecimal(speFACTORQQ.Value);
                //EntidadDt.FACTOR_KG = Convert.ToDecimal(speFACTORKG.Value);
                //EntidadDt.TARIMA = Convert.ToDecimal(speTARIMA.Value);
                //EntidadDt.SACOS = Convert.ToDecimal(speSACOS.Value);
                
                //EntidadDt.KILOGRAMOS = Convert.ToDecimal(speKilogramos.Value);
                //EntidadDt.GALONES = Convert.ToDecimal(speGalones.Value);
            }


        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;

            cbxBodegaDestino.ClientEnabled = esEdicion;
            cbxBodegaOrigen.ClientEnabled = esEdicion;
            dteFecha.ClientEnabled = esEdicion;
            cbxZafraActual.ClientEnabled = esEdicion;
            cbxZafraProd.ClientEnabled = esEdicion;
            cbxtipoMovimiento.ClientEnabled = esEdicion;
            //cbxDiaZafra.ClientEnabled = esEdicion;
            //cbxTurno.ClientEnabled = esEdicion;
            //cbxTipoConcepto.ClientEnabled = esEdicion;
            //mmoObservaciones.ClientEnabled = esEdicion;

            cbxProducto.ClientEnabled = esEdicion;
            //cbxTipoConcept.ClientEnabled = esEdicion;
            cbxPrestanciontras.ClientEnabled = esEdicion;
            //cbxPrestancionvta.ClientEnabled = esEdicion;
            cbxUnidad.ClientEnabled = esEdicion;
            //cbxUNIDAD_MEDI_FAC.ClientEnabled = esEdicion;
            //speFACTORQQ.ClientEnabled = esEdicion;
            //speFACTORKG.ClientEnabled = esEdicion;
            //speTARIMA.ClientEnabled = esEdicion;
            //speSACOS.ClientEnabled = esEdicion;
            speCantidad.ClientEnabled = esEdicion;
            //speKilogramos.ClientEnabled = esEdicion;
            //speGalones.ClientEnabled = esEdicion;
            cbxBodegaOrigen.ClientEnabled = esEdicion;
            cbxConceptoTM.ClientEnabled = esEdicion;
            //txtNReferencia.ClientEnabled = esEdicion;
            cbxestado.ClientEnabled = false;
            cbxORDEN_GLOBAL_TRAS.ClientEnabled = esEdicion;
         }
        public string Actualizar()
        {
            string Result = "";
            ENTRADA_SALIDA_ENCA Entidad = new ENTRADA_SALIDA_ENCA();
            ENTRADA_SALIDA_DETA EntidadDt = new ENTRADA_SALIDA_DETA();
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
            Entidad.COD_CAPTURA = 0;//Convert.ToInt32(txt_CodCaptura.Text);
            Entidad.FECHA = Convert.ToDateTime(dteFecha.Value);
            Entidad.ES_PROPIO = Convert.ToBoolean(rb_propio.Value);
            Entidad.ES_AJENO = Convert.ToBoolean(rb_Ajeno.Value);
            Entidad.ID_ZAFRA_PROD = Convert.ToInt32(cbxZafraProd.Value);
            Entidad.ID_ZAFRA_ACTUAL = Convert.ToInt32(cbxZafraActual.Value);
            Entidad.ID_TIPO_MOV = Convert.ToInt32(cbxtipoMovimiento.Value);
            Entidad.ID_CONCE = Convert.ToInt32(cbxConceptoTM.Value);
            Entidad.ID_ESPECI = Convert.ToInt32(cbxEspecifico.Value);

            if (Convert.ToInt32(cbxConceptoTM.Value) == 13 || Convert.ToInt32(cbxConceptoTM.Value) == 14)
            {
                Entidad.ID_BODEGAO = Convert.ToInt32(cbxBodegaOrigen.Value);
                Entidad.ID_BODEGAD = 0;
            }
            else
            {
                Entidad.ID_BODEGAO = Convert.ToInt32(cbxBodegaOrigen.Value);
                Entidad.ID_BODEGAD = Convert.ToInt32(cbxBodegaDestino.Value);
            }
            Entidad.NUM_DOC = Convert.ToString(txt_ndocument.Text);
            Entidad.ID_ESTADO = Convert.ToInt32(cbxestado.Value);
            Entidad.ID_ORDEN_TRAS = Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value);


            Entidad.ID_PROV_TRAS = Convert.ToInt32(cbxProveedorTrans.Value);
            Entidad.ID_TRANSPORTE = Convert.ToInt32(cbxTransporte.Value);
            Entidad.MOTORISTA = Convert.ToString(txtMotoritsta.Text);
            Entidad.NIT = Convert.ToString(txtNitMotor.Text);
            Entidad.PLACA_CABEZAL = Convert.ToString(txtplacaCabezal.Text);
            Entidad.PLACA_REMOLQUE = Convert.ToString(txtPlacaRemolque.Text);
            Entidad.CONTENEDOR = Convert.ToString(txtContenedor.Text);
            Entidad.MARCHAMOS = Convert.ToString(txtMarchamos.Text);
            Entidad.OBSERVACION = Convert.ToString(txtObservacion.Text);

            //detalle


            //   EntidadDt.ID_ES_ENCA = 0;//Entidad.ID_ES_ENCA;
            EntidadDt.ID_PRODUCTO = Convert.ToInt32(cbxProducto.Value);
            EntidadDt.ID_PRESEN_TRAS = Convert.ToInt32(cbxPrestanciontras.Value);
            EntidadDt.ID_UNIDAD_FAC = Convert.ToInt32(cbxUnidad.Value);
            EntidadDt.CANTIDAD = Convert.ToSingle(speCantidad.Value);
            EntidadDt.FACTOR = Convert.ToDouble(speFactor.Value);
            EntidadDt.REFERENCIA_DETA = Guid.NewGuid();
            EntidadDt.FACTORKG = Convert.ToDouble(speFactorKg.Value);

            Controlador.Actualizar(ref Entidad);
            EntidadDt.ID_ES_ENCA = Entidad.ID_ES_ENCA;
            ControladorDt.Actualizar(EntidadDt);
            Result = ControladorDt.sError;

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

            //sessionTableConvert();
            txtIdentificador.Text = "";
            cbxBodegaOrigen.Value = null;
            cbxBodegaDestino.Value = null;
            dteFecha.Value = DateTime.Now;
            cbxZafraActual.Value = null;
            cbxZafraProd.Value = null;
           // Vargui = Guid.NewGuid();
            lbGuid.Text = Guid.NewGuid().ToString();


            //cbxDiaZafra.Value = null;
            //cbxTurno.Value = null;

            //mmoObservaciones.Text = "";

            cbxProducto.Value = null;
            //cbxTipoConcept.Value = null;
            cbxPrestanciontras.Value = null;
            //cbxPrestancionvta.Value = null;
            cbxUnidad.Value = null;
            cbxtipoMovimiento.Value = null;
            cbxConceptoTM.Value = null;
            //cbxUNIDAD_MEDI_FAC.Value = null;
            //speFACTORQQ.Value = 1.087;
            //speFACTORKG.Value = 50;
            //speTARIMA.Value = 0;
            //speSACOS.Value = 0;
            speCantidad.Value = 0;
            //speKilogramos.Value = 0;
            //speGalones.Value = 0;
            cbxBodegaOrigen.Value = null;
            txt_ndocument.Text = null;
            cbxORDEN_GLOBAL_TRAS.Value = null;
            cbxestado.Value = null;
            ZafraACtual();



            // Creamos el DataTable
            DataTable DT = new DataTable();

            //DT.Columns.Add("ID_ES_DETA", Type.GetType("System.Int32"));

            DT.Columns.Add(new System.Data.DataColumn("ID_ES_DETA", typeof(System.Int32)));
            DT.PrimaryKey = new DataColumn[1] { DT.Columns["ID_ES_DETA"] }; // throws an error
            DT.Columns["ID_ES_DETA"].AutoIncrement = true;
            DT.Columns.Add("ID_PRODUCTO", Type.GetType("System.Int32"));
            //DT.Columns.Add("NOMBRE_PRODUCTO", Type.GetType("System.String"));
            DT.Columns.Add("ID_PRESEN_TRAS", Type.GetType("System.Int32"));
            //DT.Columns.Add("NOMBRE_PRESEN_TRAA", Type.GetType("System.String"));
            DT.Columns.Add("ID_UNIDAD_FAC", Type.GetType("System.Int32"));
            //DT.Columns.Add("NOMBRE_UNIDAD", Type.GetType("System.String"));
            DT.Columns.Add("CANTIDAD", Type.GetType("System.Single"));
            DT.Columns.Add("FACTOR", Type.GetType("System.Single"));
            DT.Columns.Add("REFERENCIA_DETA", Type.GetType("System.String"));
           
            // Guardamos la información en una variable de sesión
            Session["DT"] = DT;

            // Asignamos el DT al gridview (en este momento el DT está vacio)
            UcListaENTRADA_SALIDA_DETA._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA._gridLista.DataBind();
          


            txt_CodCaptura.Text = "";
            cbxORDEN_GLOBAL_TRAS.Focus();



            //txtIdentificador.ClientEnabled = true;
            //txtIdentificador.ClientEnabled = true;

            cbxBodegaDestino.Enabled = true;
            cbxBodegaOrigen.Enabled = true;
            dteFecha.Enabled = true;
            cbxZafraActual.Enabled = true;
            cbxZafraProd.Enabled = true;
            cbxtipoMovimiento.Enabled = true;
            cbxEspecifico.Enabled = true;
            txt_CodCaptura.Enabled = true;
            speFactor.Enabled = true;
            //cbxDiaZafra.Enabled=true;
            //cbxTurno.Enabled=true;
            //cbxTipoConcepto.Enabled=true;
            //mmoObservaciones.Enabled=true;


            cbxProducto.Enabled = true;
            //cbxTipoConcept.Enabled=true;
            cbxPrestanciontras.Enabled = true;
            //cbxPrestancionvta.Enabled=true;
            cbxUnidad.Enabled = true;
            //cbxUNIDAD_MEDI_FAC.Enabled=true;
            //speFACTORQQ.Enabled=true;
            //speFACTORKG.Enabled=true;
            //speTARIMA.Enabled=true;
            //speSACOS.Enabled=true;
            speCantidad.Enabled = true;
            //speKilogramos.Enabled=true;
            //speGalones.Enabled=true;
            cbxBodegaOrigen.Enabled = true;
            cbxConceptoTM.Enabled = true;
            cbxestado.Value = 1;
            cbxProveedorTrans.Enabled = true;
            cbxTransporte.Enabled = true;
            txtMotoritsta.Enabled = true;
            txtNitMotor.Enabled = true;
            txtplacaCabezal.Enabled = true;
            txtPlacaRemolque.Enabled = true;
            txtContenedor.Enabled = true;
            txtMarchamos.Enabled = true;
            txtObservacion.Enabled = true;
        }
        private void llenarGridOrigenCPT(int idproducto,int idpresentacion,int idunidad,double cantidad,double factor,string Guid)
        {
            DataTable DT = (DataTable)Session["DT"];
            // 'Revisamos si ya existe el usuario
            DataRow[] DR;
            DR = DT.Select("ID_PRODUCTO = " + cbxProducto.Value);
            if (DR.Length > 0)
            {
                lbl_mensaje.Text = "¡PRODUCTO YA EXISTE!";
                lbl_mensaje.Visible = true;
                return;
            }
            else
            {
                lbl_mensaje.Visible = false;
            }
            DT.Rows.Add(null, idproducto, idpresentacion, idunidad, cantidad, factor, Guid);
            //DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value));
            UcListaENTRADA_SALIDA_DETA._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA._gridLista.DataBind();
            // Actualizamos el DataTable en la variable de session
            Session["DT"] = DT;
            UcListaENTRADA_SALIDA_DETA._gridLista.DataBind();
            //cn.Close();
        }
        private void CargarListas()
        {
            odsTRANSPORTE.DataBind();
            cbxTransporte.DataSourceID = "odsTRANSPORTE";
            cbxTransporte.DataBind();

            odsPROVEEDOR_TRAS.DataBind();
            cbxProveedorTrans.DataSourceID = "odsPROVEEDOR_TRAS";
            cbxProveedorTrans.DataBind();

            odsBodegaDUser.DataBind();
            cbxBodegaDestino.DataSourceID = "odsBodegaDUser";
            cbxBodegaDestino.DataBind();

            odsESTADO_MOVIMIENTOS.DataBind();
            cbxestado.DataSourceID = "odsESTADO_MOVIMIENTOS";
            odsESTADO_MOVIMIENTOS.DataBind();

            odsZAFRA_PROD.DataBind();
            cbxZafraProd.DataSourceID = "odsZAFRA_PROD";
            cbxZafraProd.DataBind();

            //odsDIA_ZAFRA.DataBind();
            //cbxDiaZafra.DataSourceID = "odsDIA_ZAFRA";
            //cbxDiaZafra.DataBind();

            //odsTURNO.DataBind();
            //cbxTurno.DataSourceID = "odsTURNO";
            //cbxTurno.DataBind();

            //DETALLE
            odsPRODUCTO.DataBind();
            cbxProducto.DataSourceID = "odsPRODUCTO";
            cbxProducto.DataBind();

            odsTIPO_MOVIMIENTO.DataBind();
            cbxtipoMovimiento.DataSourceID = "odsTIPO_MOVIMIENTO";
            cbxtipoMovimiento.DataBind();

            odsORDEN_GLOBAL_TRAS.DataBind();
            cbxORDEN_GLOBAL_TRAS.DataSourceID = "odsORDEN_GLOBAL_TRAS";
            cbxORDEN_GLOBAL_TRAS.DataBind();


            //odsUNIDAD_MEDI_CONSAA.DataBind();
            //cbxUNIDAD_MEDI_CONSAA.DataSourceID = "odsUNIDAD_MEDI_CONSAA";
            //cbxUNIDAD_MEDI_CONSAA.DataBind();

            //odsUNIDAD_MEDI_FAC.DataBind();
            //cbxUNIDAD_MEDI_FAC.DataSourceID = "odsUNIDAD_MEDI_FAC";
            //cbxUNIDAD_MEDI_FAC.DataBind();
        }
        private void ZafraACtual()
        {
            odsZAFRA_ACTUAL.DataBind();
            cbxZafraActual.DataSourceID = "odsZAFRA_ACTUAL";
            cbxZafraActual.DataBind();
            cbxZafraActual.SelectedIndex = 1;
        }
        //*******ASIGNA LA BODEGA QUE TIENE SALDO***//
        private void KardexIdBodega()
        {
            odsBodegaOUser.DataBind();
           cbxBodegaOrigen.DataSourceID = "odsBodegaOUser";
            odsBodegaOUser.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
            odsKARDEX_BODEGA.SelectParameters["ID_ZAFRA_PROD"].DefaultValue = cbxZafraProd.Value.ToString();
            cbxBodegaOrigen.DataBind();
            cbxBodegaOrigen.SelectedIndex = 1;
        }
        //private void BodegaOrigen()
        //{
        //    odsBODEGAOrigen.DataBind();
        //    cbxBodegaOrigen.DataSourceID = "odsBODEGAOrigen";
        //    cbxBodegaOrigen.DataBind();
        //}
        private void CargarEspecificoMov()
        {
            cbxEspecifico.DataSourceID = "odsESPECI_MOV";
            odsESPECI_MOV.SelectParameters["id"].DefaultValue = cbxConceptoTM.Value.ToString();
            odsESPECI_MOV.DataBind();
            cbxEspecifico.DataBind();
           
        }

        private void CargarConceptosMovi()
        {
            cbxConceptoTM.DataSourceID = "odsCONCEPTO_MOVI";
            odsCONCEPTO_MOVI.SelectParameters["id"].DefaultValue = cbxtipoMovimiento.Value.ToString();
            odsCONCEPTO_MOVI.DataBind();
            cbxConceptoTM.DataBind();
           
        }
        private void CargarUnidida_Fac()
        {
            cbxUnidad.DataSourceID = "odsUNIDAD_MEDI_FAC";
            odsUNIDAD_MEDI_FAC.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsUNIDAD_MEDI_FAC.DataBind();
            cbxUnidad.DataBind();
            cbxUnidad.SelectedIndex = 1;
            //ObtenerFactor();
        }

        private void CargarPresentacion_tras()
        {
            cbxPrestanciontras.DataSourceID = "odsPRESENTACION_TRAS";
            odsPRESENTACION_TRAS.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsPRESENTACION_TRAS.DataBind();
            cbxPrestanciontras.DataBind();
            cbxPrestanciontras.SelectedIndex = 1;
        }
        private void CargarPresentacion_vta()
        {
            //cbxPrestancionvta.DataSourceID = "odsPRESENTACION_VTA";
            odsPRESENTACION_VTA.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsPRESENTACION_VTA.DataBind();
            //cbxPrestancionvta.DataBind();
        }

        #endregion

        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            //CargarConceptos();

            CargarUnidida_Fac();
            CargarPresentacion_tras();
            ObtenerFactor();


            //CargarPresentacion_vta();
        }

        protected void cbxTipoConcept_TextChanged(object sender, EventArgs e)
        {
            //if(Convert.ToInt32(cbxTipoConcept.SelectedItem.Value) == 5)
            //{ contbgorigen.Visible = true; }
            //else { contbgorigen.Visible = false;     }
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
        protected void ObtenerKardexExistencia()
        {
            KARDEX lEntidadK = new CKARDEX().ObtenerPorIdBodegaExist(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxZafraProd.Value), Convert.ToInt32(cbxBodegaOrigen.Value), Convert.ToDateTime(dteFecha.Text));
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
        protected void cbxtipoMovimiento_TextChanged(object sender, EventArgs e)
        {
            CargarConceptosMovi();

            //if (Convert.ToInt32(cbxtipoMovimiento.Value) == 1)
            //{
            //    BodegaOrigen();
            ////}
            //else {
             // KardexIdBodega();
            //}
           
        }
        protected void cbxConceptoTM_TextChanged(object sender, EventArgs e)
        {
            CargarEspecificoMov();
            if (Convert.ToInt32(cbxConceptoTM.Value) == 13 || Convert.ToInt32(cbxConceptoTM.Value) == 14)
            {
                cbxBodegaDestino.ClientVisible = false;
                lblBodegaDestino.ClientVisible = false;

                cbxProveedorTrans.ClientVisible = false;
                lblProveedorTrans.ClientVisible = false;

                lblTransporte.ClientVisible = false;
                cbxTransporte.ClientVisible = false;

                lblMotoritsta.ClientVisible = false;
                txtMotoritsta.ClientVisible = false;

                lblNitMotor.ClientVisible = false;
                txtNitMotor.ClientVisible = false;

                lblplacaCabezal.ClientVisible = false;
                txtplacaCabezal.ClientVisible = false;

                lblPlacaRemolque.ClientVisible = false;
                txtPlacaRemolque.ClientVisible = false;

                lblContenedor.ClientVisible = false;
                txtContenedor.ClientVisible = false;

                lblMarchamos.ClientVisible = false;
                txtMarchamos.ClientVisible = false;
            }
            //if (Convert.ToInt32(cbxConceptoTM.Value) != 13 || Convert.ToInt32(cbxConceptoTM.Value) != 14)
            //{
            //    cbxBodegaDestino.ClientVisible = true;
            //    lblBodegaDestino.ClientVisible = true;

            //    cbxProveedorTrans.ClientVisible = true;
            //    lblProveedorTrans.ClientVisible = true;

            //    lblTransporte.ClientVisible = true;
            //    cbxTransporte.ClientVisible = true;

            //    lblMotoritsta.ClientVisible = true;
            //    txtMotoritsta.ClientVisible = true;

            //    lblNitMotor.ClientVisible = true;
            //    txtNitMotor.ClientVisible = true;

            //    lblplacaCabezal.ClientVisible = true;
            //    txtplacaCabezal.ClientVisible = true;

            //    lblPlacaRemolque.ClientVisible = true;
            //    txtPlacaRemolque.ClientVisible = true;

            //    lblContenedor.ClientVisible = true;
            //    txtContenedor.ClientVisible = true;

            //    lblMarchamos.ClientVisible = true;
            //    txtMarchamos.ClientVisible = true;
            //}
        }
        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            DataTable DT = (DataTable)Session["DT"];
            // 'Revisamos si ya existe el usuario
            DataRow[] DR;
            DR = DT.Select("ID_PRODUCTO = " + cbxProducto.Value);
            if (DR.Length > 0)
            {
                lbl_mensaje.Text = "¡PRODUCTO YA EXISTE!";
                lbl_mensaje.Visible = true;
                return;
            }
            else
            {
                lbl_mensaje.Visible = false;
            }
            DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value),Convert.ToInt32(cbxPrestanciontras.Value),Convert.ToInt32(cbxUnidad.Value),Convert.ToInt32(speCantidad.Value),Convert.ToSingle(speFactor.Value),Convert.ToString(lbGuid.Text));
            //DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value));
            UcListaENTRADA_SALIDA_DETA._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA._gridLista.DataBind();
            // Actualizamos el DataTable en la variable de session
            Session["DT"] = DT;
            UcListaENTRADA_SALIDA_DETA._gridLista.DataBind();
            //cn.Close();
           // btnAgregarProductos0.Enabled = false;
            btnAgregarProductos.Enabled = false;
        }
        protected void txt_CodCaptura_TextChanged(object sender, EventArgs e)
        {
            DOCTO_ENCA lEntidad = new CDOCTO_ENCA().ObtenerPorId(Convert.ToInt32(txt_CodCaptura.Value));
            DOCTO_DETA lEntidaddt = new CDOCTO_DETA().ObtenerPorId(Convert.ToInt32(txt_CodCaptura.Value));
            if (lEntidad != null)
            {
                //ENCABEZADO
                txt_ndocument.Text = Convert.ToString(lEntidad.NO_DOCTO);
                dteFecha.Value = lEntidad.FECHA;
                txtIdentificador.Text = "0";
    
                cbxtipoMovimiento.Value = lEntidad.ID_TIPO_MOV;
                cbxtipoMovimiento_TextChanged(null,null);
                cbxConceptoTM.Value = lEntidad.ID_CONCE;
                cbxConceptoTM_TextChanged(null, null);
                cbxEspecifico.Value = lEntidad.ID_ESPECI;
                cbxestado.Value = lEntidad.ID_ESTADO;
                cbxORDEN_GLOBAL_TRAS.Value = lEntidad.ID_ORDEN_TRAS;

                //DETALLE
                cbxProducto.Value = lEntidaddt.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);
                cbxZafraProd.Value = lEntidad.ID_ZAFRA_DES;
                KardexIdBodega();
   
                cbxBodegaDestino.Value = lEntidad.ID_BODEGA_DEST;
                speCantidad.Value = lEntidaddt.CANTIDAD;
                cbxBodegaOrigen.Value = lEntidad.ID_BODEGA;
                llenarGridOrigenCPT(Convert.ToInt32(cbxProducto.Value),Convert.ToInt32(cbxPrestanciontras.Value),Convert.ToInt32(cbxUnidad.Value),Convert.ToDouble(speCantidad.Value),Convert.ToDouble(speFactor.Value),Convert.ToString(lbGuid.Text));
                btnAgregarProductos0.Enabled = false;
                btnAgregarProductos.Enabled = false;
            }
            if (lEntidad == null)
            {
                speFactor.Value = 0;
                speFactorKg.Value = 0;
            }
        }

        protected void cbxORDEN_GLOBAL_TRAS_TextChanged(object sender, EventArgs e)
        {
            ORDEN_GLOBAL_TRAS lEntidad = new CORDEN_GLOBAL_TRAS().ObtenerPorId(Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value), Convert.ToInt32(Session["ID_BODEP"]));
//            DOCTO_DETA lEntidaddt = new CDOCTO_DETA().ObtenerPorId(Convert.ToInt32(txt_CodCaptura.Value));
            if (lEntidad != null)
            {
                //ENCABEZADO
                //txt_ndocument.Text = Convert.ToString(lEntidad.NO_DOCTO);
                dteFecha.Value = lEntidad.FECHA;
                txtIdentificador.Text = "0";
                cbxBodegaOrigen.Value = lEntidad.ID_BODEGAO;
                cbxBodegaDestino.Value = lEntidad.ID_BODEGAD;
                cbxZafraProd.Value = lEntidad.ID_ZAFRA_PROD;
                cbxtipoMovimiento.Value = lEntidad.ID_TIPO_MOV;
                cbxtipoMovimiento_TextChanged(null, null);
                cbxConceptoTM.Value = lEntidad.ID_CONCE;
                cbxConceptoTM_TextChanged(null, null);
                cbxEspecifico.Value = lEntidad.ID_ESPECI;
                cbxestado.Value = lEntidad.ID_ESTADO;
                cbxORDEN_GLOBAL_TRAS.Value = lEntidad.ID_ORDEN_TRAS;

                //DETALLE
                cbxProducto.Value = lEntidad.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);
                //speCantidad.Value = lEntidad.CANTIDAD;

                //llenarGridOrigenCPT(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToDouble(speCantidad.Value), Convert.ToDouble(speFactor.Value), Convert.ToString(lbGuid.Text));
                //btnAgregarProductos0.Enabled = false;
                //btnAgregarProductos.Enabled = false;
            }
        }

        protected void ASPxTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cbxBodegaOrigen_TextChanged(object sender, EventArgs e)
        {
            ObtenerKardexExistencia();
        }

        protected void speCantidad_ValueChanged(object sender, EventArgs e)
        {
            double CantMax = 0;
            CantMax = (Convert.ToDouble(lblSaldo.Value));
            if (Convert.ToDouble(speCantidad.Value) > CantMax)
            {
                lbl_mensaje.Text = "LA CANTIDAD MAXIMA ES : "+Convert.ToString(lblSaldo.Value) +" " + Convert.ToString(lblPresentacion.Text);
                lbl_mensaje.Visible = true;
            }

        }
    }
}
