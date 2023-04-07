using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
using DevExpress.Web;


namespace ADMINPT.controles.movimiento_despacho
{
    public partial class UcVistaENTRADA_SALIDA_ENCA_DESPACHO : System.Web.UI.UserControl
    {
        #region "Propiedades"
        private CENTRADA_SALIDA_ENCA Controlador = new CENTRADA_SALIDA_ENCA();
        private CENTRADA_SALIDA_DETA ControladorDt = new CENTRADA_SALIDA_DETA();

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
        private void DetFact()
        {
            
            DataSet DS_DT = new DataSet("DS_DT");
            DataTable DT = DS_DT.Tables.Add("DT");
          
            try
            {
                Conn.cn.Close();
                Conn.cn.Open();

                DT = CDats.SEL_ENTRADA_SALIDA_DETA(Convert.ToInt32(txtIdentificador.Text));

                //DT.Columns.Add(new System.Data.DataColumn("ID_ES_DETA", typeof(System.Int32)));
                //DT.PrimaryKey = new DataColumn[1] { DT.Columns["ID_ES_DETA"] };
                //DT.Columns["ID_ES_DETA"].AutoIncrement = true;
                //DT.Columns.Add("ID_PRODUCTO", Type.GetType("System.Int32"));
                //DT.Columns.Add("ID_PRESEN_TRAS", Type.GetType("System.Int32"));
                //DT.Columns.Add("ID_UNIDAD_FAC", Type.GetType("System.Int32"));
                //DT.Columns.Add("CANTIDAD", Type.GetType("System.Single"));
                //DT.Columns.Add("FACTOR", Type.GetType("System.Single"));
                //DT.Columns.Add("REFERENCIA_DETA", Type.GetType("System.String"));
                //DT.Clear();
                speCantidad.Value = 0;
               
                foreach (DataRow dr in DT.Rows)
                {
                    speCantidad.Value = Convert.ToInt32(speCantidad.Value) + Convert.ToInt32(dr["cantidad"]);
                }
                Sds_lista.SelectParameters["ID_ES_ENCA"].DefaultValue = Convert.ToString(txtIdentificador.Text);
                gridListaup.DataBind();
                gridListaup.ClientVisible = true;

                Conn.cn.Close();
            }
            catch (System.Data.OleDb.OleDbException sqlEx)
            {
                lbl_mensaje.Text = sqlEx.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cnph.Close();
               
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

                txtObservacion.Text = Entidad.OBSERVACION;


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
                //txtIdentificador.Text = EntidadDt.ID_ES_ENCA.ToString();

                //DETALLE
                cbxProducto.Value = EntidadDt.ID_PRODUCTO;
                cbxProducto_TextChanged(null, null);
                speCantidad.Value = EntidadDt.CANTIDAD;

                llenarGridOrigenCPT(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToDouble(speCantidad.Value), Convert.ToDouble(speFactor.Value), Convert.ToString(lbGuid.Text));


            }


        }
        private void CargarVistaCodBarra()
        {
            //ModoEdicion(true);

           // CargarListas();
            ENTRADA_SALIDA_ENCA Entidad = Controlador.ObtenerPorId(Convert.ToInt32(txtIdentificador.Text));
            if (Entidad != null)
            {
                //txtIdentificador.Text = Entidad.ID_ES_ENCA.ToString();
                //ENCABEZADO
                txtFechaDespacho.Value = Entidad.FECHADESPACHO;
                dteFecha.Value = Entidad.FECHA;
                cbxestado.Value = Entidad.ID_ESTADO;
                txt_ndocument.Text = Entidad.NUM_DOC;
                Sds_ENTRADA_SALIDA_CLIENTE.DataBind();
                ListViewCliente.DataBind();

                rb_propio.Value = Entidad.ES_PROPIO;
                rb_Ajeno.Value = Entidad.ES_AJENO;
                cbxZafraProd.Value = Entidad.ID_ZAFRA_PROD ;
                cbxZafraActual.Value = Entidad.ID_ZAFRA_ACTUAL ;

                if( Convert.ToInt32(Entidad.ID_PROV_TRAS) != 0)
                {
                    formLayout.FindItemOrGroupByName("transporte").ClientVisible = true;
                    cbxProveedorTrans.Value = Entidad.ID_PROV_TRAS;
                    cbxTransporte.Value = Entidad.ID_TRANSPORTE;
                    txtMotoritsta.Text = Entidad.MOTORISTA;
                    txtNitMotor.Text = Entidad.NIT;
                }
                else { formLayout.FindItemOrGroupByName("transporte").ClientVisible = false; }

                FechaDoc();

                //if (Convert.ToString(txt_ndocbuscar.Text.Trim()) == "")
                //{  }

              }

                ENTRADA_SALIDA_DETA EntidadDt = ControladorDt.ObtenerPorIdEnc(Convert.ToInt32(txtIdentificador.Text));
            if (EntidadDt != null)
            {
                               //DETALLE
                cbxProducto.Value = EntidadDt.ID_PRODUCTO;
               cbxProducto_TextChanged(null, null);


                cbxtipoMovimiento.Value = Entidad.ID_TIPO_MOV;
                cbxtipoMovimiento_TextChanged(null, null);
                cbxConceptoTM.Value = Entidad.ID_CONCE;
                cbxConceptoTM_TextChanged(null, null);
                cbxEspecifico.Value = Entidad.ID_ESPECI;


                IdBodegaOrigen();
                cbxBodegaOrigen.Value = Entidad.ID_BODEGAO;



                if (Convert.ToInt32(Entidad.ID_BODEGAD) != 0)
                {
                    IdBodegaDestino();
                    cbxBodegaDestino.Value = Entidad.ID_BODEGAD;
                    cbxBodegaDestino_TextChanged(null, null);
                }
                else
                {
                    cbxBodegaDestino.Text = Convert.ToString(Entidad.ENCCLIENTE);
                    txtNit.Text = Convert.ToString(Entidad.ENCNIT);
                    txtDepartamento.Text = Convert.ToString(Entidad.ENCDEPARTAMENTO);
                    txtMunicipio.Text = Convert.ToString(Entidad.ENCMUNICIPIO);
                    txtDireccion.Text = Convert.ToString(Entidad.ENCDIRECCION);
                    txtNrc.Text = Convert.ToString(Entidad.ENCNRC);
                    txtGiro.Text = Convert.ToString(Entidad.ENCGIRO);
                }

                DetFact();

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
            //txtNFormulario.ClientEnabled = esEdicion;
            cbxProducto.ClientEnabled = esEdicion;
            cbxPrestanciontras.ClientEnabled = esEdicion;
            cbxUnidad.ClientEnabled = esEdicion;
            speCantidad.ClientEnabled = esEdicion;
            speFactor.ClientEnabled = esEdicion;
            speFactorKg.ClientEnabled = esEdicion;
            lblSaldo.ClientEnabled = esEdicion;
        }

        public string ActualizarDespacho()
        {
            string  Result = "0";
            if (Convert.ToInt32(Session["ID_BODEP"]) == 0)
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! Se cerró la sesión !','error') </script>"); }
            else if (Convert.ToInt32(cbxZafraProd.Value) == 0)
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! ZAFRA REQUERIDA !','error') </script>"); }
            else
            {
                if (rdbinfs.Checked == true && rdbinfn.Checked == false)
                {
                    cbxEstiba.ValidationSettings.RequiredField.IsRequired = true;
                    cbxEstiba.ValidationSettings.Display = DevExpress.Web.Display.Dynamic;
                    cbxEstiba.ValidationSettings.RequiredField.ErrorText = "Requerido !!!";
                    cbxEstiba.Validate();
                    /////////////////////
                    txt_tendido.ValidationSettings.RequiredField.IsRequired = true;
                    txt_tendido.ValidationSettings.Display = DevExpress.Web.Display.Dynamic;
                    txt_tendido.ValidationSettings.RequiredField.ErrorText = "Requerido !!!";
                    txt_tendido.Validate();
                    /////////////////////
                    txt_color.ValidationSettings.RequiredField.IsRequired = true;
                    txt_color.ValidationSettings.Display = DevExpress.Web.Display.Dynamic;
                    txt_color.ValidationSettings.RequiredField.ErrorText = "Requerido !!!";
                    txt_color.Validate();
                    /////////////////////
                    txt_fechaProduccion.ValidationSettings.RequiredField.IsRequired = true;
                    txt_fechaProduccion.ValidationSettings.Display = DevExpress.Web.Display.Dynamic;
                    txt_fechaProduccion.ValidationSettings.RequiredField.ErrorText = "Requerido !!!";
                    txt_fechaProduccion.Validate();
                    /////////////////////
                    txt_tendido.ValidationSettings.RequiredField.IsRequired = true;
                    txt_tendido.ValidationSettings.Display = DevExpress.Web.Display.Dynamic;
                    txt_tendido.ValidationSettings.RequiredField.ErrorText = "Requerido !!!";
                    txt_tendido.Validate();
                }
                if (rdbzfcs.Checked == false && rdbzfcn.Checked == false)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Validar Zafra del Producto !','error') </script>");
                }
                else
                {
                    ENTRADA_SALIDA_ENCA Entidad = new ENTRADA_SALIDA_ENCA();
                    Entidad.ID_ES_ENCA = Convert.ToInt32(txtIdentificador.Text);
                    Entidad.USUARIO_CREA = Convert.ToString(Session["USUARIO"]);
                    Entidad.FECHADESPACHO = Convert.ToDateTime(txtFechaDespacho.Text);

                    if (Convert.ToString(cbxEstiba.Text) == "")
                    { Entidad.ID_ESTIBA = Convert.ToString(DBNull.Value); }
                    else { Entidad.ID_ESTIBA = Convert.ToString(cbxEstiba.KeyValue.ToString()); }
                    if (Convert.ToString(txt_tendido.Text) == "")
                    { Entidad.TENDIDO = Convert.ToString(DBNull.Value); }
                    else { Entidad.TENDIDO = Convert.ToString(txt_tendido.Text); }
                    if (Convert.ToString(txt_fechaProduccion.Text) == "")
                    { Entidad.FECHA_PRODUCCION = Convert.ToDateTime("1/1/1999"); }
                    else { Entidad.FECHA_PRODUCCION = Convert.ToDateTime(txt_fechaProduccion.Text); }

                    if (Convert.ToString(txt_fechaProduccion2.Text) == "")
                    { Entidad.FECHA_PRODUCCION1 = Convert.ToDateTime("1/1/1999"); }
                    else { Entidad.FECHA_PRODUCCION1 = Convert.ToDateTime(txt_fechaProduccion2.Text); }
                    if (Convert.ToString(txt_color.Text) == "")
                    { Entidad.COLOR = Convert.ToDouble(0); }
                    else { Entidad.COLOR = Convert.ToDouble(txt_color.Text); }

                    Entidad.ID_ZAFRA_PROD = Convert.ToInt32(cbxZafraProd.Value);
                    Entidad.OBSERVACION = Convert.ToString(txtObservacion.Text);
                    // Controlador.ActualizarDespacho(Entidad);
                    Result = Convert.ToString(Controlador.ActualizarDespacho(Entidad));
                }
            }
                return Result;
        }

