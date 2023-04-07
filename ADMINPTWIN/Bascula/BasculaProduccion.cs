using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace ADMINPTWIN.Bascula
{
    public partial class BasculaProduccion : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private delegate void DelegadoAcceso(string accion);

        public BasculaProduccion()
        {
            InitializeComponent();
        }
        #region CBDT 
        public void Horatio()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cb_Horario.DataSource = CDatos._SEL_TURNO(Convert.ToInt32(-1));
                cb_Horario.DisplayMember = "HORARIO";
                cb_Horario.ValueMember = "HORARIO";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cb_Horario.Refresh();
                cb_Horario.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();

            }
        }
        public void Motorista()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cb_motorista.DataSource = CDatos._SEL_MOTORISTA_CAMION();
                cb_motorista.DisplayMember = "NOMBRE";
                cb_motorista.ValueMember = "ID_MTPROD";   
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                cb_motorista.SelectedIndex = -1;

            }
        }
        public void PlacaMotorista()
        {
            try
            {
                if (Convert.ToString(cb_motorista.Text) == string.Empty) { }
                else { 
                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_MOTORISTA_CAMION_PLACA(Convert.ToInt32(cb_motorista.SelectedValue)); 
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtPlaca.Text = Convert.ToString(row["PLACA"].ToString());

                }
                else
                {
                    txtPlaca.Text = string.Empty;
                }

                Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                //MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                //MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                Cnn.cn.Close();
               
            }
        }
        #endregion
        #region VIEW
        private void ConfCaptura()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_EQUIPO_MEDICION(Convert.ToInt32(1));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    //txtCantida.Text = Convert.ToString(row["CANTIDAD"].ToString());

                    {
                        var withBlock = serialPort1;
                        if (withBlock.IsOpen)
                        {
                            withBlock.Close();
                        }

                        withBlock.PortName = Convert.ToString(row["PUERTO"].ToString());
                        withBlock.BaudRate = Convert.ToInt32(row["BITS_POR_SEGUNDO"].ToString());
                        withBlock.DataBits = Convert.ToInt32(row["BITS_DATOS"].ToString());
                        withBlock.StopBits = System.IO.Ports.StopBits.One;
                        withBlock.Parity = System.IO.Ports.Parity.None;
                        withBlock.DtrEnable = false;
                        withBlock.Handshake = System.IO.Ports.Handshake.None;
                        withBlock.ReadBufferSize = 2048;
                        withBlock.WriteBufferSize = 1024;
                        withBlock.WriteTimeout = 500;
                        withBlock.Encoding = Encoding.Default;
                        withBlock.Open();
                    }

                }
                else
                {

                }

                Cnn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void OrdenT()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbOrdenT.DataSource = CDatos._SEL_ORDEN_GLOBAL_TRAS(Convert.ToInt32(-1), Convert.ToInt32(29));
                cbOrdenT.DisplayMember = "NOMBREDT";
                cbOrdenT.ValueMember = "ID_ORDEN_TRAS";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbOrdenT.Refresh();
                cbOrdenT.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void OrdenTDt(int id)
        {
            try
            {
                if (Convert.ToString(cbOrdenT.Text) == "")
                {
                    txtInicial.Text = "0";
                    txtDespacho.Text = "0";
                    txtSaldo.Text = "0";
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_ORDEN_GLOBAL_TRAS(Convert.ToInt32(id), Convert.ToInt32(29));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];

                        txtInicial.Text = Convert.ToString(row["ASIGNACIONT"].ToString());
                        txtDespacho.Text = Convert.ToString(row["EJECUTADO"].ToString());
                        txtSaldo.Text = Convert.ToString(row["SALDO"].ToString());
                    }
                    else
                    {
                        txtInicial.Text = "0";
                        txtDespacho.Text = "0";
                        txtSaldo.Text = "0";
                    }

                    Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                BascDDt();
            }
        }
        public void Estado()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbEstado.DataSource = CDatos._SEL_ESTADO_MOVIMIENTOS(Convert.ToInt32(-1));
                cbEstado.DisplayMember = "NOMBRE_ESTADO";
                cbEstado.ValueMember = "ID_ESTADO";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbEstado.Refresh();
                cbEstado.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void Producto()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbProducto.DataSource = CDatos._SEL_PRODUCTO(Convert.ToInt32(-1));
                cbProducto.DisplayMember = "NOMBRE_PRODUCTO";
                cbProducto.ValueMember = "ID_PRODUCTO";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbProducto.Refresh();
                cbProducto.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void ZafraProducto()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbZafraProducto.DataSource = CDatos._SEL_ZAFRA(Convert.ToInt32(-1));
                cbZafraProducto.DisplayMember = "NOMBRE_ZAFRA";
                cbZafraProducto.ValueMember = "ID_ZAFRA";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbZafraProducto.Refresh();
                cbZafraProducto.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void ZafraActual()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbZafraActual.DataSource = CDatos._SEL_ZAFRA_ACTUAL();
                cbZafraActual.DisplayMember = "NOMBRE_ZAFRA";
                cbZafraActual.ValueMember = "ID_ZAFRA";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbZafraActual.Refresh();
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void TipoMovimiento()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbTipoMovimiento.DataSource = CDatos._SEL_TIPO_MOVIMIENTO(Convert.ToInt32(-1));
                cbTipoMovimiento.DisplayMember = "NOMBRE_MOV";
                cbTipoMovimiento.ValueMember = "ID_TIPO_MOV";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbTipoMovimiento.Refresh();
                cbTipoMovimiento.SelectedIndex = -1;
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void Concepto()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbConcepto.DataSource = CDatos._SEL_CONCEPTO_MOVI(Convert.ToInt32(cbProducto.SelectedValue), Convert.ToInt32(cbTipoMovimiento.SelectedValue));
                cbConcepto.DisplayMember = "NOMBRE_CONCE";
                cbConcepto.ValueMember = "ID_CONCE";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbConcepto.Refresh();
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void Especifico()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbEspecifico.DataSource = CDatos._SEL_ESPECI_MOV(Convert.ToInt32(cbConcepto.SelectedValue));
                cbEspecifico.DisplayMember = "NOMBRE_ESPECI";
                cbEspecifico.ValueMember = "ID_ESPECI";
                //cbx_proveedor.Items.Add(0, "--Seleccionar--");
                cbEspecifico.Refresh();
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        private void IdBodegaOrigen()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbBodegaOrigen.DataSource = CDatos._SEL_BODEGAO(Convert.ToInt32(cbProducto.SelectedValue));
                cbBodegaOrigen.DisplayMember = "NOMBRE";
                cbBodegaOrigen.ValueMember = "ID_BODEGA";
                cbBodegaOrigen.Refresh();
                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        public void BascEncDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEnc.Text) == "")
                {
                    txtIdentificador.Text = "0";
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_BASCULA_ENCA_ES_PRODUCCION(Convert.ToInt32(lbIdentificadorEnc.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        txtIdentificador.Text = Convert.ToString(row["ID_BASCULAENCA"].ToString());
                        txtFecha.DateTime = Convert.ToDateTime(row["FECHA"].ToString());
                        ck_impt.Checked =Convert.ToBoolean(row["IMPT"]);
                        ck_impb.Checked = Convert.ToBoolean(row["IMPB"]);
                        ck_imptd.Checked = Convert.ToBoolean(row["IMPTD"]);
                    }
                    else
                    {
                        txtIdentificador.Text = "0";
                        ck_impt.Checked = false;
                        ck_impb.Checked = false;
                        ck_imptd.Checked = false;
                    }

                    Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                BascDDt();
            }
        }
        public void BascDDt()
        {
            try
            {
                if (Convert.ToString(txtIdentificador.Text) == "")
                {
                    lbIdentificadorDT.Text = "0";
                    txtLectura.Text = "0";
                    txtTara.Text = "0";
                    txtBruto.Text = "0";
                    txtNeto.Text = "0";
                    txtKilogramos.Text = "0";
                    txtQuintales.Text = "0";
                    txtGalones.Text = "0";
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_BASCULA_DETA_ES_PRODUCCION(Convert.ToInt32(txtIdentificador.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        lbIdentificadorDT.Text= Convert.ToString(row["ID_BASCULADETA"].ToString());
                        if (Convert.ToString(row["TARA"].ToString()) != "0.00" && Convert.ToString(row["BRUTO"].ToString()) == "0.00")
                        { cbTipoCaptura.SelectedItem = "Bruto"; }
                        
                        else if (Convert.ToString(row["TARA"].ToString()) == "0.00" && Convert.ToString(row["BRUTO"].ToString()) != "0.00")
                        { cbTipoCaptura.SelectedItem = "Tara"; }
                       
                        txtTara.Text = Convert.ToString(row["TARA"].ToString());
                        txtBruto.Text = Convert.ToString(row["BRUTO"].ToString());
                        txtNeto.Text = Convert.ToString(row["NETO"].ToString());
                        txtKilogramos.Text = Convert.ToString(row["KILOGRAMOS"].ToString());
                        txtQuintales.Text = Convert.ToString(row["QUINTALES"].ToString());
                        txtGalones.Text = Convert.ToString(row["GALONES"].ToString());
                        txtPlaca.Text = Convert.ToString(row["PLACA"].ToString());
                        txtMarchamos.Text = Convert.ToString(row["MARCHAMOS"].ToString());
                        txtContenedor.Text = Convert.ToString(row["CONTENEDOR"].ToString());
                       if(Convert.ToString(row["MOTORISTA"].ToString())==""){ }
                        else { cb_motorista.Text = Convert.ToString(row["MOTORISTA"].ToString());
                            cb_motorista_TextChanged(null, null);
                        }
                    }
                    else
                    {
                        lbIdentificadorDT.Text = "0";
                        txtLectura.Text = "0";
                        txtTara.Text = "0";
                        txtBruto.Text = "0";
                        txtNeto.Text = "0";
                        txtKilogramos.Text = "0";
                        txtQuintales.Text = "0";
                        txtGalones.Text = "0";
                        cbTipoCaptura.SelectedItem = "Bruto";
                    }

                    Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                if (Convert.ToString(txtNeto.Text) != "0.00")
                {
                    btLeerPuerto.Enabled = false;
                    btCaturaPeso.Enabled = false;
                    btGuardar.Enabled = false;
                }
                else
                {

                }

            }
        }
        public void EncDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEnc.Text) == "")
                {
                    cbEstado.SelectedIndex = -1;
                    txtNdocumento.Text = string.Empty;
                    cbProducto.SelectedIndex = -1;
                    cbZafraProducto.SelectedIndex = -1;
                    // cbZafraActual.SelectedIndex = -1;
                    cbTipoMovimiento.SelectedIndex = -1;
                    cbConcepto.SelectedIndex = -1;
                    cbEspecifico.SelectedIndex = -1;
                    cbBodegaOrigen.SelectedIndex = -1;
                    txtDestino.Text = string.Empty;
                    txtCantida.Text = string.Empty;
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_ENTRADA_SALIDA_ENCA_PRODUCCION(Convert.ToInt32(lbIdentificadorEnc.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        cbEstado.SelectedValue = Convert.ToInt32(row["ID_ESTADO"].ToString());
                        txtNdocumento.Text = Convert.ToString(row["NUM_DOC"].ToString());
                        cbProducto.SelectedValue = Convert.ToInt32(row["ID_PRODUCTO"].ToString());
                        cbZafraProducto.SelectedValue = Convert.ToInt32(row["ID_ZAFRA_PROD"].ToString());
                        cbZafraActual.SelectedValue = Convert.ToInt32(row["ID_ZAFRA_ACTUAL"].ToString());
                        cbTipoMovimiento.SelectedValue = Convert.ToInt32(row["ID_TIPO_MOV"].ToString());
                        Concepto();
                        cbConcepto.SelectedValue = Convert.ToInt32(row["ID_CONCE"].ToString());
                        Especifico();
                        cbEspecifico.SelectedValue = Convert.ToInt32(row["ID_ESPECI"].ToString());
                        IdBodegaOrigen();
                        cbBodegaOrigen.SelectedValue = Convert.ToInt32(row["ID_BODEGAO"].ToString());
                        txtDestino.Text = Convert.ToString(row["DESTINO"].ToString());
                        cbOrdenT.SelectedValue = Convert.ToInt32(row["ID_ORDEN_TRAS"].ToString());
                        if (Convert.ToString(row["ID_ORDEN_TRAS"].ToString()) != "0")
                        { OrdenTDt(Convert.ToInt32(row["ID_ORDEN_TRAS"].ToString())); }
                        else
                        {
                            cbOrdenT.SelectedIndex = -1;
                            txtInicial.Text = "0";
                            txtDespacho.Text = "0";
                            txtSaldo.Text = "0";
                        }



                    }
                    else
                    {
                        cbEstado.SelectedIndex = -1;
                        txtNdocumento.Text = string.Empty;
                        cbProducto.SelectedIndex = -1;
                        cbZafraProducto.SelectedIndex = -1;
                        //cbZafraActual.SelectedIndex = -1;
                        cbTipoMovimiento.SelectedIndex = -1;
                        cbConcepto.SelectedIndex = -1;
                        cbEspecifico.SelectedIndex = -1;
                        cbBodegaOrigen.SelectedIndex = -1;
                        txtDestino.Text = string.Empty;
                        cbOrdenT.SelectedIndex = -1;
                        txtInicial.Text = "0";
                        txtDespacho.Text = "0";
                        txtSaldo.Text = "0";
                    }

                    Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                if (Convert.ToInt32(cbEstado.SelectedValue) == 1 || Convert.ToInt32(cbEstado.SelectedValue) == 2 || Convert.ToInt32(cbEstado.SelectedValue) == 3 || Convert.ToInt32(cbEstado.SelectedValue) == 4)
                {                    
                    btLeerPuerto.Enabled = true;
                    btCaturaPeso.Enabled = true;
                    btGuardar.Enabled = true;
                }
                else
                {
                    btLeerPuerto.Enabled = false;
                    btCaturaPeso.Enabled = false;
                    btGuardar.Enabled = false;
                }
            }
        }
        public void DDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEnc.Text) == "")
                {
                    txtCantida.Text = string.Empty;
                    lbkg.Text = string.Empty;
                    lbqq.Text = string.Empty;
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_ENTRADA_SALIDA_DETA_PRODUCCION(Convert.ToInt32(lbIdentificadorEnc.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        txtCantida.Text = Convert.ToString(row["CANTIDAD"].ToString());
                        txtFactor.Text = Convert.ToString(row["FACTOR"].ToString());
                        txtFactork.Text = Convert.ToString(row["FACTORKG"].ToString());
                        lbkg.Text = Convert.ToString(row["KILOGRAMOS"].ToString());
                        lbqq.Text = Convert.ToString(row["QUINTALES"].ToString());
                    }
                    else
                    {
                        txtCantida.Text = string.Empty;
                        txtFactor.Text = string.Empty;
                        txtFactork.Text = string.Empty;
                        lbkg.Text = string.Empty;
                        lbqq.Text = string.Empty;
                    }

                    Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }
        }
        private void TpCaptura()
        {
            cbTipoCaptura.Items.Clear();
            cbTipoCaptura.Items.Add("Tara");
            cbTipoCaptura.Items.Add("Bruto");
            cbTipoCaptura.Text = "Bruto";
        }
        public void FechaDoc()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_FECHA_PRODUCCION();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtFecha.DateTime  = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    txtFecha.Text = string.Empty;
                }

                Cnn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                if(LoginInfo.ID_MENUPERFIL==1)
                { txtFecha.Enabled= true ; } else { txtFecha.Enabled = false; }
            }
        }
        public void DocActual()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_DOC_PRODUCCION_ACTUAL(Convert.ToDateTime(txtFecha.Text));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtCodbarra.Text = Convert.ToString(row["ID_ES_ENCA"].ToString());

                }
                else
                {
                    txtCodbarra.Text = string.Empty;
                }

                Cnn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                txtCodbarra_TextChanged(null, null);
            }
        }

        public void Dt()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._VIEW_MOVIMIENTOS_WINDOWS(Convert.ToInt32(6)); //PRODUCCION CRUDA
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    lb_produccion.Text = Convert.ToString(row["MOV"].ToString());

                }
                else
                {
                    lb_produccion.Text = "0";
                }

                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                
            }
        }
        public void ObtenerNDoc()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._VIEW_DOCUMENTO_NUMERACION(Convert.ToInt32(6), Convert.ToInt32(29)); //PRODUCCION CRUDA
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txt_recibonew.Text = Convert.ToString(row["ULT_NUM_ASIGNADO"].ToString());

                }
                else
                {
                    txt_recibonew.Text = "";
                }

                Cnn.cn.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();

            }
        }

        #endregion

        #region INST
        private void InsEnc()
        {
            
            try
            {

                if (Convert.ToString(lb_produccion.Text) == "0")
                {
                    MessageBox.Show("id Configuracion Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(txt_recibonew.Text) == "")
                {
                    MessageBox.Show("N° Recibo Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(cb_Horario.Text) == "")
                {
                    MessageBox.Show("Horario Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {

                Cnn.cn.Close();
                Cnn.cn.Open();
                //SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_EXPRESWIN", Conn.cn);
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_PRODUCCION_CAMION_win", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@lbIdentificadorEncT", lb_produccion.Text);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);
                guardar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(29));
                guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToString(txt_recibonew.Text));
                guardar.Parameters.AddWithValue("@HORARIO", cb_Horario.SelectedValue);               

                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                string MensajeDT = "";
                if (rowsAffected > 0)
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    lb_produccion.Text = "0";
                    txt_recibonew.Text = "";
                        gb_recibo.Visible = false;
                }
                else
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    //GUARDA
                    //RptPesos(Id);
                }
                Cnn.cn.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
{
    Cnn.cn.Close();
}

        }

        private void InsBascEnc()
        {
            string Mensaje = "0";
            try
            {
                if (Convert.ToString(cbTipoCaptura.Text) == "Bruto")
                { 

                    if (Convert.ToString(cb_Horario.Text) == "")
                {
                    MessageBox.Show("Horario Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(cb_motorista.Text) == "")
                {
                    MessageBox.Show("Motorista Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if (Convert.ToString(txtPlaca.Text) == "")
                {
                    MessageBox.Show("Placa Requeridad", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                } 
                else if (Convert.ToString(txtBruto.Text) == "0")
                {
                    MessageBox.Show("Tara no puede ser cero", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                else                 
                {
                  //  FechaDoc();
                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_BASCULA_ENCA_ES_PRODUCCION_CRUDA", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                //guardar.Parameters.AddWithValue("@NUMEMPR", this.ParentForm.Controls.Find("lb_empresa", true)[0].Text);
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", lbIdentificadorEnc.Text);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNdocumento.Text);
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);//this.ParentForm.Controls.Find("lb_usuario", true)[0].Text);
                SqlParameter msgparam = new SqlParameter("@id", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@id"].Value);
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@id"].Value);

                }
                Cnn.cn.Close();
                }
                }
                else {
                    MessageBox.Show("captura de peso bruto es primero", "Mensaje", MessageBoxButtons.OK,
   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
                if (Convert.ToString(Mensaje) != "0")
                { InsBascDet(Convert.ToInt32(Mensaje)); }
                else { }
            }

        }
        private void InsBascDet(int Id)
        {
            try
            {
                if (Convert.ToString(cbTipoCaptura.Text) == "Bruto")
                {
                    Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_BASCULA_DETA_ES_PRODUCCION_CRUDA", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@TPCAP", Convert.ToString(cbTipoCaptura.Text));
                guardar.Parameters.AddWithValue("@ID_BASCULAENCA", Id);
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", lbIdentificadorEnc.Text);
                guardar.Parameters.AddWithValue("@ID_TARIMA", DBNull.Value);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNdocumento.Text);
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", cbProducto.SelectedValue);
                guardar.Parameters.AddWithValue("@CANTIDAD", txtCantida.Text);
                guardar.Parameters.AddWithValue("@PESOTARIMA", Convert.ToDecimal(txtPesotarima.Text));
                guardar.Parameters.AddWithValue("@PESOSACO", Convert.ToDecimal(0));
                guardar.Parameters.AddWithValue("@TARA", Convert.ToDecimal(txtTara.Text));
                guardar.Parameters.AddWithValue("@BRUTO", Convert.ToDecimal(txtBruto.Text));
                guardar.Parameters.AddWithValue("@NETO", Convert.ToDecimal(txtNeto.Text));
                guardar.Parameters.AddWithValue("@KILOGRAMOS", Convert.ToDecimal(txtKilogramos.Text));
                guardar.Parameters.AddWithValue("@QUINTALES", Convert.ToDecimal(txtQuintales.Text));
                guardar.Parameters.AddWithValue("@KILOGRAMOSP", Convert.ToDecimal(lbkg.Text));
                guardar.Parameters.AddWithValue("@QUINTALESP", Convert.ToDecimal(lbqq.Text));
                guardar.Parameters.AddWithValue("@GALONES", Convert.ToDecimal(txtGalones.Text));
                guardar.Parameters.AddWithValue("@PLACA", txtPlaca.Text);
                guardar.Parameters.AddWithValue("@MARCHAMOS", txtMarchamos.Text);
                guardar.Parameters.AddWithValue("@CONTENEDOR", txtContenedor.Text);
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);//this.ParentForm.Controls.Find("lb_usuario", true)[0].Text);
                guardar.Parameters.AddWithValue("@HORARIO", cb_Horario.SelectedValue);
                guardar.Parameters.AddWithValue("@ZAFRA", cbZafraProducto.Text);
                guardar.Parameters.AddWithValue("@MOTORISTA", cb_motorista.Text);
                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                string MensajeDT = "";
                if (rowsAffected > 0)
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        btNuevo_Click(null, null);
                    }
                else
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    //GUARDA
                    //RptPesos(Id);
                }
                Cnn.cn.Close();
            }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }

        }
        #endregion
        private void UpdBascDet(int Id, int IdENC)
        {
            try

            {
                if (Convert.ToString(cbTipoCaptura.Text) == "Tara")
                {
                    if (Convert.ToString(cb_Horario.Text) == "")
                {
                    MessageBox.Show("Horario Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToString(txtNeto.Text) == "0.00") || (Convert.ToString(txtNeto.Text) == "0"))
                {
                    MessageBox.Show("Neto Requerido", "Mensaje", MessageBoxButtons.OK,
MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                  //  FechaDoc();
                    Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("UPD_BASCULA_DETA_ES_PRODUCCION_CRUDA", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@TPCAP", Convert.ToString(cbTipoCaptura.Text));
                guardar.Parameters.AddWithValue("@ID_BASCULADETA", Id);
                guardar.Parameters.AddWithValue("@ID_BASCULAENCA", IdENC);
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", lbIdentificadorEnc.Text);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNdocumento.Text);
                guardar.Parameters.AddWithValue("@PESOTARIMA", Convert.ToDecimal(txtPesotarima.Text));
                guardar.Parameters.AddWithValue("@TARA", Convert.ToDecimal(txtTara.Text));
                guardar.Parameters.AddWithValue("@BRUTO", Convert.ToDecimal(txtBruto.Text));
                guardar.Parameters.AddWithValue("@NETO", Convert.ToDecimal(txtNeto.Text));
                guardar.Parameters.AddWithValue("@KILOGRAMOS", Convert.ToDecimal(txtKilogramos.Text));
                guardar.Parameters.AddWithValue("@QUINTALES", Convert.ToDecimal(txtQuintales.Text));
                guardar.Parameters.AddWithValue("@GALONES", Convert.ToDecimal(txtGalones.Text));
                guardar.Parameters.AddWithValue("@PLACA", txtPlaca.Text);
                guardar.Parameters.AddWithValue("@MARCHAMOS", txtMarchamos.Text);
                guardar.Parameters.AddWithValue("@CONTENEDOR", txtContenedor.Text);
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);//this.ParentForm.Controls.Find("lb_usuario", true)[0].Text);
                    guardar.Parameters.AddWithValue("@HORARIO", cb_Horario.SelectedValue);
                    guardar.Parameters.AddWithValue("@ZAFRA", cbZafraProducto.Text);
                    guardar.Parameters.AddWithValue("@MOTORISTA", cb_motorista.Text);
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                string MensajeDT = "";
                if (rowsAffected > 0)
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            btImprimirPesos_Click(null,null);
                        }
                else
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    //GUARDA
                   // RptPesos( Convert.ToInt32 (txtIdentificador.Text));

                }
                Cnn.cn.Close();
            }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();
            }

        }
        private void Bascula_Load(object sender, EventArgs e)
        {
            btCerrarpuerto_Click(null, null);
            // TODO: esta línea de código carga datos en la tabla 'dsReportes.SEL_PROCESO_CARGA' Puede moverla o quitarla según sea necesario.
            this.sEL_PROCESO_CARGATableAdapter.Fill(this.dsReportes.SEL_PROCESO_CARGA);
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
           //txtFecha.DateTime = DateTime.Now;
            Producto();
            Estado();
            ZafraProducto();
            ZafraActual();
            TipoMovimiento();
            TpCaptura();
            OrdenT();
            FechaDoc();
            Horatio();
            Motorista();
        }
        private void limp()
        {
            txtIdentificador.Text = "0";
            Estado();
           //txtFecha.DateTime = DateTime.Now;
            txtNdocumento.Text = string.Empty;
            lbIdentificadorEnc.Text = "0";
            lbIdentificadorDT.Text = "0";
            Producto();
            txtFactor.Text = string.Empty;
            txtFactork.Text = string.Empty;
            ZafraProducto();
            ZafraActual();
            TipoMovimiento();
            cbConcepto.SelectedIndex = -1;
            cbEspecifico.SelectedIndex = -1;
            cbBodegaOrigen.SelectedIndex = -1;
            txtCantida.Text = string.Empty;
            txtDestino.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            txtMarchamos.Text = string.Empty;
            txtPesotarima.Text = "0";
            txtContenedor.Text = string.Empty;
            txtLectura.Text = "0";
            txtPeso.Text = "0";
            txtTara.Text = "0";
            txtBruto.Text = "0";
            txtNeto.Text = "0";
            txtKilogramos.Text = "0";
            txtQuintales.Text = "0";
            txtGalones.Text = "0";
            lbkg.Text = "0";
            lbqq.Text = "0";
            txtCodbarra.Focus();
            cbOrdenT.SelectedIndex = -1;
            txtInicial.Text = "0";
            txtDespacho.Text = "0";
            txtSaldo.Text = "0";
            btLeerPuerto.Enabled = true;
            btCaturaPeso.Enabled = true;
            btGuardar.Enabled = true;
            Producto();
            Estado();
            ZafraProducto();
            ZafraActual();
            TipoMovimiento();
            TpCaptura();
            OrdenT();
            FechaDoc();
        }
        private void txtCodbarra_TextChanged(object sender, EventArgs e)
        {
            limp();
            lbIdentificadorEnc.Text = txtCodbarra.Text;
            BascEncDt();
            EncDt();
            DDt();
        }
        private void btLeerPuerto_Click(object sender, EventArgs e)
        {
            try
            {

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }


                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_EQUIPO_MEDICION(Convert.ToInt32(1));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    var withBlock = serialPort1;
                    withBlock.PortName = Convert.ToString(row["PUERTO"].ToString());
                    withBlock.BaudRate = Convert.ToInt32(row["BITS_POR_SEGUNDO"].ToString());
                    withBlock.DataBits = Convert.ToInt32(row["BITS_DATOS"].ToString());
                    withBlock.StopBits = System.IO.Ports.StopBits.One;
                    withBlock.Parity = System.IO.Ports.Parity.None;
                    withBlock.Handshake = System.IO.Ports.Handshake.None;
                    withBlock.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                    //withBlock.ReadTimeout = 500;
                    //withBlock.WriteTimeout = 500;
                    withBlock.Open();

                }
                else
                {
                    MessageBox.Show("Error COM", "Mensaje", MessageBoxButtons.OK,
              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    serialPort1.Close();
                }

                Cnn.cn.Close();

            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }
        }
        private void btCaturaPeso_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToString(cbTipoCaptura.Text) == "")
                {
                    MessageBox.Show("SELECIONAR TIPO CAPTURA", "Mensaje", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (Convert.ToString(cbTipoCaptura.Text) == "")
                        txtPeso.Text = "0";
                    else
                    {
                        if (Convert.ToInt32(LoginInfo.capm) == 0)
                        {
                            /// LECTURA COM
                            string[] lines = txtLectura.Lines;
                            if ((lines.Count() > 2))
                            {
                                txtPeso.Text = Regex.Replace(lines[2], "([^0-9.])", "");
                            }
                        }
                        else
                        {  ///MANUAL
                            
                            txtPeso.Text = txtLectura.Text;
                        }
                    }

                    if (Convert.ToString(cbTipoCaptura.Text) == "Tara")
                    {

                        if ((Convert.ToString(txtBruto.Text) == "0") || (Convert.ToString(txtBruto.Text) == "0.00"))
                        {
                            string dtpeso, peso, pesof, pesof2;
                            int pesolen, pesoflen;

                            dtpeso = txtPeso.Text.Trim();
                            peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                            pesolen = peso.Length;
                            pesof = peso.Substring(1, (pesolen - 1));
                            pesoflen = pesof.Length;
                            pesof2 = pesof.Substring(0, (pesoflen - 2));


                            txtTara.Text = Convert.ToString(Convert.ToDecimal(pesof2) + Convert.ToDecimal(txtPesotarima.Text));
                        }
                        else if ((Convert.ToString(txtBruto.Text) != "0") || (Convert.ToString(txtBruto.Text) != "0.00"))
                        {
                            string dtpeso, peso, pesof, pesof2;
                            int pesolen, pesoflen;

                            dtpeso = txtPeso.Text.Trim();
                            peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                            pesolen = peso.Length;
                            pesof = peso.Substring(1, (pesolen - 1));
                            pesoflen = pesof.Length;
                            pesof2 = pesof.Substring(0, (pesoflen - 2));
                            txtTara.Text = Convert.ToString(Convert.ToDecimal(pesof2) + Convert.ToDecimal(txtPesotarima.Text));
                            txtNeto.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtBruto.Text) - Convert.ToDecimal(txtTara.Text), 2));
                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtKilogramos.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(2.174), 2)); }
                            else
                            { txtKilogramos.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(2.174), 2));
                                //txtKilogramos.Text = "0";
                            }

                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtQuintales.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(100), 2)); }
                            else
                            { txtQuintales.Text = "0"; }


                            
                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtGalones.Text = "0"; }
                            else
                            { txtGalones.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(txtFactor.Text), 0)); }
                        }


                    }
                    else if (Convert.ToString(cbTipoCaptura.Text) == "Bruto")
                    {
                        if ((Convert.ToString(txtTara.Text) == "0" ) || (Convert.ToString(txtTara.Text) == "0.00"))
                        {
                            string dtpeso, peso, pesof, pesof2;
                            int pesolen, pesoflen;

                            dtpeso = txtPeso.Text.Trim();
                            peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                            pesolen = peso.Length;
                            pesof = peso.Substring(1, (pesolen - 1));
                            pesoflen = pesof.Length;
                            pesof2 = pesof.Substring(0, (pesoflen - 2));

                            txtBruto.Text = Convert.ToString(Convert.ToDecimal(pesof2));
                        }
                        else if ((Convert.ToString(txtTara.Text) != "0" ) || (Convert.ToString(txtTara.Text) != "0.00" ))
                        {
                            string dtpeso, peso, pesof, pesof2;
                            int pesolen, pesoflen;

                            dtpeso = txtPeso.Text.Trim();
                            peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                            pesolen = peso.Length;
                            pesof = peso.Substring(1, (pesolen - 1));
                            pesoflen = pesof.Length;
                            pesof2 = pesof.Substring(0, (pesoflen - 2));

                            txtBruto.Text = Convert.ToString(Convert.ToDecimal(pesof2));

                            txtNeto.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtBruto.Text) - Convert.ToDecimal(txtTara.Text), 2));

                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtKilogramos.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(2.174), 2)); }
                            else
                            {
                                txtKilogramos.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(2.174), 2));
                               //txtKilogramos.Text = "0"; 
                            }

                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtQuintales.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(100), 2)); }
                            else
                            { txtQuintales.Text = "0"; }

                           
                            if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                            { txtGalones.Text = "0"; }
                            else
                            { txtGalones.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(txtFactor.Text), 0)); }
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //btLeerPuerto.Enabled = false;
                //btCaturaPeso.Enabled = false;
            }
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToString(txtCodbarra.Text)=="")
                { MessageBox.Show("Codigo de Barra Resquerido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else { 
                if (Convert.ToString(txtIdentificador.Text) == "0")
                { InsBascEnc(); }
                else { UpdBascDet(Convert.ToInt32(lbIdentificadorDT.Text), Convert.ToInt32(txtIdentificador.Text)); }
            }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //btLeerPuerto.Enabled = false;
                //btCaturaPeso.Enabled = false;
                this.sEL_PROCESO_CARGATableAdapter.Fill(this.dsReportes.SEL_PROCESO_CARGA);
                dataGridView1.Refresh();
                FechaDoc();
            }
        }
        private void btNuevo_Click(object sender, EventArgs e)
        {

            txtCodbarra.Text = string.Empty;
            cbEstado.SelectedIndex = -1;
            txtIdentificador.Text = "0";
           //txtFecha.DateTime = DateTime.Now;
            txtNdocumento.Text = string.Empty;
            cbProducto.SelectedIndex = -1;
            txtFactor.Text = "0";
            txtFactork.Text = "0";
            cbZafraProducto.SelectedIndex = -1;
            cbZafraActual.SelectedIndex = -1;
            cbTipoMovimiento.SelectedIndex = -1;
            cbConcepto.SelectedIndex = -1;
            cbEspecifico.SelectedIndex = -1;
            cbBodegaOrigen.SelectedIndex = -1;
            cbOrdenT.SelectedIndex = -1;
           
            txtCantida.Text = "0";
            txtLectura.Text = "0";
            txtPeso.Text = "0";
            txtTara.Text = "0";
            txtBruto.Text = "0";
            txtNeto.Text = "0";
            txtKilogramos.Text = "0";
            txtQuintales.Text = "0";
            txtGalones.Text = "0";
            lbkg.Text = "0";
            lbqq.Text = "0";            
            lbIdentificadorEnc.Text = "0";
           

            btLeerPuerto.Enabled = true;
            btCaturaPeso.Enabled = true;
            btGuardar.Enabled = true;
            Producto();
            Estado();
            ZafraProducto();
            ZafraActual();
            TipoMovimiento();
            TpCaptura();
            OrdenT();
            FechaDoc();
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
        private void si_DataReceived(string accion)
        {
            try
            {
                txtLectura.Text = accion;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                //  MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }


        }
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.Enabled == true)
                {
                    Thread.Sleep(500);
                    string data = serialPort1.ReadExisting();
                    this.BeginInvoke(new DelegadoAcceso(si_DataReceived), new object[] { data });
                }
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                // MessageBox.Show(sqlEx.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }

        }
        public void RptPesos(int ID_BASCULAENCA)
        {
            try
            {
                if (Convert.ToString(cbTipoCaptura.Text) == "Tara")
                {
                    Reportes.Bascula.Rpt_PesosProdCruda ReportT = new Reportes.Bascula.Rpt_PesosProdCruda(ID_BASCULAENCA);
                    Reportes.Visor form = new Reportes.Visor();
                    form._view_documento.DocumentSource = ReportT;
                    form.Show();
                    btNuevo_Click(null, null);
                }
                else if (Convert.ToString(cbTipoCaptura.Text) == "Bruto")
                {
                    Reportes.Bascula.Rpt_PesosProdCruda ReportB = new Reportes.Bascula.Rpt_PesosProdCruda(ID_BASCULAENCA);
                    Reportes.Visor form = new Reportes.Visor();
                    form._view_documento.DocumentSource = ReportB;
                    form.Show();
                    btNuevo_Click(null, null);
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();

            }
        }
        public void RptPesosall(int ID_BASCULAENCA)
        {
            try
            {
                Reportes.Bascula.Rpt_PesosProdCruda Report = new Reportes.Bascula.Rpt_PesosProdCruda(ID_BASCULAENCA);
                Reportes.Visor form = new Reportes.Visor();
                form._view_documento.DocumentSource = Report;
                form.Show();
                btNuevo_Click(null, null);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cnn.cn.Close();

            }
        }
        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtIdentificador.Text) != "0" && ck_impb.Checked == false)
            { 
                //Reportes.Bascula.Rpt_PesosBruto ReportB = new Reportes.Bascula.Rpt_PesosBruto(Convert.ToInt32(txtIdentificador.Text));
                //Reportes.Visor form = new Reportes.Visor();
                //form._view_documento.DocumentSource = ReportB;
                //form.Show();
                btNuevo_Click(null, null);
            }
            else {
                MessageBox.Show("NO SE PUEDE REIMPRIMIR EL PESO BRUTO PARA ESTE DOCUMENTO "+ txtNdocumento.Text, "Mensaje", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
      
        private void btImprimirPesos_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtIdentificador.Text) != "0" )
            {

                Reportes.Visor childForm = new Reportes.Visor();

                if (ActivarForm(childForm) == true)
                {
                    childForm = null;
                    
                }
                else
                {
                    
                    Reportes.Bascula.Rpt_PesosProdCruda ReportT = new Reportes.Bascula.Rpt_PesosProdCruda(Convert.ToInt32(txtIdentificador.Text));
                    childForm._view_documento.DocumentSource = ReportT;
                  //  childForm.MdiParent = this;
                    childForm.WindowState = FormWindowState.Maximized;
                    childForm.Show();
                    btNuevo_Click(null, null);
                }
                   
              
            }
           
        }

        #region key
       
        private void cbProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbProducto_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbZafraProducto_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbZafraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbTipoMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbTipoMovimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbBodegaOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbBodegaOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbZafraActual_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbZafraActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbEspecifico_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void cbEspecifico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            return;
        }
        #endregion

        private void btCerrarpuerto_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

        }

        private void btcerrar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            this.Close();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btImprimirTara_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtIdentificador.Text) != "0" && ck_impt.Checked == false)
            {
                Reportes.Bascula.Rpt_PesosProdCruda Report = new Reportes.Bascula.Rpt_PesosProdCruda(Convert.ToInt32(txtIdentificador.Text));
                Reportes.Visor form = new Reportes.Visor();
                form._view_documento.DocumentSource = Report;
                form.Show();
                btNuevo_Click(null, null);
            }
            else
            {
                MessageBox.Show("NO SE PUEDE REIMPRIMIR EL PESO TARA PARA ESTE DOCUMENTO " + txtNdocumento.Text, "Mensaje", MessageBoxButtons.OK,
               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void cb_motorista_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
        }

        private void cb_motorista_TextChanged(object sender, EventArgs e)
        {        
           PlacaMotorista();
        }

        private void bt_actual_Click(object sender, EventArgs e)
        {
            DocActual();
           
        }

        private void bt_reporte_Click(object sender, EventArgs e)
        {
            string hr = "0";
            switch (cb_Horario.Text)
            {
                case "06:00 A.M. A 02:00 P.M.":
                    hr = "1";
                    break;
                case "02:00 P.M. A 10:00 P.M.":
                    hr = "2";
                    break;
                case "10:00 P.M. A 06:00 A.M.":
                    hr = "3";
                    break;
                default:
                    hr = "0";
                    break;
            }
            Reportes.Bascula.RptMovCrudaCamion Report = new Reportes.Bascula.RptMovCrudaCamion(Convert.ToInt32(29),Convert.ToDateTime(txtFecha.Text), hr);
            Reportes.Visor form = new Reportes.Visor();
            form._view_documento.DocumentSource = Report;
            form.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gb_recibo.Visible = true;
            Dt();
            ObtenerNDoc();
        }

        private void bt_guardarRecibo_Click(object sender, EventArgs e)
        {
            InsEnc();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            lb_produccion.Text = "0";
            txt_recibonew.Text = "";
            gb_recibo.Visible = false;
        }


        private Boolean ActivarForm(Form Formulario)
        {

            foreach (Control control in this.Controls)
            {
                if (control.HasChildren)//porque el mdi es un contenedor.
                {
                    foreach (Control controlChild in control.Controls)
                    {
                        if (controlChild.GetType() == Formulario.GetType())
                        {
                            if (((Form)controlChild).WindowState == FormWindowState.Minimized)
                            {
                                ((Form)controlChild).WindowState = FormWindowState.Normal;


                            }
                        ((Form)controlChild).BringToFront();
                            return true;

                        }
                    }
                }

            }
            return false;
        }

      

    }
}
