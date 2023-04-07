using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
using DevExpress.Web;

namespace ADMINPT.controles.movimiento_vtjiboaEmp
{
    public partial class UcVentaEmpacada : System.Web.UI.UserControl
    {
        private CENTRADA_SALIDA_ENCA Controlador = new CENTRADA_SALIDA_ENCA();
        private CENTRADA_SALIDA_DETA ControladorDt = new CENTRADA_SALIDA_DETA();
        char[] charsToTrim = { '*', ' ', '\'' };
        private void Inicializar()
        {
            UCEncabezado.Titulo = "VENTA DE AZUCAR JIBOA EMPACADA";
            UCBarraNavegacion.btn_reporte.Visible = true;
            CargarListas();
            _btn_nuevo_Click(null, null);

            //  Session["DT"] = DT;
        }
        protected void Page_Init(object sender, EventArgs e)
        { Inicializar(); }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Cancelar_Click += _btn_cancelar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporteDia_Click;

            if (!IsPostBack)
            {
                DataTable DT = (DataTable)Session["DT"];
                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = DT;
                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();

                if (Convert.ToInt32(Session["ID_ES_ENCA"]) != 0) { _btn_reporte_Click(null, null); }
            }
            else { if (Convert.ToInt32(Session["ID_ES_ENCA"]) != 0) { _btn_reporte_Click(null, null); } }

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



            //odsCLIENTE.DataBind();
            //cbxCliente.DataSourceID = "odsCLIENTE";
            //cbxCliente.DataBind();

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
            //if (Convert.ToString(cbxProducto.Text) == "")
            //{ }
            //else if (Convert.ToString(cbxProducto.Text) != "")
            //{
            //    odsBodegaDUser.DataBind();
            //    cbxBodegaDestino.DataSourceID = "odsBodegaDUser";
            //    odsBodegaDUser.SelectParameters["ID_PRODUCTO"].DefaultValue = cbxProducto.Value.ToString();
            //    cbxBodegaDestino.DataBind();
            //    cbxBodegaDestino.Value = 18;
            //    cbxBodegaDestino_TextChanged(null, null);
            //}
            //else { }
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
                // cbxConceptoTM.SelectedIndex = -1;
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
            //BODEGA lEntidad = new CBODEGA().ObtenerPorId(Convert.ToInt32(cbxBodegaDestino.Value));
            //if (lEntidad != null)
            //{
            //    txtNit.Text = lEntidad.NIT;
            //    txtNrc.Text = lEntidad.NRC;
            //    txtGiro.Text = lEntidad.GIRO;
            //    txtDireccion.Text = lEntidad.DIRECCION;
            //    txtDepartamento.Text = lEntidad.NOMDEPARTAMENTO;
            //    txtMunicipio.Text = lEntidad.NOMMUNICIPIO;
            //}
            //if (lEntidad == null)
            //{
            //    txtNit.Text = string.Empty;
            //    txtNrc.Text = string.Empty;
            //    txtGiro.Text = string.Empty;
            //    txtDireccion.Text = string.Empty;
            //    txtDepartamento.Text = string.Empty;
            //    txtMunicipio.Text = string.Empty;
            //}
        }

        protected void cbxProducto_TextChanged(object sender, EventArgs e)
        {
            ZafraProducto();
            //CargarPresentacion_tras();
            //ObtenerFactor();
            IdBodegaOrigen();
            //IdBodegaDestino();
            CargarConceptosMovi();
            cbxtipoMovimiento.SelectedIndex = 1;
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
            DT.Rows.Add(null, Convert.ToInt32(cbxProducto.Value), Convert.ToInt32(cbxPrestanciontras.Value), Convert.ToInt32(cbxUnidad.Value), Convert.ToInt32(speCantidad.Value), Convert.ToSingle(speFactor.Value), Convert.ToString(lbGuid.Text));
            //DT.Rows.Add(null,Convert.ToInt32(cbxProducto.Value));
            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = DT;
            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();
            // Actualizamos el DataTable en la variable de session
            Session["DT"] = DT;
            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();
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
                //ENCABEZADO
                //txt_ndocument.Text = Convert.ToString(lEntidad.NO_DOCTO);
                dteFecha.Value = lEntidad.FECHA;
                txtIdentificador.Text = "0";
                cbxBodegaOrigen.Value = lEntidad.ID_BODEGAO;
                // cbxBodegaDestino.Value = lEntidad.ID_BODEGAD;
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


        }
        protected void cbxBodegaDestino_TextChanged(object sender, EventArgs e)
        {
            //ObtenerdtBGDestino();
        }
        protected void cbxZafraProd_TextChanged(object sender, EventArgs e)
        {
            //IdBodegaOrigen();
            ObtenerExistencia();
        }

