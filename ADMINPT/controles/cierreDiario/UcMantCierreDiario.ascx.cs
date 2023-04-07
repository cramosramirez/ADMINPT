using DevExpress.XtraReports.Web;
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
    public partial class UcMantCierreDiario : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "CIERRE DIARIO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_reporte.Visible = false;
            txt_fechad.Date = DateTime.Now;
            SdsListBgasOrigen.DataBind();
            cb_bodegaO.DataBind();
            cb_zafra.DataBind();
            sdscb_zafra.DataBind();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            if (ibog == 0)
            { cb_bodegaO.Enabled = true; }
            else { cb_bodegaO.Value = ibog; }
            Dgv_List.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            SdsListCierre.DataBind();
            Dgv_List.DataBind();
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txt_fechad.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccione una fecha !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }               
                else
                {
                    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Close();
                    cn.Open();
                    SqlCommand guardar = new SqlCommand("CRE_CIERRE_DIARIO", cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    guardar.Parameters.AddWithValue("@ID_BODEP", cb_bodegaO.Value);
                    guardar.Parameters.AddWithValue("@ANIOFISCAL", txt_anio.Text);
                    guardar.Parameters.AddWithValue("@ID_ZAFRA", cb_zafra.Value);
                    guardar.Parameters.AddWithValue("@FECHA", txt_fechad.Value);
                    guardar.Parameters.AddWithValue("@USU_CREA", Convert.ToString(Session["USUARIO"]));   
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.NVarChar, 500);
                    msgparam.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                       Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                        txt_fechad.Text = string.Empty;
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','error') </script>");
       
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
                Dgv_List.DataBind();
            }
        }

        protected void txt_fechad_ValueChanged(object sender, EventArgs e)
        {
            SdsListCierre.DataBind();
            Dgv_List.DataBind();
            if (Convert.ToString(txt_fechad.Text)==string.Empty)
            { } else { txt_anio.Text = txt_fechad.Date.ToString("yyyy"); }
        }
    }
}
