using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.cierreDiario
{
    public partial class UcMantProduciones : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "PROCESAR PRODUCIONES";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_reporte.Visible = false;
            FechaDoc();
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            cb_zafra.DataBind();
            sdscb_zafra.DataBind();
            cb_zafra.SelectedIndex = 1;
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        public void FechaDoc()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats._SEL_FECHA_PRODUCCION();
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txt_fecha.Value = Convert.ToDateTime(row["FECHA"].ToString());
                    //dteFecha.Value=Convert.ToDateTime("01/01/2021");
                }
                else
                {
                    txt_fecha.Text = string.Empty;
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
                if (Convert.ToInt16(Session["FECHAHB"]) == 1) { txt_fecha.ClientEnabled = true; }
                else { txt_fecha.ClientEnabled = false; }
            }
        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txt_fecha.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccione una fecha !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }
                else
                {
                    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Close();
                    cn.Open();
                    SqlCommand guardar = new SqlCommand("CRE_PRODUCCION_FECHA", cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    //guardar.Parameters.AddWithValue("@ID_BODEP", cb_bodegaO.Value);
                    //guardar.Parameters.AddWithValue("@ID_ZAFRA", cb_zafra.Value);
                    guardar.Parameters.AddWithValue("@FECHA", txt_fecha.Value);
                    guardar.Parameters.AddWithValue("@USU_CREA", Convert.ToString(Session["USUARIO"]));
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.Int, 8);
                    msgparam.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                        // Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! Cierre realizado correctamente !','success') </script>");
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! Ocurrio un error verificar !','error') </script>");
                    }

                }


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
                FechaDoc();
                //Dgv_List.DataBind();
            }
        }


    }
}
