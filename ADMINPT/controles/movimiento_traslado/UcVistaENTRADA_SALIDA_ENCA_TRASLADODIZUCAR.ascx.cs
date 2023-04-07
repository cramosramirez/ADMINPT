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

namespace ADMINPT.controles.movimiento_traslado
{
    public partial class UcVistaENTRADA_SALIDA_ENCA_TRASLADODIZUCAR : System.Web.UI.UserControl
    {
        #region "Propiedades"
        private CENTRADA_SALIDA_ENCA Controlador = new CENTRADA_SALIDA_ENCA();
        private CENTRADA_SALIDA_DETA ControladorDt = new CENTRADA_SALIDA_DETA();

        public int Identificador

        {
            get
            {
                if (ViewState["Identificador"] == null)
                {

                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ViewState["Identificador"]);
                }
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

            ENTRADA_SALIDA_ENCA Entidad = Controlador.ObtenerPorId(Identificador);
            if (Entidad != null)
            {
                txtIdentificador.Text = Entidad.ID_ES_ENCA.ToString();
                //ENCABEZADO
                dteFecha.Value = Entidad.FECHA;
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

                txtObservacion.Text = Entidad.OBSERVACION;
                txtNFormulario.Text = Entidad.NFORMULARIO;


                cbxBodegaDestino.Enabled = false;
                cbxBodegaOrigen.Enabled = false;
                dteFecha.Enabled = false;
                cbxZafraActual.Enabled = false;
                cbxZafraProd.Enabled = false;
                cbxtipoMovimiento.Enabled = false;
                cbxEspecifico.Enabled = false;
                speFactor.Enabled = false;


                cbxProducto.Enabled = false;
                cbxPrestanciontras.Enabled = false;
                cbxUnidad.Enabled = false;

                speCantidad.Enabled = false;
                cbxBodegaOrigen.Enabled = false;
                cbxConceptoTM.Enabled = false;
                cbxestado.Value = false;

                cbxProveedorTrans.Enabled = false;
                cbxTransporte.Enabled = false;
                txtMotoritsta.Enabled = false;
                txtNitMotor.Enabled = false;

                txtObservacion.Enabled = false;
            }

            ENTRADA_SALIDA_DETA EntidadDt = ControladorDt.ObtenerPorIdEnc(Identificador);
            if (EntidadDt != null)
            {

                //DETALLE
                cbxProducto.Value = EntidadDt.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);
                speCantidad.Value = EntidadDt.CANTIDAD;

                llenarGridOrigenCPT(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToDouble(speCantidad.Value), Convert.ToDouble(speFactor.Value), Convert.ToString(lbGuid.Text));


            }


        }
        private void ModoEdicion(Boolean esEdicion)
        {
            txtIdentificador.ClientEnabled = false;

            cbxestado.ClientEnabled = esEdicion;
            dteFecha.ClientEnabled = esEdicion;
            rb_propio.ClientEnabled = esEdicion;
            rb_Ajeno.ClientEnabled = esEdicion;
            cbxZafraProd.ClientEnabled = esEdicion;
            cbxZafraActual.ClientEnabled = esEdicion;
            cbxtipoMovimiento.ClientEnabled = esEdicion;
            cbxConceptoTM.ClientEnabled = esEdicion;
            cbxEspecifico.ClientEnabled = esEdicion;
            cbxBodegaOrigen.ClientEnabled = esEdicion;
            cbxBodegaDestino.ClientEnabled = esEdicion;
            txt_ndocument.ClientEnabled = esEdicion;
            cbxestado.ClientEnabled = esEdicion;
            cbxORDEN_GLOBAL_TRAS.ClientEnabled = esEdicion;
            cbxProveedorTrans.ClientEnabled = esEdicion;
            cbxTransporte.ClientEnabled = esEdicion;
            txtMotoritsta.ClientEnabled = esEdicion;
            txtNitMotor.ClientEnabled = esEdicion;
            txtObservacion.ClientEnabled = esEdicion;
            txtNFormulario.ClientEnabled = esEdicion;
            cbxProducto.ClientEnabled = esEdicion;
            cbxPrestanciontras.ClientEnabled = esEdicion;
            cbxUnidad.ClientEnabled = esEdicion;
            speCantidad.ClientEnabled = esEdicion;
            speFactor.ClientEnabled = esEdicion;
            speFactorKg.ClientEnabled = esEdicion;
            lblSaldo.ClientEnabled = esEdicion;
        }
        public string ActualizarTraslado()
        {
            string Result = "0";
            if (Convert.ToInt32(Session["ID_BODEP"]) == 0)
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! Se cerró la sesión !','error') </script>"); }
            else
            {
                if (Convert.ToDouble(lblSaldo.Text) <= 0.00)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! NO SE PUEDE PROCESAR PORQUE LA EXISTENCIA DISPONIBLE ES ≤0 !','error') </script>"); }
                else
                {
                    ENTRADA_SALIDA_ENCA Entidad = new ENTRADA_SALIDA_ENCA();
                    ENTRADA_SALIDA_DETA EntidadDt = new ENTRADA_SALIDA_DETA();

                    Entidad.USUARIO_CREA = Convert.ToString(Session["USUARIO"]);
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
                    Entidad.ID_BODEGAO = Convert.ToInt32(cbxBodegaOrigen.Value);
                    Entidad.ID_BODEGAD = Convert.ToInt32(cbxBodegaDestino.Value);
                    Entidad.NUM_DOC = Convert.ToString(txt_ndocument.Text);
                    Entidad.ID_ESTADO = Convert.ToInt32(cbxestado.Value);
                    Entidad.ID_ORDEN_TRAS = Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value);
                    Entidad.ID_PROV_TRAS = Convert.ToInt32(cbxProveedorTrans.Value);
                    Entidad.ID_TRANSPORTE = Convert.ToInt32(cbxTransporte.Value);
                    Entidad.MOTORISTA = Convert.ToString(txtMotoritsta.Text);
                    Entidad.NIT = Convert.ToString(txtNitMotor.Text);
                    Entidad.OBSERVACION = Convert.ToString(txtObservacion.Text);
                    Entidad.NFORMULARIO = Convert.ToString(txtNFormulario.Text);
                    Entidad.ID_BODEP = Convert.ToInt32(Session["ID_BODEP"]);
                    //detalle
                    //   EntidadDt.ID_ES_ENCA = 0;//Entidad.ID_ES_ENCA;
                    EntidadDt.ID_PRODUCTO = Convert.ToInt32(cbxProducto.Value);
                    EntidadDt.ID_PRESEN_TRAS = Convert.ToInt32(cbxPrestanciontras.Value);
                    EntidadDt.ID_UNIDAD_FAC = Convert.ToInt32(cbxUnidad.Value);
                    EntidadDt.CANTIDAD = Convert.ToSingle(speCantidad.Value);
                    EntidadDt.FACTOR = Convert.ToDouble(speFactor.Value);
                    EntidadDt.REFERENCIA_DETA = Guid.NewGuid();
                    EntidadDt.FACTORKG = Convert.ToDouble(speFactorKg.Value);
                    EntidadDt.ID_BODEP = Convert.ToInt32(Session["ID_BODEP"]);
                    Controlador.ActualizarTraslado(ref Entidad);
                    Session["ID_ES_ENCA"] = Entidad.ID_ES_ENCA;
                    EntidadDt.ID_ES_ENCA = Entidad.ID_ES_ENCA;

                    Result = Convert.ToString(ControladorDt.ActualizarTraslado(EntidadDt));
                }
            }
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
            txtIdentificador.Text = string.Empty;
            //txtFecha.DateTime = DateTime.Now;
            rb_propio.Checked = true;
            rb_Ajeno.Checked = false;
            cbxZafraProd.SelectedIndex = -1;
            cbxZafraActual.SelectedIndex = -1;
            cbxtipoMovimiento.SelectedIndex = -1;
            cbxConceptoTM.SelectedIndex = -1;
            cbxEspecifico.SelectedIndex = -1;
             cbxBodegaOrigen.SelectedIndex = 1;
            cbxBodegaDestino.SelectedIndex = -1;
            txt_ndocument.Text = string.Empty;
            cbxestado.SelectedIndex = -1;
            cbxORDEN_GLOBAL_TRAS.SelectedIndex = -1;
            cbxProveedorTrans.SelectedIndex = -1;
            cbxTransporte.SelectedIndex = -1;
            txtMotoritsta.Text = string.Empty;
            txtNitMotor.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtNFormulario.Text = string.Empty;
            cbxProducto.SelectedIndex = -1;
            cbxPrestanciontras.SelectedIndex = -1;
            cbxUnidad.SelectedIndex = -1;
            speCantidad.Value = string.Empty;
            speFactor.Value = 0;
            lbGuid.Text = Convert.ToString(Guid.NewGuid());
            speFactorKg.Value = 0;
            lblSaldo.Text = string.Empty;

