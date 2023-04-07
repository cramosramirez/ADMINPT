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
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ADMINPTWIN.TrasladoExpress
{
    public partial class AsignacionDocumento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AsignacionDocumento()
        {
            InitializeComponent();
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
        public void ViewDt()
        {
            try
            {
                if (Convert.ToString(txtFecha.Text) == "")
                {
                   
                }
                else
                {
                    Cnn.cn.Close();
                    Cnn.cn.Open();
                    DataTable Dt;
                    Dt = CDatos._VEW_BASCULA_CONTROL_SALDO(Convert.ToInt32(cbProducto.SelectedValue),Convert.ToDateTime(txtFecha.Text),Convert.ToInt32(cbZafraProducto.SelectedValue));
                    gvLista.DataSource = Dt;
                    gvLista.Refresh();
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
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void AsignacionDocumento_Load(object sender, EventArgs e)
        {
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            Producto();
            FechaDoc();
            ZafraProducto();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cbProducto.Text) == "")
            {
                MessageBox.Show("Producto Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtFecha.Text) == "")
            {
                MessageBox.Show("Fecha Requerida !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } else { 
            ViewDt();
        }
    }
        private void UpConSaldo()
        {
            string Mensaje = "";
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("UPD_BASCULA_CONTROL_SALDO_ASIGNARDOC", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", cbProducto.SelectedValue);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNota.Text);
                guardar.Parameters.AddWithValue("@USUARIO_ACT", LoginInfo.USUARIO);//this.ParentForm.Controls.Find("lb_usuario", true)[0].Text);
                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK,
              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ViewDt();
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
        private void btAsignarnota_Click(object sender, EventArgs e)
        {
            if(Convert.ToString(cbProducto.Text)=="")
            {
                MessageBox.Show("Producto Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtFecha.Text) == "")
            {
                MessageBox.Show("Fecha Requerida !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtNota.Text) == "")
            {
                MessageBox.Show("N° Nota Remision Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else { UpConSaldo(); }
            
        }
        private void UpConSaldoAP()
        {
            string Mensaje = "";
            try
            {

                Cnn.cn.Close();
                Cnn.cn.Open();
                SqlCommand guardar = new SqlCommand("UPD_BASCULA_CONTROL_SALDO_ASIGNARDOCAP", Cnn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@ID_PRODUCTO", cbProducto.SelectedValue);
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtFecha.Text));
                guardar.Parameters.AddWithValue("@NUM_DOC", txtNota.Text);
                guardar.Parameters.AddWithValue("@USUARIO_ACT", LoginInfo.USUARIO);//this.ParentForm.Controls.Find("lb_usuario", true)[0].Text);
                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK,
              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ViewDt();
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
        private void btAplicar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cbProducto.Text) == "")
            {
                MessageBox.Show("Producto Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtFecha.Text) == "")
            {
                MessageBox.Show("Fecha Requerida !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtNota.Text) == "")
            {
                MessageBox.Show("N° Nota Remision Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                UpConSaldoAP();
            }
        }
        public void RptPesos(int ID_PRODUCTO, DateTime FECHA, int ID_ZAFRA_PROD)
        {
            try
            {
                if (Convert.ToString(cbProducto.Text) == "" & Convert.ToString(txtFecha.Text)=="")
                { } else if (Convert.ToString(cbProducto.Text) != "" & Convert.ToString(txtFecha.Text) == "")
                { }
                else if (Convert.ToString(cbProducto.Text) != "" & Convert.ToString(txtFecha.Text) != "")
                {
                    Reportes.Bascula.Rpt_TrasladoInterno ReportT = new Reportes.Bascula.Rpt_TrasladoInterno(ID_PRODUCTO, FECHA, ID_ZAFRA_PROD);
                    Reportes.Visor form = new Reportes.Visor();
                    form._view_documento.DocumentSource = ReportT;
                    form.Show();
                   
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
        private void btReporte_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cbProducto.Text) == "")
            {
                MessageBox.Show("Producto Requerido !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else if (Convert.ToString(txtFecha.Text) == "")
            {
                MessageBox.Show("Fecha Requerida !!!", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else { 
            Reportes.Bascula.Rpt_TrasladoInternoCE5 ReportT = new Reportes.Bascula.Rpt_TrasladoInternoCE5(Convert.ToInt32(cbProducto.SelectedValue), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(cbZafraProducto.SelectedValue));
            Reportes.Visor form = new Reportes.Visor();
            form._view_documento.DocumentSource = ReportT;
            form.Show();
        }
        }

        private void btcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btImprimirNota_Click(object sender, EventArgs e)
        {

        }
    }
}
