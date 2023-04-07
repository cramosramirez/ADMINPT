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

namespace ADMINPT.controles.movimientos_windows
{

     public partial class UcVistaMOVIMIENTOS_WINDOWS : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCEncabezado.Titulo = "CONFIGURACION MOVIMIENTOS EXPRESS WINDOWS";

            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;


            if (!IsPostBack)
            {
 

                RecuperarDt();
            }
            else
            {
                cb_produccionTarima.DataBind();
                cb_produccionJumbo.DataBind();
                cb_produccionCruada.DataBind();
                cb_produccionMelaza.DataBind();
                cb_transladoCe5Dizucar.DataBind();
               // cb_transladoInterno.DataBind();
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
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            //if (cb_turno.Text != "")
            //{

            //    string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();
            //    if (HostName == "SV1-ITINJ03.injiboa.local")
            //    {

            //        string _open = "window.open('/MBodega/WfProduccion/wfVisorProduccion.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            //    }
            //    else if (HostName == "SV1-IT03")
            //    {

            //        string _open = "window.open('/MBodega/WfProduccion/wfVisorProduccion.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            //    }
            //    else
            //    {

            //        string _open = "window.open('/scpf/MBodega/WfKardex/VisorKardex.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            //    }
            //}

        }

        private void RecuperarDt()
        {
            DataTable Dt = new DataTable();
            SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            SqlDataAdapter Dadapter;
            cn.Close();
            cn.Open();
            var View = new SqlCommand("VIEW_ENTRADA_SALIDA_DETA_T", cn);
            View.CommandType = CommandType.StoredProcedure;
            //View.Parameters.AddWithValue("@ID_CLIENTE", x);
            //View.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
            Dadapter = new SqlDataAdapter(View);
            Dadapter.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                DataRow row = Dt.Rows[0];
                txt_cod.Text = row["ID_MVWIN"].ToString();

                cb_produccionTarima.DataBind();
                cb_produccionTarima.Value = Convert.ToInt32(row["PRODUCCION_TARIMA"]);
                cb_produccionJumbo.DataBind();
                cb_produccionJumbo.Value = Convert.ToInt32(row["PRODUCCION_JUMBO"]);
                cb_produccionCruada.DataBind();
                cb_produccionCruada.Value = Convert.ToInt32(row["PRODUCCION_CRUDA"]);
                cb_produccionMelaza.DataBind();
                cb_produccionMelaza.Value = Convert.ToInt32(row["PRODUCCION_MELAZA"]);
                cb_transladoCe5Dizucar.DataBind();
                cb_transladoCe5Dizucar.Value = Convert.ToInt32(row["TRASLADO_CE5DIZUCAR"]);
                //cb_transladoInterno.DataBind();
                //cb_transladoInterno.Text = row["NOM_TRANSLADO_INTERNO"].ToString();
            }
            else
            {
            }
            cn.Close();

        }

        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cb_produccionTarima.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Tarima !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }
                else if (Convert.ToString(cb_produccionJumbo.Text) == "")
                { //si_msje("Dia Zafra Requerida!!!");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Jumbo !','error') </script>");
                }
                else if (Convert.ToString(cb_produccionCruada.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Crudo a Granel !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else if (Convert.ToString(cb_produccionMelaza.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Produccion Melaza !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else if (Convert.ToString(cb_transladoCe5Dizucar.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Translado CE5 Dizucar !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                //else if (Convert.ToString(cb_transladoInterno.Text) == "")
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Translado Interno !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                //}
                else
                {
                    SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                    cn.Close();
                    cn.Open();
                    SqlCommand guardar = new SqlCommand("UPD_MOVIMIENTOS_WINDOWS", cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    guardar.Parameters.AddWithValue("@PRODUCCION_TARIMA", cb_produccionTarima.Value);
                    guardar.Parameters.AddWithValue("@PRODUCCION_JUMBO", cb_produccionJumbo.Value);
                    guardar.Parameters.AddWithValue("@PRODUCCION_CRUDA", cb_produccionCruada.Value);
                    guardar.Parameters.AddWithValue("@PRODUCCION_MELAZA", cb_produccionMelaza.Value);
                    guardar.Parameters.AddWithValue("@TRASLADO_CE5DIZUCAR", cb_transladoCe5Dizucar.Value);
                    //guardar.Parameters.AddWithValue("@TRASLADO_INTERNO", cb_transladoInterno.Value);
                    guardar.Parameters.AddWithValue("@ID_MVWIN",txt_cod.Value);

                    // parate para guardar la accion del usuario
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                    msgparam.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                      Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                      Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                      // Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", @"ShowMessage('" + Mensaje + "','" + SiteMaster.MessageType.Error + "');", true);
                      
                //lblMensaje.Visible = true;
                //      lblMensaje.Text = "EL REGISTRO SE HA ACTUALIZADO CORRECTAMENTE";
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                       //cb_zafra.SelectedIndex = -1;
                       // lblMensaje.Visible = true;
                       //lblMensaje.Text = "EL REGISTRO SE HA ACTUALIZADO CORRECTAMENTE";

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


