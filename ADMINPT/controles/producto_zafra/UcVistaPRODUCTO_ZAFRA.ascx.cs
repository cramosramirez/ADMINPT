using DevExpress.Data.Filtering;
using DevExpress.Web;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.producto_zafra
{

    public partial class UcVistaPRODUCTO_ZAFRA : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCEncabezado.Titulo = "CONFIGURACION PRODUCTO ZAFRA";

            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;


            if (!IsPostBack)
            {

               //RecuperarDt();
                cb_zafraProduccion.DataBind();
                cb_zafraTraslado.DataBind();
                cb_zafraVenta.DataBind();
                cb_zafraProduccion.DataBind();
            }
            else
            {
                //cb_zafraProduccion.DataBind();
                //cb_zafraTraslado.DataBind();
                //cb_zafraVenta.DataBind();
                //cb_zafraProduccion.DataBind();
            }
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
            //Mensaje1.lbl_mensaje.Text = "ENTRO AL GUARDAR";
            //Mensaje1.lbl_mensj.Text = "ENTRO AL GUARDAR";
        }

        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cb_producto.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Tarima !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }
                //else if (Convert.ToString(cb_zafraTraslado.Text) == "")
                //{ //si_msje("Dia Zafra Requerida!!!");
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Jumbo !','error') </script>");
                //}
                //else if (Convert.ToString(cb_zafraVenta.Text) == "")
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Translado CE5 Dizucar !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                //}
                //else if (Convert.ToString(cb_zafraProduccion.Text) == "")
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Translado Interno !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                //}
                else
                {
                    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Close();
                    cn.Open();
                    SqlCommand guardar = new SqlCommand("CRE_PRODUCTO_ZAFRA", cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    guardar.Parameters.AddWithValue("@ID_PRODUCTO", cb_producto.Value);
                    if (Convert.ToString(cb_zafraTraslado.Text) == "") { guardar.Parameters.AddWithValue("@ID_ZAFRA_TRASLADO", DBNull.Value); }
                    else { guardar.Parameters.AddWithValue("@ID_ZAFRA_TRASLADO", cb_zafraTraslado.Value); }                    
                    if (Convert.ToString(cb_zafraVenta.Text) == "") { guardar.Parameters.AddWithValue("@ID_ZAFRA_VENTA", DBNull.Value); }
                    else { guardar.Parameters.AddWithValue("@ID_ZAFRA_VENTA", cb_zafraVenta.Value); }                    
                    if (Convert.ToString(cb_zafraProduccion.Text) == "") { guardar.Parameters.AddWithValue("@ID_ZAFRA_PRODUCCION", DBNull.Value); }
                    else { guardar.Parameters.AddWithValue("@ID_ZAFRA_PRODUCCION", cb_zafraProduccion.Value); }                   

                    // parate para guardar la accion del usuario
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                    msgparam.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','error') </script>");
                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", @"ShowMessage('" + Mensaje + "','" + SiteMaster.MessageType.Error + "');", true);

                        //lblMensaje.Visible = true;
                        //lblMensaje.Text = "EL REGISTRO SE HA INGRESADO CORRECTAMENTE";
                        Dgv_List.DataBind();
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                        //cb_zafra.SelectedIndex = -1;
                        //lblMensaje.Visible = true;
                        //lblMensaje.Text = "EL REGISTRO SE HA INGRESADO CORRECTAMENTE";
                        cb_producto.Text = "";
                        cb_zafraTraslado.Text = "";
                        cb_zafraVenta.Text = "";
                        cb_zafraProduccion.Text = "";



                        cb_producto.DataBind();
                        cb_zafraTraslado.DataBind();
                        cb_zafraVenta.DataBind();
                        cb_zafraProduccion.DataBind();
                        Dgv_List.DataBind();

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

            }
        }
    }
}