        public string ActualizarVtaDizucar()
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

            Entidad.OBSERVACION = Convert.ToString(txtObservacion.Text);
            Entidad.NFORMULARIO = Convert.ToString(DBNull.Value);
            //detalle


            //   EntidadDt.ID_ES_ENCA = 0;//Entidad.ID_ES_ENCA;
            EntidadDt.ID_PRODUCTO = Convert.ToInt32(cbxProducto.Value);
            EntidadDt.ID_PRESEN_TRAS = Convert.ToInt32(cbxPrestanciontras.Value);
            EntidadDt.ID_UNIDAD_FAC = Convert.ToInt32(cbxUnidad.Value);
            EntidadDt.CANTIDAD = Convert.ToSingle(speCantidad.Value);
            EntidadDt.FACTOR = Convert.ToDouble(speFactor.Value);
            EntidadDt.REFERENCIA_DETA = Guid.NewGuid();
            EntidadDt.FACTORKG = Convert.ToDouble(speFactorKg.Value);

            Controlador.ActualizarVtaDizucar(ref Entidad);
            EntidadDt.ID_ES_ENCA = Entidad.ID_ES_ENCA;
            Session["ID_ES_ENCA"] = Entidad.ID_ES_ENCA;
            ControladorDt.ActualizarVtaDizucar(EntidadDt);
            Result = ControladorDt.sError;
            txt_CodCaptura.Focus();
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
            txtFechaDespacho.Value = DateTime.Now.ToString();
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
            //txtNFormulario.Text = string.Empty;
            cbxProducto.SelectedIndex = -1;
            cbxPrestanciontras.SelectedIndex = -1;
            cbxUnidad.SelectedIndex = -1;
            speCantidad.Value = string.Empty;
            speFactor.Value = 0;
            lbGuid.Text = Convert.ToString(Guid.NewGuid());
            speFactorKg.Value = 0;
            lblSaldo.Text = string.Empty;