        private void EncaFact()
        {
            try
            {



                string SALF;
                SALF = Convert.ToString(dteFecha.Date.ToString("MM/dd/yyyy"));


                DataTable Dt = new DataTable();
                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select c.nombrecli,c.direcli,c.registro,c.nit, d.nom_deptog, mm.nombre as municipio, a.efectivo,a.cheques,a.tarjeta " +
                    " from facturas a, clientes c, deptog d, municipi mm " +
                    " where a.cliente=c.cliente and d.deptog=c.depto and mm.codmuni=c.codmuni and" +
                    " SUBS(a.tipofact,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fecha={" + SALF + "}", Conn.cnph);
                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtCliente.Text = Convert.ToString(row["nombrecli"].ToString().Trim(charsToTrim));
                    txtDireccion.Text = Convert.ToString(row["direcli"].ToString().Trim(charsToTrim));
                    txtNit.Text = Convert.ToString(row["nit"].ToString().Trim(charsToTrim));
                    txtNrc.Text = Convert.ToString(row["registro"].ToString().Trim(charsToTrim));
                    txtDepartamento.Text = Convert.ToString(row["nom_deptog"].ToString().Trim(charsToTrim));
                    txtMunicipio.Text = Convert.ToString(row["municipio"].ToString().Trim(charsToTrim));
                    txtEfectivo.Text = Convert.ToString(row["efectivo"].ToString());
                    txtCheque.Text = Convert.ToString(row["cheques"].ToString());
                    txtNotaAbono.Text = Convert.ToString(row["tarjeta"].ToString());
                    txtTotal.Text = Convert.ToString(Convert.ToDecimal(row["efectivo"]) + Convert.ToDecimal(row["cheques"]) + Convert.ToDecimal(row["tarjeta"]));
                    if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 1; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 2; }
                    else if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 3; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 4; }
                    else if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 5; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 6; }
                    txtmCheque.Text = "0";
                    txtmNotaAbono.Text = "0";
                }
                else
                {
                    lbl_mensaje.Text = "";
                    lbl_mensaje.Visible = false;
                }
                Conn.cnph.Close();
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
        private void EncaNCH()
        {
            try
            {

                string SALF;
                SALF = Convert.ToString(dteFecha.Date.ToString("MM/dd/yyyy"));


                DataTable Dt = new DataTable();
                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select rtrim(b.nombre) as banco, rtrim(a.cuentachk) as cuentachk, rtrim(a.numchk) as numchk, rtrim(a.nombrechk) as nombrechk" +
                    " from movchk a, bancos b " +
                    " where a.bancoc=b.banco and" +
                    " SUBS(a.tipodoc,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fechachk={" + SALF + "}", Conn.cnph);
                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtBanco.Text = Convert.ToString(row["banco"].ToString().Trim(charsToTrim));
                    txtNCuenta.Text = Convert.ToString(row["cuentachk"].ToString().Trim(charsToTrim));
                    txtNCheque.Text = Convert.ToString(row["numchk"].ToString().Trim(charsToTrim));
                    
                }
                else
                {
                    lbl_mensaje.Text = "";
                    lbl_mensaje.Visible = false;
                }
                Conn.cnph.Close();
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
        private void DetFact()
        {
            DataSet DS_DTG = new DataSet();
            DataSet DS_DT = new DataSet("DS_DT");
            DataTable DT = DS_DT.Tables.Add("DT");
            Session["DS_DT"] = null;
            try
            {



                string SALF;
                SALF = Convert.ToString(dteFecha.Date.ToString("MM/dd/yyyy"));



                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select  IIF(b.codigoart = '10001           ', '9               ', IIF(b.codigoart = '10002           ', '10              ',IIF(b.codigoart = '10003           ', '11              ',IIF(b.codigoart = '08001           ', '12              ',IIF(b.codigoart = '08002           ', '13              ',IIF(b.codigoart = '08003           ', '14              ', '0               '))))))  as codigoart, b.cantidad  from facturas a, detafac b " +
                     " where a.tipofact=b.tipofact and VAL(a.NUMERO)=VAL(b.NUMERO) and val(b.codigoart)<>9920 and ltrim(rtrim(b.codigoart))<>'/'  and" +
                    " SUBS(a.tipofact,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fecha={" + SALF + "}", Conn.cnph);

                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(DS_DTG);

                DT.Columns.Add(new System.Data.DataColumn("ID_ES_DETA", typeof(System.Int32)));
                DT.PrimaryKey = new DataColumn[1] { DT.Columns["ID_ES_DETA"] };
                DT.Columns["ID_ES_DETA"].AutoIncrement = true;
                DT.Columns.Add("ID_PRODUCTO", Type.GetType("System.Int32"));
                DT.Columns.Add("ID_PRESEN_TRAS", Type.GetType("System.Int32"));
                DT.Columns.Add("ID_UNIDAD_FAC", Type.GetType("System.Int32"));
                DT.Columns.Add("CANTIDAD", Type.GetType("System.Single"));
                DT.Columns.Add("FACTOR", Type.GetType("System.Single"));
                DT.Columns.Add("REFERENCIA_DETA", Type.GetType("System.String"));
                DT.Clear();
                speCantidad.Value = 0;
                if (DS_DTG.Tables.Count != 0)
                {

                    foreach (DataTable table in DS_DTG.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {

                            speCantidad.Value = Convert.ToInt32(speCantidad.Value) + Convert.ToInt32(dr["cantidad"]);


                            DT.Rows.Add(null, Convert.ToInt32(dr["codigoart"]), 2, 1, Convert.ToDouble(dr["cantidad"].ToString()), 1.087, Guid.NewGuid());

                            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = DS_DT;
                            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();
                        }
                    }
                }

                Conn.cnph.Close();
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
                Session["DS_DT"] = DS_DT;
            }
        }
        private void InsEnc()
        {
            string Mensaje = "";
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_VJIBOA_EMP", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@COD_CAPTURA", 0);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dteFecha.Value));
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
                guardar.Parameters.AddWithValue("@ID_PROV_TRAS", Convert.ToInt32(cbxProveedorTrans.Value));
                guardar.Parameters.AddWithValue("@ID_TRANSPORTE", Convert.ToInt32(cbxTransporte.Value));
                guardar.Parameters.AddWithValue("@MOTORISTA", Convert.ToString(txtMotoritsta.Text));
                guardar.Parameters.AddWithValue("@NIT", Convert.ToString(txtNitMotor.Text));
                guardar.Parameters.AddWithValue("@PLACA_CABEZAL", DBNull.Value);
                guardar.Parameters.AddWithValue("@PLACA_REMOLQUE", DBNull.Value);
                guardar.Parameters.AddWithValue("@CONTENEDOR", DBNull.Value);
                guardar.Parameters.AddWithValue("@MARCHAMOS", DBNull.Value);
                guardar.Parameters.AddWithValue("@OBSERVACION", Convert.ToString(txtObservacion.Text));
                guardar.Parameters.AddWithValue("@NFORMULARIO", DBNull.Value);
                guardar.Parameters.AddWithValue("@ENCCLIENTE", Convert.ToString(txtCliente.Text));
                guardar.Parameters.AddWithValue("@ENCNIT", Convert.ToString(txtNit.Text));
                guardar.Parameters.AddWithValue("@ENCNRC", Convert.ToString(txtNrc.Text));
                guardar.Parameters.AddWithValue("@ENCDEPARTAMENTO", Convert.ToString(txtDepartamento.Text));
                guardar.Parameters.AddWithValue("@ENCMUNICIPIO", Convert.ToString(txtMunicipio.Text));
                guardar.Parameters.AddWithValue("@ENCGIRO", Convert.ToString(txtGiro.Text));
                guardar.Parameters.AddWithValue("@ENCDIRECCION", Convert.ToString(txtDireccion.Text));
                if (Convert.ToString(cbxTipoDocument.Value) == "FA")
                { guardar.Parameters.AddWithValue("@ID_TIPO", Convert.ToInt32(2)); }
                else if (Convert.ToString(cbxTipoDocument.Value) == "CF") 
                { guardar.Parameters.AddWithValue("@ID_TIPO", Convert.ToInt32(3)); }
                guardar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(Session["ID_BODEP"]));
                guardar.Parameters.AddWithValue("@ID_FMPAGO", Convert.ToDecimal(cb_fmpago.Value));
                guardar.Parameters.AddWithValue("@EFECTIVO", Convert.ToDecimal(txtEfectivo.Text));
                guardar.Parameters.AddWithValue("@CHEQUE", Convert.ToDecimal(txtCheque.Text));
                guardar.Parameters.AddWithValue("@NOTAABONO", Convert.ToDecimal(txtNotaAbono.Text));
                guardar.Parameters.AddWithValue("@TOTAL", Convert.ToDecimal(txtTotal.Text));
                guardar.Parameters.AddWithValue("@NCUENTA", Convert.ToString(txtNCuenta.Text));
                guardar.Parameters.AddWithValue("@NCHEQUE", Convert.ToString(txtNCheque.Text));
                guardar.Parameters.AddWithValue("@BANCO", Convert.ToString(txtBanco.Text));
                guardar.Parameters.AddWithValue("@MCHEQUE", Convert.ToDecimal(txtmCheque.Text));
                guardar.Parameters.AddWithValue("@MNOTAABONO", Convert.ToDecimal(txtmNotaAbono.Text));
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
                else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! EL N° DE DOCUMENTO YA FUE REGISTRADOR !','error') </script>");
                }
            }

        }
        private void InsEncDet(int Id)
        {
            int fordt = 0;
            DataSet DS_DTInt = (DataSet)Session["DS_DT"];

            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_DETA_VJIBOA_EMP", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;

                if (DS_DTInt.Tables.Count != 0)
                {
                    foreach (DataTable table in DS_DTInt.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            fordt += 1;
                            guardar.Parameters.Clear();
                            guardar.Parameters.AddWithValue("@ID_ES_ENCA", Id);
                            guardar.Parameters.AddWithValue("@ID_PRODUCTO", Convert.ToInt32(dr["ID_PRODUCTO"]));
                            guardar.Parameters.AddWithValue("@ID_PRESEN_TRAS", Convert.ToInt32(dr["ID_PRESEN_TRAS"]));
                            guardar.Parameters.AddWithValue("@ID_UNIDAD_FAC", Convert.ToInt32(dr["ID_UNIDAD_FAC"]));
                            guardar.Parameters.AddWithValue("@CANTIDAD", Convert.ToSingle(dr["CANTIDAD"]));
                            guardar.Parameters.AddWithValue("@FACTOR", Convert.ToDouble(dr["FACTOR"]));
                            guardar.Parameters.AddWithValue("@REFERENCIA_DETA", Guid.NewGuid());
                            guardar.Parameters.AddWithValue("@USUARIO_CREA", Convert.ToString(Session["USUARIO"]));
                            guardar.Parameters.AddWithValue("@FECHA_CREA", DateTime.Now);
                            guardar.Parameters.AddWithValue("@FACTORKG", 50);
                            guardar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(Session["ID_BODEP"]));
                            guardar.ExecuteNonQuery();
                        }
                    }
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
                Conn.cn.Close();
                if (DS_DTInt.Tables[0].Rows.Count == fordt)
                {
                    // Response.Write("<script>alert('fin');</script>");
                    InsEncTraslado();
                    _btn_nuevo_Click(null, null);


                }
                else { }
            }

        }

        private void InsEncTraslado()
        {           
            try
            {
                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_TRASLADOCE5INJIBOA1", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;              
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(dteFecha.Value));              
                guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToString(txt_ndocument.Text));               
                guardar.ExecuteNonQuery();
               
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
            {         Conn.cn.Close();              
            }

        }

        protected void btImportar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_ndocument.Text) != string.Empty)
            {
                EncaFact();          
            EncaNCH();
             DetFact();

            cbxProducto.Value = 9;
            cbxProducto_TextChanged(null, null);
            System.Threading.Thread.Sleep(1500);
            }
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
            //cbxBodegaDestino.SelectedIndex = -1;
            txt_ndocument.Text = string.Empty;
            cbxestado.SelectedIndex = -1;
            cbxORDEN_GLOBAL_TRAS.SelectedIndex = -1;
            cbxProveedorTrans.SelectedIndex = -1;
            cbxTransporte.SelectedIndex = -1;
            txtMotoritsta.Text = string.Empty;
            txtNitMotor.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            //txtNFormulario.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtNit.Text = string.Empty;
            txtNrc.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtMunicipio.Text = string.Empty;
            txtGiro.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            cbxProducto.SelectedIndex = -1;
            cbxPrestanciontras.SelectedIndex = -1;
            cbxUnidad.SelectedIndex = -1;
            speCantidad.Value = string.Empty;
            speFactor.Value = 0;
            lbGuid.Text = Convert.ToString(Guid.NewGuid());
            speFactorKg.Value = 0;
            lblSaldo.Text = string.Empty;

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
            // cbxBodegaDestino.Enabled = true;
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
            cbxORDEN_GLOBAL_TRAS.Focus();
            cbxestado.SelectedIndex = -1;
            btnAgregarProductos.Enabled = true;
            btnAgregarProductos0.Enabled = true;
            cbxTipoDocument.Value = "CF";

            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = null;
            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();

            cb_fmpago.SelectedIndex = -1;
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtNotaAbono.Text = "0";
            txtmCheque.Text = "0";
            txtmNotaAbono.Text = "0";
            txtTotal.Text = "0";
            txtBanco.Text = "";
            txtNCheque.Text = "";
            txtNCuenta.Text = "";
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
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            InsEnc();

            //int fordt = 0;
            //DataSet DS_DTInt = (DataSet)Session["DS_DT"];
            //try
            //{
            //    if (DS_DTInt.Tables.Count != 0)
            //    {
            //        foreach (DataTable table in DS_DTInt.Tables)
            //        {
            //            foreach (DataRow dr in table.Rows)
            //            {
            //                fordt += 1;
            //               // Response.Write("<script>alert('Your text');</script>");
            //            }
            //        }
            //    }
            //    Conn.cn.Close();
            //}
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    lbl_mensaje.Text = ex.Message;
            //    lbl_mensaje.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    lbl_mensaje.Text = ex.Message;
            //    lbl_mensaje.Visible = true;
            //}
            //finally
            //{
            //    Conn.cn.Close();
            //    if (DS_DTInt.Tables[0].Rows.Count == fordt)
            //    {
            //       // Response.Write("<script>alert('fin');</script>");
            //        _btn_nuevo_Click(null, null);


            //    }
            //    else { }
            //}
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            _btn_nuevo_Click(null, null);
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();

            string mv = "1";
            string TipoRpt = "";

            TipoRpt = "5";
            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }

        protected void _btn_reporteDia_Click(object sender, EventArgs e)
        {
            FechaDoc();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();
            string mv = "2";
            string TipoRpt = "";

            TipoRpt = "12";
            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha.Text) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-2") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha.Text) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-2") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha.Text) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-2") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha.Text) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-2") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha.Text) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-2") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }
        protected void ObtenerNDoc()
        {
            if (Convert.ToString(cbxTipoDocument.SelectedItem.Value) == "FA")
            {
                ENTRADA_SALIDA_ENCA lEntidadd = new CENTRADA_SALIDA_ENCA().ObtenerNDoc(Convert.ToInt32(2), Convert.ToInt32(Session["ID_BODEP"]));
                if (lEntidadd != null)
                {

                    txt_ndocument.Text = lEntidadd.ULT_NUM_ASIGNADO;

                }
                if (lEntidadd == null)
                {
                    txt_ndocument.Text = string.Empty;
                }
            }
            else if (Convert.ToString(cbxTipoDocument.SelectedItem.Value) == "CF")
            {
                ENTRADA_SALIDA_ENCA lEntidadd = new CENTRADA_SALIDA_ENCA().ObtenerNDoc(Convert.ToInt32(3), Convert.ToInt32(Session["ID_BODEP"]));
                if (lEntidadd != null)
                {

                    txt_ndocument.Text = lEntidadd.ULT_NUM_ASIGNADO;

                }
                if (lEntidadd == null)
                {
                    txt_ndocument.Text = string.Empty;
                }
            }


        }
        protected void cbxTipoDocument_TextChanged(object sender, EventArgs e)
        {
            ObtenerNDoc();
        }
    }
    }