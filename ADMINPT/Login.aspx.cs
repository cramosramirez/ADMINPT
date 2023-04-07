using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace ADMINPT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToString(txt_user.Text) == "") {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','!Ingrese Usuario !','error') </script>");
                    }
                else if (Convert.ToString(txt_pass.Text) == "") {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Ingrese Contraseña  !','error') </script>");
                        }
                else
                {
                    Conn.cn.Close();
                    Conn.cn.Open();
                    var Dt = new DataTable();
                    SqlDataAdapter Dadapter;
                    var iniciar = new SqlCommand("VIEW_INICIOSESION", Conn.cn);
                    iniciar.CommandType = CommandType.StoredProcedure;
                    iniciar.Parameters.AddWithValue("@USUARIO", txt_user.Text);
                    iniciar.Parameters.AddWithValue("@CLAVE", (txt_pass.Text)); //'CDats.CifrarClave'
                    iniciar.Parameters.AddWithValue("@ID_BODEP", Convert.ToInt32(cb_bodega.Value));
                    Dadapter = new SqlDataAdapter(iniciar);
                    Dadapter.Fill(Dt);
                    if (Dt.Rows.Count > 0)
                    {
                        DataRow row = Dt.Rows[0];
                        lb_msj.Text = "";
                        Session["ID_EMPRESA"] = row["ID_EMPRESA"].ToString();
                        Session["ID_MENUPERFIL"] = row["ID_MENUPERFIL"].ToString();
                        Session["USUARIO"] = row["NOMBRE"].ToString();
                        Session["ROLES"] = 4;
                      
                        Session["ID_BODEP"] = Convert.ToInt32(cb_bodega.Value);
                        Session["BODEP"] = Convert.ToString(cb_bodega.Text);
                        Session["BANDA_AZUCAR"] = Convert.ToBoolean(row["BANDA_AZUCAR"].ToString());
                        Session["FECHAHB"] = Convert.ToInt32(row["FECHAHB"].ToString());

                    }
                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! VERIFICAR CREDENCIALES Ó USUARIO NO TIENE ACCESO BODEGA !','error') </script>");
                        Session["ID_EMPRESA"] = null;
                        Session["ID_MENUPERFIL"] = null;
                        Session["USUARIO"] = null;
                        Session["ROLES"] = null;
                        Session["BANDA_AZUCAR"] = null;
                        Session["ID_BODEP"] = null;
                        Session["BODEP"] = null;
                        Session["FECHAHB"] = Convert.ToInt32(0);
                        Session.Abandon();

                    }
                    Conn.cn.Close();
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
                Conn.cn.Close();
                // Response.Cache.SetNoStore();
                if (Session["ID_MENUPERFIL"] != null)
                {
                   
                    Response.Redirect("~/Default.aspx");
                }
            }

        }

        
        protected void btinjiboa1_ServerClick(object sender, EventArgs e)
        {
            cb_bodega.Value = 29;
            txt_user.Text = string.Empty;
            txt_pass.Text = string.Empty;
            pcLogin.ShowOnPageLoad = true;
        }

        protected void btalmaconsa_ServerClick(object sender, EventArgs e)
        {
            cb_bodega.Value = 16;
            txt_user.Text = string.Empty;
            txt_pass.Text = string.Empty;
            pcLogin.ShowOnPageLoad = true;
        }

        protected void btalmapac_ServerClick(object sender, EventArgs e)
        {
            cb_bodega.Value = 17;
            txt_user.Text = string.Empty;
            txt_pass.Text = string.Empty;
            pcLogin.ShowOnPageLoad = true;
        }

        protected void btadminpt_ServerClick(object sender, EventArgs e)
        {
            cb_bodega.Value = 0;
            txt_user.Text = string.Empty;
            txt_pass.Text = string.Empty;
            pcLogin.ShowOnPageLoad = true;
        }

        protected void btalmapacreal_ServerClick(object sender, EventArgs e)
        {
            cb_bodega.Value = 30;
            txt_user.Text = string.Empty;
            txt_pass.Text = string.Empty;
            pcLogin.ShowOnPageLoad = true;
        }
    }
}