            // Creamos el DataTable
          


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
            //txtNFormulario.Enabled = true;
            cbxProducto.Enabled = true;
            cbxPrestanciontras.Enabled = true;
            cbxUnidad.Enabled = true;
            speCantidad.Enabled = true;
            speFactor.Enabled = true;
            speFactorKg.Enabled = true;
            lblSaldo.Enabled = true;

            CargarListas();
            ZafraACtual();

            // cbxestado.Value = 1;

            FechaDoc();
            //if (Convert.ToInt16(Session["FECHAHB"]) == 1) { txtFechaDespacho.ClientEnabled = true; }
            //else { txtFechaDespacho.ClientEnabled = false; }

            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
            txt_CodCaptura.Focus();

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
                    txtFechaDespacho.Value = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    txtFechaDespacho.Text = string.Empty;
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



            odsESTADO_MOVIMIENTOS.DataBind();
            cbxestado.DataSourceID = "odsESTADO_MOVIMIENTOS";
            odsESTADO_MOVIMIENTOS.DataBind();

            odsZAFRA_PROD.DataBind();
            cbxZafraProd.DataSourceID = "odsZAFRA_PROD";
            cbxZafraProd.DataBind();

            odsCLIENTE.DataBind();
            cbxCliente.DataSourceID = "odsCLIENTE";
            cbxCliente.DataBind();

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
                //cbxBodegaDestino_TextChanged(null, null);
            }
            else { }
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
                cbxConceptoTM.SelectedIndex = -1;
                //cbxConceptoTM_TextChanged(null, null);
            }
            else { }
        }
        private void CargarEspecificoMov()
        {
            cbxEspecifico.DataSourceID = "odsESPECI_MOV";
            odsESPECI_MOV.SelectParameters["id"].DefaultValue = cbxConceptoTM.Value.ToString();
            odsESPECI_MOV.DataBind();
            cbxEspecifico.DataBind();
            cbxEspecifico.SelectedIndex = -1;
        }
        
        private void CargarUnidida_Fac()
        {
            cbxUnidad.DataSourceID = "odsUNIDAD_MEDI_FAC";
            odsUNIDAD_MEDI_FAC.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsUNIDAD_MEDI_FAC.DataBind();
            cbxUnidad.DataBind();
           
            if(Convert.ToString(txt_CodCaptura.Text)=="")
            { cbxUnidad.SelectedIndex = 1; }  else { cbxUnidad.SelectedIndex = -1; }

        }

        private void CargarPresentacion_tras()
        {
            cbxPrestanciontras.DataSourceID = "odsPRESENTACION_TRAS";
            odsPRESENTACION_TRAS.SelectParameters["id"].DefaultValue = cbxProducto.Value.ToString();
            odsPRESENTACION_TRAS.DataBind();
            cbxPrestanciontras.DataBind();
            
            if (Convert.ToString(txt_CodCaptura.Text) == "")
            { cbxPrestanciontras.SelectedIndex = 1; } else { cbxPrestanciontras.SelectedIndex = -1; }
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
            CargarUnidida_Fac();
            CargarPresentacion_tras();
           // ObtenerFactor();
           IdBodegaOrigen();
            IdBodegaDestino();
            CargarConceptosMovi();
            cbxtipoMovimiento_TextChanged(null, null);
            ObtenerExistencia();
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
            if (Convert.ToInt32(cbxConceptoTM.Value)==16 || Convert.ToInt32(cbxConceptoTM.Value) == 17) 
            { formLayout.FindItemOrGroupByName("cdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("ccfdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("cantdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("opdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("dtdizucar").ClientVisible = true;
            }
            else
            {
                formLayout.FindItemOrGroupByName("cdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("ccfdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("cantdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("opdizucar").ClientVisible = false;
                formLayout.FindItemOrGroupByName("dtdizucar").ClientVisible = false;
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
        protected void btAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToString(txt_ndocument.Text) == "" & Convert.ToString(cbxCliente.Text) == "" & Convert.ToString(txtCcf.Text) == "" & Convert.ToString(txtCantidaCliente.Text) == "")
                { lbMensajeAgregar.Text = "N° Documento Requerido !!!"; lbMensajeAgregar.Visible = true; }
                else if (Convert.ToString(txt_ndocument.Text) != "" & Convert.ToString(cbxCliente.Text) == "" & Convert.ToString(txtCcf.Text) == "" & Convert.ToString(txtCantidaCliente.Text) == "")
                { lbMensajeAgregar.Text = "Cliente Requerido !!!"; lbMensajeAgregar.Visible = true; }
                else if (Convert.ToString(txt_ndocument.Text) != "" & Convert.ToString(cbxCliente.Text) != "" & Convert.ToString(txtCcf.Text) == "" & Convert.ToString(txtCantidaCliente.Text) == "")
                { lbMensajeAgregar.Text = "CCF/FA Requerido !!!"; lbMensajeAgregar.Visible = true; }
                else if (Convert.ToString(txt_ndocument.Text) != "" & Convert.ToString(cbxCliente.Text) != "" & Convert.ToString(txtCcf.Text) != "" & Convert.ToString(txtCantidaCliente.Text) == "")
                { lbMensajeAgregar.Text = "Cantidad Requerido !!!"; lbMensajeAgregar.Visible = true; }
                else if (Convert.ToString(txt_ndocument.Text) != "" & Convert.ToString(cbxCliente.Text) != "" & Convert.ToString(txtCcf.Text) != "" & Convert.ToString(txtCantidaCliente.Text) != "")
                {
                    //lbMensajeAgregar.Text = "FUNCIONA"; lbMensajeAgregar.Visible = true;
                    //else { lbMensajeAgregar.Text = string.Empty; lbMensajeAgregar.Visible = false;
                    //    cbxCliente.SelectedIndex = -1;

                    Conn.cn.Close();
                    Conn.cn.Open();
                    SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_CLIENTE", Conn.cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    guardar.Parameters.AddWithValue("@ID_ES_ENCA", txtIdentificador.Text);
                    guardar.Parameters.AddWithValue("@FECHA", dteFecha.Text);
                    guardar.Parameters.AddWithValue("@NUM_DOC", txt_ndocument.Text);
                    guardar.Parameters.AddWithValue("@ID_CLIENTE", cbxCliente.Value);
                    guardar.Parameters.AddWithValue("@CCF_FA", txtCcf.Text);
                    guardar.Parameters.AddWithValue("@CANTIDAD", txtCantidaCliente.Text);
                    guardar.ExecuteNonQuery();

                    lbMensajeAgregar.Text = string.Empty; lbMensajeAgregar.Visible = false;
                    cbxCliente.SelectedIndex = -1;
                    txtCcf.Text = string.Empty;
                    txtCantidaCliente.Text = string.Empty;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Mensaje!', '! " + Message + " !', 'error');", true);
                }
                Conn.cn.Close();

            }
#pragma warning disable CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            catch (System.Data.SqlClient.SqlException sqlEx)
#pragma warning restore CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            {
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Mensaje!', '! " + sqlEx.Message + " !', 'error');", true);
            }
#pragma warning disable CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            catch (Exception sqlEx)
#pragma warning restore CS0168 // La variable 'sqlEx' se ha declarado pero nunca se usa
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Mensaje!', '! " + sqlEx.Message + " !', 'error');", true);

            }
            finally
            {
                Conn.cn.Close();
                Sds_ENTRADA_SALIDA_CLIENTE.DataBind();
                ListViewCliente.DataBind();
            }

        }
        protected void ListViewCliente_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {

        }

        protected void ListViewCliente_SummaryDisplayText(object sender, DevExpress.Web.ASPxGridViewSummaryDisplayTextEventArgs e)
        {

        }

        protected void ListViewCliente_DataBound(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            grid.JSProperties["cp_SUBTOTALSummary"] = Convert.ToDecimal(grid.GetTotalSummaryValue(grid.TotalSummary["CANTIDAD"])).ToString();
        }

        protected void txt_CodCaptura_TextChanged(object sender, EventArgs e)
        {
            txt_ndocbuscar.Text = string.Empty;
            if (Convert.ToString(txt_CodCaptura.Text.Trim()) != "")
            {
                txtIdentificador.Text = txt_CodCaptura.Text.Trim();
                if (Convert.ToString(txtIdentificador.Text.Trim()) != "")
                { CargarVistaCodBarra(); }
                else { Nuevo(); } 
            }
            else { txtIdentificador.Text = string.Empty;
                Nuevo();
            }
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

        protected void rdbzfcn_CheckedChanged(object sender, EventArgs e)
        {if (Convert.ToString(txt_CodCaptura.Text.Trim()) == string.Empty)
            { }
            else
            {
                cbxZafraProd.ClientEnabled = true;
                cbxZafraProd.SelectedIndex = -1;
            }
        }

        protected void rdbinfn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbinfs.Checked == false & rdbinfn.Checked == true)
            {
                cbxEstiba.ValidationSettings.RequiredField.IsRequired = false;
                cbxEstiba.Validate();
                /////////////////////
                txt_tendido.ValidationSettings.RequiredField.IsRequired = false;
                txt_tendido.Validate();
                /////////////////////
                txt_color.ValidationSettings.RequiredField.IsRequired = false;
                txt_color.Validate();
                /////////////////////
                txt_fechaProduccion.ValidationSettings.RequiredField.IsRequired = false;
                txt_fechaProduccion.Validate();
                /////////////////////
                txt_tendido.ValidationSettings.RequiredField.IsRequired = false;
                txt_tendido.Validate();
            }
            
        }

        protected void gridListaup_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "NOMBRE_PRODUCTO")
            {
                PRODUCTO lEntidad = new CPRODUCTO().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRODUCTO"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_KARDEX;
            }
            else if (e.Column.FieldName == "NOMBRE_PRESEN_TRAA")
            {
                PRESENTACION_TRAS lEntidad = new CPRESENTACION_TRAS().ObtenerPorId((int)e.GetListSourceFieldValue("ID_PRESEN_TRAS"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_PRESEN_TRAA;
            }
            else if (e.Column.FieldName == "NOMBRE_UNIDAD")
            {
                UNIDAD_MEDI_FAC lEntidad = new CUNIDAD_MEDI_FAC().ObtenerPorId((int)e.GetListSourceFieldValue("ID_UNIDAD_FAC"));
                if (lEntidad != null)
                    e.Value = lEntidad.NOMBRE_UNIDAD;
            }
        }

        public void dtnot()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._VIEW_PRODUCTO_ENTSALID(Convert.ToDateTime(txtFechaDespacho.Text), Convert.ToString(txt_ndocbuscar.Text), Convert.ToInt32(cb_bodegaO.Value));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtIdentificador.Text = Convert.ToString(row["ID_ES_ENCA"].ToString());
                }
                else
                {
                    txtIdentificador.Text = string.Empty;
                    txt_ndocbuscar.Text= string.Empty;
                    txtFechaDespacho.Text = string.Empty;
                    Nuevo();
                }

                Conn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
            }
            catch (Exception sqlEx)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
            }
            finally
            {
                Conn.cn.Close();
            }
        }

        protected void txt_ndocbuscar_TextChanged(object sender, EventArgs e)
        {
            txt_CodCaptura.Text = string.Empty;
            if (Convert.ToString(txt_ndocbuscar.Text.Trim()) != "")
            {
                dtnot();
                if (Convert.ToString(txtIdentificador.Text.Trim()) != "")
                { CargarVistaCodBarra(); }
                else { Nuevo(); }
            }
            else { txtIdentificador.Text = string.Empty;
                Nuevo();
            }
        }
    }
}