            txtAsignacionT.Value = 0;
            txtEjecutado.Value = 0;
            txtSaldo.Value = 0;

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
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataBind();


            cbxestado.Enabled = true;
            dteFecha.Enabled = true;
            rb_propio.Enabled = true;
            rb_Ajeno.Enabled = true;
            cbxZafraProd.Enabled = true;
            cbxZafraActual.Enabled = true;
            cbxtipoMovimiento.Enabled = true;
            cbxConceptoTM.Enabled = true;
            cbxEspecifico.Enabled = true;
            cbxBodegaOrigen.Enabled = true;
            cbxBodegaDestino.Enabled = true;
            txt_ndocument.Enabled = true;
            cbxestado.Enabled = true;
            cbxORDEN_GLOBAL_TRAS.Enabled = true;
            cbxProveedorTrans.Enabled = true;
            cbxTransporte.Enabled = true;
            txtMotoritsta.Enabled = true;
            txtNitMotor.Enabled = true;
            txtObservacion.Enabled = true;
            txtNFormulario.Enabled = true;
            cbxProducto.Enabled = true;
            cbxPrestanciontras.Enabled = true;
            cbxUnidad.Enabled = true;
            speCantidad.Enabled = true;
            speFactor.Enabled = true;
            speFactorKg.Enabled = true;
            lblSaldo.Enabled = true;

