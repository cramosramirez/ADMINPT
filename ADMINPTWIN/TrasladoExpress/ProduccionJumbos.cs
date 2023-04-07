using DevExpress.Office.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMINPTWIN.TrasladoExpress
{
    public partial class ProduccionJumbos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private delegate void DelegadoAcceso(string accion);
        string cbTipoCaptura = "Bruto";
        public ProduccionJumbos()
        {
            InitializeComponent();
            
        }
       
        #region CbDT
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
        private void IdBodegaDestino()
        {
            try
            {
                Cnn.cn.Close();
                Cnn.cn.Open();
                cbBodegaDestino.DataSource = CDatos._SEL_BODEGAO(Convert.ToInt32(cbProducto.SelectedValue));
                cbBodegaDestino.DisplayMember = "NOMBRE";
                cbBodegaDestino.ValueMember = "ID_BODEGA";
                cbBodegaDestino.Refresh();
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

        #region ViewDt
        public void Dt()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._VIEW_MOVIMIENTOS_WINDOWS(Convert.ToInt32(2));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtCodbarra.Text = Convert.ToString(row["MOV"].ToString());

                }
                else
                {
                    txtCodbarra.Text = "0";
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
                if (Convert.ToString(txtCodbarra.Text) != "0")
                {
                    txtCodbarra_TextChanged(null, null);

                }
            }
        }
        public void BascEncDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEncT.Text) == "")
                {
                    txtIdentificador.Text = "0";
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_BASCULA_ENCA_ES(Convert.ToInt32(lbIdentificadorEncT.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        txtIdentificador.Text = Convert.ToString(row["ID_BASCULAENCA"].ToString());
                        txtFecha.DateTime = Convert.ToDateTime(row["FECHA"].ToString());
                    }
                    else
                    {
                        txtIdentificador.Text = "0";
                       //txtFecha.DateTime = DateTime.Now;
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
                    Dt = CDatos._SEL_BASCULA_DETA_ES(Convert.ToInt32(txtIdentificador.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        //if (Convert.ToString(row["TARA"].ToString()) != "0.00" && Convert.ToString(row["BRUTO"].ToString()) == "0.00")
                        //{ cbTipoCaptura.SelectedItem = "Bruto"; }
                        //else if (Convert.ToString(row["TARA"].ToString()) == "0.00" && Convert.ToString(row["BRUTO"].ToString()) != "0.00")
                        //{ cbTipoCaptura.SelectedItem = "Tara"; }
                        txtTara.Text = Convert.ToString(row["TARA"].ToString());
                        txtBruto.Text = Convert.ToString(row["BRUTO"].ToString());
                        txtNeto.Text = Convert.ToString(row["NETO"].ToString());
                        txtKilogramos.Text = Convert.ToString(row["KILOGRAMOS"].ToString());
                        txtQuintales.Text = Convert.ToString(row["QUINTALES"].ToString());
                        txtGalones.Text = Convert.ToString(row["GALONES"].ToString());

                        if (Convert.ToDecimal(row["NETO"].ToString()) != 0)
                        {
                            btLeerPuerto.Enabled = false;
                            btCaturaPeso.Enabled = false;
                            btGuardar.Enabled = false;
                        }
                        else
                        {
                            btLeerPuerto.Enabled = true;
                            btCaturaPeso.Enabled = true;
                            btGuardar.Enabled = true;
                        }
                    }
                    else
                    {
                        txtLectura.Text = "0";
                        txtTara.Text = "0";
                        txtBruto.Text = "0";
                        txtNeto.Text = "0";
                        txtKilogramos.Text = "0";
                        txtQuintales.Text = "0";
                        txtGalones.Text = "0";
                        //cbTipoCaptura.SelectedItem = "Tara";
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
        public void EncDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEncT.Text) == "")
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
                    cbBodegaDestino.SelectedIndex = -1;
                    txtCantida.Text = string.Empty;
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_ENTRADA_SALIDA_ENCA_TRASLADO_T(Convert.ToInt32(lbIdentificadorEncT.Text));
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
                        IdBodegaDestino();
                        cbBodegaDestino.SelectedValue = Convert.ToString(row["ID_BODEGAD"].ToString());
                        //cbOrdenT.SelectedValue = Convert.ToInt32(row["ID_ORDEN_TRAS"].ToString());
                        //if (Convert.ToString(row["ID_ORDEN_TRAS"].ToString()) != "0")
                        //{ OrdenTDt(Convert.ToInt32(row["ID_ORDEN_TRAS"].ToString())); }
                        //else
                        //{
                        //    cbOrdenT.SelectedIndex = -1;
                        //    txtInicial.Text = "0";
                        //    txtDespacho.Text = "0";
                        //    txtSaldo.Text = "0";
                        //}

                       //txtFecha.DateTime = DateTime.Now;

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
                        cbBodegaDestino.SelectedIndex = -1;
                        //cbOrdenT.SelectedIndex = -1;
                        //txtInicial.Text = "0";
                        //txtDespacho.Text = "0";
                        //txtSaldo.Text = "0";
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
        public void DDt()
        {
            try
            {
                if (Convert.ToString(lbIdentificadorEncT.Text) == "")
                {
                    txtCantida.Text = string.Empty;
                    lbkg.Text = string.Empty;
                    lbqq.Text = string.Empty;
                    txtFactorSaco.Text = string.Empty;
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_ENTRADA_SALIDA_DETA_ENCA_T(Convert.ToInt32(lbIdentificadorEncT.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        //txtCantida.Text = Convert.ToString(row["CANTIDAD"].ToString());
                        txtFactor.Text = Convert.ToString(row["FACTOR"].ToString());
                        txtFactork.Text = Convert.ToString(row["FACTORKG"].ToString());
                        lbkg.Text = Convert.ToString(row["KILOGRAMOS"].ToString());
                        lbqq.Text = Convert.ToString(row["QUINTALES"].ToString());
                        txtFactorSaco.Text = Convert.ToString(row["FSACO"].ToString());
                        lbPT.Text = Convert.ToString(row["ID_PRESEN_TRAS"].ToString());
                        lbUF.Text = Convert.ToString(row["ID_UNIDAD_FAC"].ToString());
                    }
                    else
                    {
                        txtCantida.Text = string.Empty;
                        txtFactor.Text = string.Empty;
                        txtFactork.Text = string.Empty;
                        lbkg.Text = string.Empty;
                        lbqq.Text = string.Empty;
                        txtFactorSaco.Text = string.Empty;
                        lbPT.Text = "0";
                        lbUF.Text = "0";
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
        public void DtTarima()
        {
            try
            {
                if (Convert.ToString(txtCodTarima.Text) == "")
                {
                    txtCantida.Text = string.Empty;
                    lbkg.Text = string.Empty;
                    lbqq.Text = string.Empty;
                    txtTara.Text = string.Empty;
                    lbTarima.Text = string.Empty;
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._SEL_TARIMA(Convert.ToInt32(txtCodTarima.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        lbTarima.Text = Convert.ToString(row["NOMBRE"].ToString());
                        txtPTarima.Text = Convert.ToString(row["TARA"].ToString());
                        txtCantida.Text = Convert.ToString(row["SACOS"].ToString());
                        txtCantida_EditValueChanged(null, null);
                    }
                    
                    else
                    {
                        lbTarima.Text = string.Empty;
                        txtTara.Text = string.Empty;
                        txtCantida.Text = string.Empty;
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
        public void FechaDoc()
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                DataTable Dt;
                Dt = CDatos._SEL_FECHA_MOVIMIENTO();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtFecha.DateTime = Convert.ToDateTime(row["FECHA"].ToString());

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

            }
        }
        #endregion
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
        #region Crud
        private void InsEnc()
        {
            string Mensaje = "";
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_EXPRESWIN", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@lbIdentificadorEncT", lbIdentificadorEncT.Text);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
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
                {
                    txtNdocumento.Text = Mensaje;
                    lbIdentificadorEnc.Text = Mensaje;
                    InsEncDet(Convert.ToInt32(Mensaje)); }
                else { lbIdentificadorEnc.Text = "0"; }
            }

        }
        private void InsEncDet(int Id)
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_DETA_TRASLADO_EXPRESWIN", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;   
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", Id); 
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", cbProducto.SelectedValue);
                guardar.Parameters.AddWithValue("@ID_PRESEN_TRAS", lbPT.Text);
                guardar.Parameters.AddWithValue("@ID_UNIDAD_FAC", lbUF.Text );              
                guardar.Parameters.AddWithValue("@CANTIDAD", txtCantida.Text);
                guardar.Parameters.AddWithValue("@FACTOR", txtFactor.Text );
                guardar.Parameters.AddWithValue("@FACTORKG", txtFactork.Text );
                guardar.Parameters.AddWithValue("@REFERENCIA_DETA", Guid.NewGuid());
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);
                
                int rowsAffected = guardar.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                
                }
                else
                {                   
                    InsBascEnc();
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
        private void InsBascEnc()
        {
            string Mensaje = "";
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_BASCULA_ENCA_ES", Cnn.cn);
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
            }

        }
        private void InsBascDet(int Id)
        {
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("CRE_BASCULA_DETA_ESWIN", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@TPCAP", Convert.ToString(cbTipoCaptura));
                guardar.Parameters.AddWithValue("@ID_BASCULAENCA", Id);
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", lbIdentificadorEnc.Text);
                guardar.Parameters.AddWithValue("@ID_TARIMA", txtCodTarima.Text);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNdocumento.Text);
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", cbProducto.SelectedValue);
                guardar.Parameters.AddWithValue("@CANTIDAD", txtCantida.Text);
                guardar.Parameters.AddWithValue("@PESOTARIMA", Convert.ToDecimal(txtPTarima.Text));
                guardar.Parameters.AddWithValue("@PESOSACO", Convert.ToDecimal(txtPSaco.Text));
                guardar.Parameters.AddWithValue("@TARA", Convert.ToDecimal(txtTara.Text));
                guardar.Parameters.AddWithValue("@BRUTO", Convert.ToDecimal(txtBruto.Text));
                guardar.Parameters.AddWithValue("@NETO", Convert.ToDecimal(txtNeto.Text));
                guardar.Parameters.AddWithValue("@KILOGRAMOS", Convert.ToDecimal(txtKilogramos.Text));
                guardar.Parameters.AddWithValue("@QUINTALES", Convert.ToDecimal(txtQuintales.Text));
                guardar.Parameters.AddWithValue("@KILOGRAMOSP", Convert.ToDecimal(lbkg.Text));
                guardar.Parameters.AddWithValue("@QUINTALESP", Convert.ToDecimal(lbqq.Text));
                guardar.Parameters.AddWithValue("@GALONES", Convert.ToDecimal(txtGalones.Text));
                guardar.Parameters.AddWithValue("@PLACA", DBNull.Value);
                guardar.Parameters.AddWithValue("@MARCHAMOS", DBNull.Value);
                guardar.Parameters.AddWithValue("@CONTENEDOR", DBNull.Value);
                guardar.Parameters.AddWithValue("@USUARIO_CREA", LoginInfo.USUARIO);
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
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MensajeDT = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(MensajeDT, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                   btNuevo_Click(null, null);
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

        private void ProduccionJumbos_Load(object sender, EventArgs e)
        {
            btCerrarpuerto_Click_1(null, null);
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
            Dt();
            FechaDoc();
            Horatio();
            txtCodTarima_EditValueChanged(null,null);
        }
        private void limp()
        {
            txtIdentificador.Text = "0";
            Estado();
           //txtFecha.DateTime = DateTime.Now;
            txtNdocumento.Text = string.Empty;
            lbIdentificadorEncT.Text = "0";
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
            cbBodegaDestino.SelectedIndex = -1;
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
            btLeerPuerto.Enabled = true;
            btCaturaPeso.Enabled = true;
            btGuardar.Enabled = true;
            Producto();
            Estado();
            ZafraProducto();
            ZafraActual();
            TipoMovimiento();
        }
        private void txtCodbarra_TextChanged(object sender, EventArgs e)
        {
            limp();
            lbIdentificadorEncT.Text = txtCodbarra.Text;
           // BascEncDt();
            EncDt();
            DDt();
            this.ActiveControl = txtCodTarima;
            txtCodTarima.Focus();
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
                Dt = CDatos._SEL_EQUIPO_MEDICION(Convert.ToInt32(2));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                   

                    var withBlock = serialPort1;
                    //if (withBlock.IsOpen)
                    //{
                    //    withBlock.Close();
                    //}

                    withBlock.PortName = Convert.ToString(row["PUERTO"].ToString());
                    withBlock.BaudRate = Convert.ToInt32(row["BITS_POR_SEGUNDO"].ToString());
                    withBlock.DataBits = Convert.ToInt32(row["BITS_DATOS"].ToString());
                    withBlock.StopBits = System.IO.Ports.StopBits.One;
                    withBlock.Parity = System.IO.Ports.Parity.None;
                    withBlock.Handshake = System.IO.Ports.Handshake.None;
                    withBlock.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                    withBlock.ReadTimeout = 500;
                    withBlock.WriteTimeout = 500;
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

                if (Convert.ToString(cbTipoCaptura) == "")
                {
                    MessageBox.Show("SELECIONAR TIPO CAPTURA", "Mensaje", MessageBoxButtons.OK,
                     MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (txtLectura.Text == "0")
                    { txtPeso.Text = "0"; }

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

                        if (Convert.ToString(cbTipoCaptura) == "Bruto")
                        {
                            if ((Convert.ToString(txtTara.Text) == "0" && Convert.ToString(txtBruto.Text) == "0") || (Convert.ToString(txtTara.Text) == "0.00" && Convert.ToString(txtBruto.Text) == "0.00"))
                            {
                                string dtpeso, peso, pesof, pesof2;
                                int pesolen, pesoflen;

                                dtpeso = txtPeso.Text.Trim();
                                peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                                pesolen = peso.Length;
                                pesof = peso.Substring(0, (pesolen - 0));
                                pesoflen = pesof.Length;
                                pesof2 = pesof.Substring(0, (pesoflen - 0));

                                txtBruto.Text = Convert.ToString(Convert.ToDecimal(pesof2));
                            }
                            else if ((Convert.ToString(txtTara.Text) != "0" && Convert.ToString(txtBruto.Text) == "0") || (Convert.ToString(txtTara.Text) != "0.00" && Convert.ToString(txtBruto.Text) == "0.00"))
                            {
                                string dtpeso, peso, pesof, pesof2;
                                int pesolen, pesoflen;

                                dtpeso = txtPeso.Text.Trim();
                                peso = Regex.Replace(dtpeso, "([^0-9.])", "");
                                pesolen = peso.Length;
                                pesof = peso.Substring(0, (pesolen - 0));
                                pesoflen = pesof.Length;
                                pesof2 = pesof.Substring(0, (pesoflen - 0));

                                txtBruto.Text = Convert.ToString(Convert.ToDecimal(pesof2));

                                txtNeto.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtBruto.Text) - Convert.ToDecimal(txtTara.Text), 2));

                                if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                                { txtKilogramos.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text), 2)); }
                                else
                                { txtKilogramos.Text = "0"; }

                                if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                                { txtQuintales.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(46), 2)); }
                                else
                                { txtQuintales.Text = "0"; }


                                if (Convert.ToInt32(cbProducto.SelectedValue) != 5)
                                { txtGalones.Text = "0"; }
                                else
                                { txtGalones.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtNeto.Text) / Convert.ToDecimal(txtFactor.Text), 2)); }
                            }
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


                if (Convert.ToString(txtIdentificador.Text) == "0")
                {
                    InsEnc();
                     
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

        private void si_DataReceived(string accion)
        {
            try
            {
                txtLectura.Text = accion;
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
            txtFactorSaco.Text = "0";
            cbZafraProducto.SelectedIndex = -1;
            cbZafraActual.SelectedIndex = -1;
            cbTipoMovimiento.SelectedIndex = -1;
            cbConcepto.SelectedIndex = -1;
            cbEspecifico.SelectedIndex = -1;
            cbBodegaOrigen.SelectedIndex = -1;
            cbBodegaDestino.SelectedIndex = -1;
            
            txtCantida.Text = "0";
            txtLectura.Text = "0";
            txtPeso.Text = "0";
            txtPTarima.Text = "0";
            txtPSaco.Text = "0";
            txtTara.Text = "0";
            txtBruto.Text = "0";
            txtNeto.Text = "0";
            txtKilogramos.Text = "0";
            txtQuintales.Text = "0";
            txtGalones.Text = "0";
            lbkg.Text = "0";
            lbqq.Text = "0";
            lbIdentificadorEncT.Text = "0";
            lbIdentificadorEnc.Text = "0";
            lbPT.Text = "0";
            lbUF.Text = "0";

            Dt();
            txtCodTarima.Text = "26";
            txtCodTarima_EditValueChanged(null,null);
            FechaDoc();
        }

        private void txtCodTarima_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DtTarima();
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
               
                btLeerPuerto_Click(null, null);
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
        private void txtCantida_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCantida.Text) == "") { lbqq.Text = "0"; lbkg.Text = "0"; }
                else
                {
                    lbqq.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtFactor.Text) * Convert.ToDecimal(txtCantida.Text), 2));
                    lbkg.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtFactork.Text) * Convert.ToDecimal(txtCantida.Text), 2));
                    txtPSaco.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtFactorSaco.Text) * Convert.ToDecimal(txtCantida.Text), 2));
                    txtTara.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(txtPTarima.Text) + Convert.ToDecimal(txtPSaco.Text), 2));
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
            }

        }



        #region readonly 
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            this.Close();
        }
     


        private void btcerrar_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            this.Close();
        }

        private void btCerrarpuerto_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }
    }
}
