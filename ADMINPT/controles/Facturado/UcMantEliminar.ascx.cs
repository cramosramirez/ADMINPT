using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.Facturado
{
    public partial class UcMantEliminar : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "ELIMINAR DOCUMENTO DE SALIDA";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            txt_fechad.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
            FechaDoc();
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
                    txt_fechad.Value = Convert.ToDateTime(row["FECHA"].ToString());
                }
                else
                { txt_fechad.Text = string.Empty; }
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
                if (Convert.ToInt16(Session["FECHAHB"]) == 1) { txt_fechad.ClientEnabled = true; }
                else { txt_fechad.ClientEnabled = false; }
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            string Mensaje = "";
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("DEL_DOCUMENTO", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txt_fechad.Value));
                guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToInt32(txtNDocumento.Text));
                guardar.Parameters.AddWithValue("@MOTIVO_ANULACION", txtObservacion.Text);
                guardar.Parameters.AddWithValue("@ID_BODEGAO", Convert.ToInt32(cb_bodegaO.Value));
                guardar.Parameters.AddWithValue("@USUARIO_CREA", Session["USUARIO"].ToString());
                SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 1000);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + Mensaje + " !','error') </script>");
                }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    txt_fechad.Date = DateTime.Now;
                    txtNDocumento.Text = string.Empty;
                    txtObservacion.Text = string.Empty;
                   
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
    }
}