            CargarListas();
            ZafraACtual();
            cbxORDEN_GLOBAL_TRAS.Focus();
            //cbxestado.Value = 1;
            btnAgregarProductos.Enabled = true;
            btnAgregarProductos0.Enabled = true;
            ObtenerNDoc();

            FechaDoc();
            if (Convert.ToInt16(Session["FECHAHB"]) == 1) { dteFecha.ClientEnabled = true; }
            else { dteFecha.ClientEnabled = false; }
        }
        public void FechaDoc()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._SEL_FECHA_MOVIMIENTO();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    dteFecha.Value = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    dteFecha.Text = string.Empty;
                }

                Conn.cn.Close();

            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (System.Data.SqlClient.SqlException ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
            finally
            {
                Conn.cn.Close();

            }
        }
        private void llenarGridOrigenCPT(int idproducto, int idpresentacion, int idunidad, double cantidad, double factor, string Guid)
        {
            DataTable DT = (DataTable)Session["DT"];
            // 'Revisamos si ya existe el usuario
            DataRow[] DR;
            DR = DT.Select("ID_PRODUCTO = " + cbxProducto.Value);
            if (DR.Length > 0)
            {
                //lbl_mensaje.Text = "¡PRODUCTO YA EXISTE!";
                //lbl_mensaje.Visible = true;
                return;
            }
            else
            {
                //lbl_mensaje.Visible = false;
            }
            DT.Rows.Add(null, idproducto, idpresentacion, idunidad, cantidad, factor, Guid);
            //DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value));
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataBind();
            // Actualizamos el DataTable en la variable de session
            Session["DT"] = DT;
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataBind();
            //cn.Close();
        }
        private void CargarListas()
        {
            odsTRANSPORTE.DataBind();
            cbxTransporte.DataSourceID = "odsTRANSPORTE";
            cbxTransporte.DataBind();
            cbxTransporte.Value = 2;

            odsPROVEEDOR_TRAS.DataBind();
            cbxProveedorTrans.DataSourceID = "odsPROVEEDOR_TRAS";
            cbxProveedorTrans.DataBind();
            cbxProveedorTrans.Value = 47;


            odsESTADO_MOVIMIENTOS.DataBind();
            cbxestado.DataSourceID = "odsESTADO_MOVIMIENTOS";
            odsESTADO_MOVIMIENTOS.DataBind();

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



        }
        private void ZafraProducto()
        {
            if (Convert.ToString(cbxProducto.Text) == "")
            { }
            else if (Convert.ToString(cbxProducto.Text) != "")
            {
                odsZAFRA_PROD.DataBind();
                cbxZafraProd.DataSourceID = "odsZAFRA_PROD";
                odsZAFRA_PROD.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
                odsZAFRA_PROD.SelectParameters["TIPO"].DefaultValue = "V";
                cbxZafraProd.DataBind();
               cbxZafraProd.SelectedIndex = 0;
            }
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

                if (Convert.ToInt32(cbxProducto.Value) == 1)
                {
                   if (Convert.ToInt16(Session["ID_BODEP"]) == 29)
                    {
                        cbxBodegaDestino.Value = 18; //DIZUCAR.- INJIBOA
                        cbxBodegaDestino_TextChanged(null, null);
                    }
                    else if (Convert.ToInt16(Session["ID_BODEP"]) == 16)
                    {
                        cbxBodegaDestino.Value = 18; //DIZUCAR.- INJIBOA
                        cbxBodegaDestino_TextChanged(null, null);
                    }
                }
                else if (Convert.ToInt32(cbxProducto.Value) == 4)
                {
                   if (Convert.ToInt16(Session["ID_BODEP"]) == 29)
                    {
                        cbxBodegaDestino.Value = 18; //DIZUCAR.- INJIBOA
                        cbxBodegaDestino_TextChanged(null, null);
                    }
                    else if (Convert.ToInt16(Session["ID_BODEP"]) == 16)
                    {
                        cbxBodegaDestino.Value = 18; //DIZUCAR.- INJIBOA
                        cbxBodegaDestino_TextChanged(null, null);
                    }
                }
            }
            else { }
        }
        private void CargarEspecificoMov()
        {
            cbxEspecifico.DataSourceID = "odsESPECI_MOV";
            odsESPECI_MOV.SelectParameters["id"].DefaultValue = cbxConceptoTM.Value.ToString();
            odsESPECI_MOV.DataBind();
            cbxEspecifico.DataBind();
            cbxEspecifico.Value = 30;
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
        protected void ObtenerNDoc()
        {
            ENTRADA_SALIDA_ENCA lEntidadd = new CENTRADA_SALIDA_ENCA().ObtenerNDoc(Convert.ToInt32(1), Convert.ToInt32(Session["ID_BODEP"]));
            if (lEntidadd != null)
            {

                txt_ndocument.Text = lEntidadd.ULT_NUM_ASIGNADO;

            }
            if (lEntidadd == null)
            {
                txt_ndocument.Text = string.Empty;
            }
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
                KARDEX lEntidadK = new CKARDEX().ObtenerPorIdBodegaExist(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxZafraProd.Value), Convert.ToInt32(cbxBodegaOrigen.Value), Convert.ToDateTime(dteFecha.Text));
                if (lEntidadK != null)
                {
                    lblSaldo.Value = 0.00;
                    lblSaldo.Value = Convert.ToDecimal(lEntidadK.EXISTENCIA_BODE).ToString("N2");
                    lblPresentacion.Value = lEntidadK.PRESENTACION;
                    lblSaldo.Visible = true;
                    lblPresentacion.Visible = true;
                }
                if (lEntidadK == null)
                {
                    lblSaldo.Value = 0.00;
                    lblPresentacion.Value = string.Empty;
                    lblSaldo.Visible = true;
                    lblPresentacion.Visible = true;
                }
            }
        }

        protected void ObtenerdtBGDestino()
        {
            //PRESENTACION_TRAS lEntidad = new CPRESENTACION_TRAS().ObtenerPorId(Convert.ToInt32(cbxPrestanciontras.Value));
            BODEGA lEntidad = new CBODEGA().ObtenerPorId(Convert.ToInt32(cbxBodegaDestino.Value));
            if (lEntidad != null)
            {
                txtNit.Text = lEntidad.NIT;
                txtNrc.Text = lEntidad.NRC;
                txtGiro.Text = lEntidad.GIRO;
                txtDireccion.Text = lEntidad.DIRECCION;
                txtDepartamento.Text = lEntidad.NOMDEPARTAMENTO;
                txtMunicipio.Text = lEntidad.NOMMUNICIPIO;
            }
            if (lEntidad == null)
            {
                txtNit.Text = string.Empty;
                txtNrc.Text = string.Empty;
                txtGiro.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtDepartamento.Text = string.Empty;
                txtMunicipio.Text = string.Empty;
            }
        }

        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            ZafraProducto();
            CargarUnidida_Fac();
            CargarPresentacion_tras();
            ObtenerFactor();
            IdBodegaOrigen();
            IdBodegaDestino();
            CargarConceptosMovi();
            ObtenerExistencia();
            cbxtipoMovimiento.SelectedIndex = 1;
            cbxtipoMovimiento_TextChanged(null, null);

            if (Convert.ToInt32(cbxProducto.Value) == 5 || Convert.ToInt32(cbxProducto.Value) == 2)
            { speCantidad.Value = 0; }
            else { speCantidad.Value = string.Empty; }
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
        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            DataTable DT = (DataTable)Session["DT"];
            // 'Revisamos si ya existe el usuario
            DataRow[] DR;
            DR = DT.Select("ID_PRODUCTO = " + cbxProducto.Value);
            if (DR.Length > 0)
            {
                //lbl_mensaje.Text = "¡PRODUCTO YA EXISTE!";
                //lbl_mensaje.Visible = true;
                return;
            }
            else
            {
                //lbl_mensaje.Visible = false;
            }
            DT.Rows.Add(null, Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToInt32(speCantidad.Value), Convert.ToSingle(speFactor.Value), Convert.ToString(lbGuid.Text));
            //DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value));
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataBind();
            // Actualizamos el DataTable en la variable de session
            Session["DT"] = DT;
            UcListaENTRADA_SALIDA_DETA_TRASLADO._gridLista.DataBind();
            //cn.Close();
            // btnAgregarProductos0.Enabled = false;
            btnAgregarProductos.Enabled = false;
        }


        protected void cbxORDEN_GLOBAL_TRAS_TextChanged(object sender, EventArgs e)
        {
            ORDEN_GLOBAL_TRAS lEntidad = new CORDEN_GLOBAL_TRAS().ObtenerPorId(Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value), Convert.ToInt32(Session["ID_BODEP"]));
            //            DOCTO_DETA lEntidaddt = new CDOCTO_DETA().ObtenerPorId(Convert.ToInt32(txt_CodCaptura.Value));
            if (lEntidad != null)
            {
                formLayout.FindItemOrGroupByName("Saldo").ClientVisible = true;
                //ENCABEZADO
                //txt_ndocument.Text = Convert.ToString(lEntidad.NO_DOCTO);
                //dteFecha.Value = lEntidad.FECHA;
                txtIdentificador.Text = "0";
                cbxProducto.Value = lEntidad.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);

                cbxZafraProd.Value = lEntidad.ID_ZAFRA_PROD;
                cbxtipoMovimiento.Value = lEntidad.ID_TIPO_MOV;
                cbxtipoMovimiento_TextChanged(null, null);
                cbxConceptoTM.Value = lEntidad.ID_CONCE;
                cbxConceptoTM_TextChanged(null, null);
                cbxEspecifico.Value = lEntidad.ID_ESPECI;
                cbxestado.Value = lEntidad.ID_ESTADO;
                cbxORDEN_GLOBAL_TRAS.Value = lEntidad.ID_ORDEN_TRAS;
                cbxBodegaOrigen.Value = lEntidad.ID_BODEGAO;
                cbxBodegaOrigen_TextChanged(null, null);
                cbxBodegaDestino.Value = lEntidad.ID_BODEGAD;
                cbxBodegaDestino_TextChanged(null, null);

                //txtAsignacionO.Value = Convert.ToDouble(Entidad.ASIGNACIONO);
                //txtAmpliaciones.Value = Convert.ToDouble(Entidad.AMPLIACIONES);
                txtAsignacionT.Value = Convert.ToDouble(lEntidad.ASIGNACIONT);
                txtEjecutado.Value = Convert.ToDouble(lEntidad.EJECUTADO);
                txtSaldo.Value = Convert.ToDouble(lEntidad.SALDO);
                //DETALLE
                cbxProducto.Enabled = false;
                cbxZafraProd.Enabled = false;
                cbxtipoMovimiento.Enabled = false;
                cbxConceptoTM.Enabled = false;
                cbxEspecifico.Enabled = false;
                cbxestado.Enabled = false;
                //cbxORDEN_GLOBAL_TRAS.Enabled = false;
                cbxBodegaOrigen.Enabled = false;
                cbxBodegaDestino.Enabled = false;
                cbxUnidad.Enabled = false;
                cbxPrestanciontras.Enabled = false;
                rb_Ajeno.Enabled = false;
                rb_propio.Enabled = false;
                speFactor.Enabled = false;
                speFactorKg.Enabled = false;
            }
            else
            {
                formLayout.FindItemOrGroupByName("Saldo").ClientVisible = false;
                cbxProducto.Enabled = true;
                cbxZafraProd.Enabled = true;
                cbxtipoMovimiento.Enabled = true;
                cbxConceptoTM.Enabled = true;
                cbxEspecifico.Enabled = true;
                cbxestado.Enabled = true;
                cbxORDEN_GLOBAL_TRAS.Enabled = true;
                cbxBodegaOrigen.Enabled = true;
                cbxBodegaDestino.Enabled = true;
                cbxUnidad.Enabled = true;
                cbxPrestanciontras.Enabled = true;
                rb_Ajeno.Enabled = true;
                rb_propio.Enabled = true;
                speFactor.Enabled = true;
                speFactorKg.Enabled = true;
                txtAsignacionT.Value = 0;
                txtEjecutado.Value = 0;
                txtSaldo.Value = 0;
                Nuevo();
            }
        }

        protected void cbxBodegaOrigen_TextChanged(object sender, EventArgs e)
        {
            ObtenerExistencia();
        }

        protected void speCantidad_ValueChanged(object sender, EventArgs e)
        {
            //double CantMax = 0;
            //CantMax = (Convert.ToDouble(lblSaldo.Value));
            //if (Convert.ToDouble(speCantidad.Value) > CantMax)
            //{
            //    lbl_mensaje.Text = "LA CANTIDAD MAXIMA ES : " + Convert.ToString(lblSaldo.Value) + " " + Convert.ToString(lblPresentacion.Text);
            //    lbl_mensaje.Visible = true;
            //}

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


        #endregion

        #region "Atributos"
        public DevExpress.Web.ASPxTextBox txt_Identificador
        {
            get { return txtIdentificador; }
            set { txtIdentificador = value; }
        }
        public DevExpress.Web.ASPxComboBox cbx_Producto
        {
            get { return cbxProducto; }
            set { cbxProducto = value; }
        }
        #endregion
    }
}
