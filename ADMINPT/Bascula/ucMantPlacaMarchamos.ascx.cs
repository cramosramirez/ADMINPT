using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.Bascula
{
    public partial class ucMantPlacaMarchamos : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "CORRECCION DE PLACA, MARCHAMOS, CONTENEDOR";
       
            FechaDoc();
            if (Convert.ToInt16(Session["FECHAHB"]) == 1) { dteFecha.ClientEnabled = true; }
            else { dteFecha.ClientEnabled = false; }
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
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

        public void dtnot()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._VIEW_PRODUCTO_ENTSALID(Convert.ToDateTime(dteFecha.Text), Convert.ToString(txt_ndocument.Text), Convert.ToInt32(Convert.ToInt32(Session["ID_BODEP"])));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtIdentificador.Text = Convert.ToString(row["ID_ES_ENCA"].ToString());
                }
                else
                {
                    txtIdentificador.Text = string.Empty;
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
        private void Nuevo()
        {
            txtIdentificador.Text = string.Empty;
            txtIdentificadorBenc.Text = string.Empty;
            txtIdentificadorDt.Text = string.Empty;
            txt_ndocument.Text = string.Empty;
            txt_placa.Text = string.Empty;
            txt_marchamos.Text = string.Empty;
            txt_contenedor.Text = string.Empty;
            ck_tara.Value = 0;
            ck_bruto.Value = 0;
            ck_todos.Value = 0;
        }
        private void DtPlaca()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._VIEW_BASCULA_DETA_ES(Convert.ToInt32(txtIdentificador.Text));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtIdentificadorBenc.Text = Convert.ToString(row["ID_BASCULAENCA"].ToString());
                    txtIdentificadorDt.Text = Convert.ToString(row["ID_BASCULADETA"].ToString());

                    ck_tara.Value = Convert.ToBoolean(row["IMPT"].ToString());
                    ck_bruto.Value = Convert.ToBoolean(row["IMPB"].ToString());
                    ck_todos.Value = Convert.ToBoolean(row["IMPTD"].ToString());                 
                    
                    txt_placa.Text = Convert.ToString(row["PLACA"].ToString());
                    txt_marchamos.Text = Convert.ToString(row["MARCHAMOS"].ToString());
                    txt_contenedor.Text = Convert.ToString(row["CONTENEDOR"].ToString());
                }
                else
                {
                    txtIdentificadorBenc.Text = string.Empty;
                    txtIdentificadorDt.Text = string.Empty;
                    txt_placa.Text = string.Empty;
                    txt_marchamos.Text = string.Empty;
                    txt_contenedor.Text = string.Empty;
                    ck_tara.Value = 0;
                    ck_bruto.Value = 0;
                    ck_todos.Value = 0;
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
        protected void txt_ndocument_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_ndocument.Text.Trim()) != "")
            {
                dtnot();
                if (Convert.ToString(txtIdentificador.Text.Trim()) != "")
                { DtPlaca(); }
                else { Nuevo(); }
            }
            else
            {
                txtIdentificador.Text = string.Empty;
                Nuevo();
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
            FechaDoc();            
        }

        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(txtIdentificador.Text==string.Empty)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Nº Documento Requerido !','error') </script>"); }
                else if (txtIdentificador.Text == string.Empty)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Nº Documento Requerido !','error') </script>"); }
                else { 
                    Conn.cn.Close();
                Conn.cn.Open();
                //SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_EXPRESWIN", Conn.cn);
                SqlCommand guardar = new SqlCommand("UPD_BASCULA_DETA_ES_PLACA", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@ID_BASCULADETA", txtIdentificadorDt.Text);
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", txtIdentificador.Text);
                guardar.Parameters.AddWithValue("@PLACA", Convert.ToString(txt_placa.Text));
                guardar.Parameters.AddWithValue("@MARCHAMOS", Convert.ToString(txt_marchamos.Text));
                guardar.Parameters.AddWithValue("@CONTENEDOR", Convert.ToString(txt_contenedor.Text));
                    guardar.Parameters.AddWithValue("@ID_BASCULAENCA", Convert.ToInt32(txtIdentificadorBenc.Text));
                    guardar.Parameters.AddWithValue("@IMPT", Convert.ToBoolean(ck_tara.Value));
                    guardar.Parameters.AddWithValue("@IMPB", Convert.ToBoolean(ck_bruto.Value));
                    guardar.Parameters.AddWithValue("@IMPTD", Convert.ToBoolean(ck_todos.Value));
                    SqlParameter msgparam = new SqlParameter("@MSG", SqlDbType.VarChar, 500);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                string Mensaje = "";
                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@MSG"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    Nuevo();
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@MSG"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','error') </script>");

                }
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
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            _btn_nuevo_Click(null, null);
            Inicializar();
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
    }
}