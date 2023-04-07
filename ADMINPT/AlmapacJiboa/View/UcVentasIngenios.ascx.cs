using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;


namespace ADMINPT.AlmapacJiboa.View
{
    public partial class UcVentasIngenios : System.Web.UI.UserControl
    {
        //EVENTOS
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicio();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Cancelar_Click += _btn_cancelar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporteDia_Click;


        }
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            //InicializarDetalle(false);
            //UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            InsEnc();
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            //InicializarDetalle(false);
            //UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            //InicializarDetalle(false);
            //UcVistaENTRADA_SALIDA_ENCA_VTJIBOAM.Identificador = 0;

            UCBarraNavegacion.btn_nuevo.Visible = true;
            UCBarraNavegacion.btn_guardar.Visible = false;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = false;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporteDia_Click(object sender, EventArgs e)
        {
            FechaDoc();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();
            string mv = "2";
            string TipoRpt = "";

            TipoRpt = "11";
            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dt_fecha.Value) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-3") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dt_fecha.Value) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-3") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dt_fecha.Value) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-3") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dt_fecha.Value) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-3") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dt_fecha.Value) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-3") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }
        protected void cbxTipoDocument_TextChanged(object sender, EventArgs e)
        {
            ObtenerNDoc();
        }

        //FUNCIONES
        private void Inicio()
        {
            UCEncabezado.Titulo = "VENTA A INGENIOS";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            Nuevo();
            txtIdentificador.Text = "0";
            FechaDoc();
            CargarListas();
        }
        private void Nuevo()
        {
            cbxORDEN_GLOBAL_TRAS.SelectedIndex = -1;
            txtIdentificador.Text = string.Empty;
            dt_fecha.Text = string.Empty;
            cbxestado.SelectedIndex = -1;
            cbxTipoDocument.SelectedIndex = -1;
            txt_ndocument.Text = string.Empty;
            cbxProducto.SelectedIndex = -1;
            cbxPrestanciontras.SelectedIndex = -1;
            cbxUnidad.SelectedIndex = -1;
            speFactor.Text = string.Empty;
            speFactorKg.Text = string.Empty;
            cbxZafraProd.SelectedIndex = -1;
            cbxZafraActual.SelectedIndex = -1;
            cbxtipoMovimiento.SelectedIndex = -1;
            cbxConceptoTM.SelectedIndex = -1;
            cbxEspecifico.SelectedIndex = -1;
            cbxBodegaOrigen.SelectedIndex = -1;
            speCantidad.Value = 0;
            cb_cliente.SelectedIndex = -1;
            txtNit.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtIdentificador.Text = "0";
            //speCantidadMt.Value = string.Empty;
            speFactorTm.Value = string.Empty;
            CargarListas();
            FechaDoc();
            if (Convert.ToInt16(Session["FECHAHB"]) == 1) { dt_fecha.ClientEnabled = true; }
            else { dt_fecha.ClientEnabled = false; }
        }
        protected void ObtenerNDoc()
        {


            DataTable Dt = new DataTable();
            SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            SqlDataAdapter Dadapter;
            cn.Close();
            cn.Open();
            var View = new SqlCommand("VIEW_DOCUMENTO_NUMERACION", cn);
            View.CommandType = CommandType.StoredProcedure;
            View.Parameters.AddWithValue("@ID_TIPO", cbxTipoDocument.Value);
            View.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(Session["ID_BODEP"]));

            Dadapter = new SqlDataAdapter(View);
            Dadapter.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                DataRow row = Dt.Rows[0];

                //txt_cod.Text = row["ID_MVWIN"].ToString();
                txt_ndocument.Text = row["ULT_NUM_ASIGNADO"].ToString();
                //cb_produccionTarima.DataBind();
                //cb_produccionTarima.Value = Convert.ToInt32(row["PRODUCCION_TARIMA"]);
                //cb_produccionJumbo.DataBind();
                //cb_produccionJumbo.Value = Convert.ToInt32(row["PRODUCCION_JUMBO"]);
                //cb_produccionCruada.DataBind();
                //cb_produccionCruada.Value = Convert.ToInt32(row["PRODUCCION_CRUDA"]);
                //cb_produccionMelaza.DataBind();
                //cb_produccionMelaza.Value = Convert.ToInt32(row["PRODUCCION_MELAZA"]);
                //cb_transladoCe5Dizucar.DataBind();
                //cb_transladoCe5Dizucar.Value = Convert.ToInt32(row["TRASLADO_CE5DIZUCAR"]);
                //cb_transladoInterno.DataBind();
                //cb_transladoInterno.Text = row["NOM_TRANSLADO_INTERNO"].ToString();
            }
            else
            {
            }
            cn.Close();

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

                    dt_fecha.Value = Convert.ToDateTime(row["FECHA"].ToString());
                }
                else
                {
                    dt_fecha.Value = DateTime.Now;
                }

                Conn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)

            {

            }

            catch (Exception ex)

            {

            }
            finally
            {
                Conn.cn.Close();

            }
        }
        private void CargarListas()
        {
            odsESTADO_MOVIMIENTOS.DataBind();
            cbxestado.DataSourceID = "odsESTADO_MOVIMIENTOS";
            odsESTADO_MOVIMIENTOS.DataBind();
            odsTIPO_MOVIMIENTO.DataBind();
            cbxtipoMovimiento.DataSourceID = "odsTIPO_MOVIMIENTO";
            cbxtipoMovimiento.DataBind();
            ZafraACtual();
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
                //cbxBodegaDestino.DataSourceID = "odsBodegaDUser";
                //odsBodegaDUser.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
                //cbxBodegaDestino.DataBind();
                //cbxBodegaDestino.SelectedIndex = -1;
            }
            else { }
        }
        private void CargarEspecificoMov()
        {
            if (this.cbxConceptoTM.SelectedItem == null || this.cbxConceptoTM.SelectedIndex == -1)
            { }
            else
            {
                odsESPECI_MOV.DataBind();
                cbxEspecifico.DataSourceID = "odsESPECI_MOV";
                odsESPECI_MOV.SelectParameters["id"].DefaultValue = cbxConceptoTM.Value.ToString();

                cbxEspecifico.DataBind();
                cbxEspecifico.Value = 42;
            }
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
                speFactorTm.Value = lEntidad.FMT;

            }
            if (lEntidad == null)
            {
                speFactor.Value = 0;
                speFactorKg.Value = 0;
                speFactorTm.Value = 0;
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
                KARDEX lEntidadK = new CKARDEX().ObtenerPorIdBodegaExist(Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxZafraProd.Value), Convert.ToInt32(cbxBodegaOrigen.Value), Convert.ToDateTime(dt_fecha.Text));
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

        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            if (this.cbxProducto.SelectedItem == null || this.cbxProducto.SelectedIndex == -1)
            { }
            else
            {
                ZafraProducto();
                CargarUnidida_Fac();
                CargarPresentacion_tras();
                ObtenerFactor();
                IdBodegaOrigen();
                IdBodegaDestino();
                CargarConceptosMovi();

                cbxtipoMovimiento.SelectedIndex = 1;
                cbxtipoMovimiento_TextChanged(null, null);

                speCantidad.Value = string.Empty;
                ObtenerExistencia();
            }
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

        }
        protected void cbxZafraProd_TextChanged(object sender, EventArgs e)
        {
            IdBodegaOrigen();
            ObtenerExistencia();
        }
        public void dtCliente()
        {
            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._SEL_CLIENTE_INGENIOS(cb_cliente.Value);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtNit.Text = Convert.ToString(row["NIT"].ToString());
                    txtNrc.Text = Convert.ToString(row["NRC"].ToString());
                    txtDepartamento.Text = Convert.ToString(row["NOMDEPARTAMENT"].ToString());
                    txtMunicipio.Text = Convert.ToString(row["NOMMUNICIPIO"].ToString());
                    txtGiro.Text = Convert.ToString(row["GIRO"].ToString());
                    txtDireccion.Text = Convert.ToString(row["DIRECCION"].ToString());
                }
                else
                {
                    txtNit.Text = "";
                    txtNrc.Text = "";
                    txtDepartamento.Text = "";
                    txtMunicipio.Text = "";
                    txtGiro.Text = "";
                    txtDireccion.Text = "";
                }

                Conn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)

            {

            }

            catch (Exception ex)

            {

            }
            finally
            {
                Conn.cn.Close();

            }
        }
        protected void cb_cliente_TextChanged(object sender, EventArgs e)
        {
            if (this.cb_cliente.SelectedItem == null || this.cb_cliente.SelectedIndex == -1)
            {
                txtNit.Text = "";
                txtDireccion.Text = "";
            }
            else
            {
                dtCliente();
            }
        }

        private void InsEnc()
        {
            string Mensaje = "";
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_VT_ALMAPAC_ING", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@COD_CAPTURA", 0);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_fecha.Value));
                guardar.Parameters.AddWithValue("@ES_PROPIO", Convert.ToBoolean(rb_propio.Value));
                guardar.Parameters.AddWithValue("@ES_AJENO", Convert.ToBoolean(rb_Ajeno.Value));
                guardar.Parameters.AddWithValue("@ID_ZAFRA_PROD", Convert.ToInt32(cbxZafraProd.Value));
                guardar.Parameters.AddWithValue("@ID_ZAFRA_ACTUAL", Convert.ToInt32(cbxZafraActual.Value));
                guardar.Parameters.AddWithValue("@ID_TIPO_MOV", Convert.ToInt32(cbxtipoMovimiento.Value));
                guardar.Parameters.AddWithValue("@ID_CONCE", Convert.ToInt32(cbxConceptoTM.Value));
                guardar.Parameters.AddWithValue("@ID_ESPECI", Convert.ToInt32(cbxEspecifico.Value));
                guardar.Parameters.AddWithValue("@ID_BODEGAO", Convert.ToInt32(cbxBodegaOrigen.Value));
                guardar.Parameters.AddWithValue("@ID_BODEGAD", 0);
                guardar.Parameters.AddWithValue("@USUARIO_CREA", Convert.ToString(Session["USUARIO"]));
                guardar.Parameters.AddWithValue("@FECHA_CREA", DateTime.Now);
                guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToString(txt_ndocument.Text));
                guardar.Parameters.AddWithValue("@ID_ESTADO", Convert.ToInt32(cbxestado.Value));
                guardar.Parameters.AddWithValue("@ID_ORDEN_TRAS", Convert.ToInt32(cbxORDEN_GLOBAL_TRAS.Value));
                guardar.Parameters.AddWithValue("@ID_PROV_TRAS", Convert.ToInt32(0));
                guardar.Parameters.AddWithValue("@ID_TRANSPORTE", Convert.ToInt32(0));
                guardar.Parameters.AddWithValue("@MOTORISTA", DBNull.Value);
                guardar.Parameters.AddWithValue("@NIT", DBNull.Value);
                guardar.Parameters.AddWithValue("@PLACA_CABEZAL", DBNull.Value);
                guardar.Parameters.AddWithValue("@PLACA_REMOLQUE", DBNull.Value);
                guardar.Parameters.AddWithValue("@CONTENEDOR", DBNull.Value);
                guardar.Parameters.AddWithValue("@MARCHAMOS", DBNull.Value);
                guardar.Parameters.AddWithValue("@OBSERVACION", Convert.ToString(txtObservacion.Text));
                guardar.Parameters.AddWithValue("@NFORMULARIO", DBNull.Value);
                guardar.Parameters.AddWithValue("@ENCCLIENTE", Convert.ToString(cb_cliente.Text));
                guardar.Parameters.AddWithValue("@ENCNIT", Convert.ToString(txtNit.Text));
                guardar.Parameters.AddWithValue("@ENCNRC", txtNrc.Text);
                guardar.Parameters.AddWithValue("@ENCDEPARTAMENTO", txtDepartamento.Text);
                guardar.Parameters.AddWithValue("@ENCMUNICIPIO", txtMunicipio.Text);
                guardar.Parameters.AddWithValue("@ENCGIRO", txtGiro.Text);
                guardar.Parameters.AddWithValue("@ENCDIRECCION", Convert.ToString(txtDireccion.Text));
                guardar.Parameters.AddWithValue("@ID_TIPO", Convert.ToInt32(cbxTipoDocument.Value));
                guardar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(Session["ID_BODEP"]));
                guardar.Parameters.AddWithValue("@ID_FMPAGO", Convert.ToInt32(0));
                guardar.Parameters.AddWithValue("@EFECTIVO", Convert.ToDecimal(0));
                guardar.Parameters.AddWithValue("@CHEQUE", Convert.ToDecimal(0));
                guardar.Parameters.AddWithValue("@NOTAABONO", Convert.ToDecimal(0));
                guardar.Parameters.AddWithValue("@TOTAL", Convert.ToDecimal(0));
                guardar.Parameters.AddWithValue("@NCUENTA", DBNull.Value);
                guardar.Parameters.AddWithValue("@NCHEQUE", DBNull.Value);
                guardar.Parameters.AddWithValue("@BANCO", DBNull.Value);
                guardar.Parameters.AddWithValue("@ID_CLIENTEING", Convert.ToInt32(cb_cliente.Value));
                SqlParameter msgparam = new SqlParameter("@ID", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@ID"].Value);
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@ID"].Value);

                }
                Conn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cn.Close();
                if (Convert.ToString(Mensaje) != "0")
                {
                    txtIdentificador.Text = Convert.ToString(Mensaje);
                    InsEncDet(Convert.ToInt32(Mensaje));
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! EL N° DE DOCUMENTO YA FUE REGISTRADOR !','error') </script>");
                }
            }

        }
        private void InsEncDet(int Id)
        {
            //int fordt = 0;
            //DataSet DS_DTInt = (DataSet)Session["DS_DT"];

            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_DETA_VT_ALMAPAC_EXP", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", Id);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dt_fecha.Value));
                guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToString(txt_ndocument.Text));
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", Convert.ToInt32(cbxProducto.Value));
                guardar.Parameters.AddWithValue("@ID_PRESEN_TRAS", Convert.ToInt32(cbxPrestanciontras.Value));
                guardar.Parameters.AddWithValue("@ID_UNIDAD_FAC", Convert.ToInt32(cbxUnidad.Value));
                guardar.Parameters.AddWithValue("@CANTIDAD", Convert.ToDouble(speCantidad.Text));
                guardar.Parameters.AddWithValue("@FACTOR", Convert.ToDouble(speFactor.Value));
                guardar.Parameters.AddWithValue("@REFERENCIA_DETA", Guid.NewGuid());
                guardar.Parameters.AddWithValue("@USUARIO_CREA", Convert.ToString(Session["USUARIO"]));
                guardar.Parameters.AddWithValue("@FECHA_CREA", DateTime.Now);
                guardar.Parameters.AddWithValue("@USUARIO_ACT", Convert.ToString(Session["USUARIO"]));
                guardar.Parameters.AddWithValue("@FECHA_ACT", DateTime.Now);
                guardar.Parameters.AddWithValue("@FACTORKG", speFactorKg.Value);
                guardar.Parameters.AddWithValue("@QUINTALES", 0);
                guardar.Parameters.AddWithValue("@KILOGRAMOS", 0);
                guardar.Parameters.AddWithValue("@GALONES", 0);
                guardar.Parameters.AddWithValue("@TM", Convert.ToDouble(speCantidad.Text));
                guardar.Parameters.AddWithValue("@TM_JIBOA", 0);
                guardar.Parameters.AddWithValue("@TM_ALMAPAC", 0);
                guardar.Parameters.AddWithValue("@TM_DIF_ALMAPAC", 0);
                guardar.Parameters.AddWithValue("@TM_DIF_JIBOA", 0);
                guardar.Parameters.AddWithValue("@FACTORTM", 0);
                guardar.Parameters.AddWithValue("@PESOKG", 0);
                guardar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(Session["ID_BODEP"]));
                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                string Mensaje;
                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    Nuevo();
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','error') </script>");

                }
                Conn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cn.Close();

            }

        }

        protected void speCantidadMt_NumberChanged(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(speCantidadMt.Text))
            //{
            //    switch (Convert.ToInt32(cbxProducto.Value))
            //    {
            //        case 1:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value)) / Convert.ToDouble(speFactor.Value)), 0);
            //            break;
            //        case 2:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value))), 2);
            //            break;
            //        case 3:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value)) / Convert.ToDouble(speFactor.Value)), 0);
            //            break;
            //        case 5:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value))), 2);
            //            break;
            //        case 7:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value)) / Convert.ToDouble(speFactor.Value)), 0);
            //            break;
            //        case 15:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value)) / Convert.ToDouble(speFactor.Value)), 0);
            //            break;
            //        case 16:
            //            speCantidad.Value = Math.Round(((Convert.ToDouble(speCantidadMt.Value) * Convert.ToDouble(speFactorTm.Value)) / Convert.ToDouble(speFactor.Value)), 0);
            //            break;
            //        default:
            //            speCantidad.Value = String.Empty;
            //            break;
            //    }

            //}
            //else { speCantidad.Text = string.Empty; }

        }
    }
}