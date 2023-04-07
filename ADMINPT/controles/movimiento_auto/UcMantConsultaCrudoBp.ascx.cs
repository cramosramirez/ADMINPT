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

namespace ADMINPT.controles.movimiento_auto
{

    public partial class UcMantConsultaCrudoBp : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] == null)
            { Response.Redirect("~/Login.aspx"); }

            UCBarraNavegacion.btn_buscar.Text = "Consultar";
            UCBarraNavegacion.btn_guardar.Text = "Cerrar Turno Banda";


            UCEncabezado.Titulo = "Consulta Produccion Azucar Cruda - Banda";
            UCBarraNavegacion.btn_buscar.Visible = true;
            UCBarraNavegacion.btn_guardar.Visible = false;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;

            if (Convert.ToBoolean(Session["BANDA_AZUCAR"]) == true)
            {
                UCBarraNavegacion.btn_fijarTurno.Visible =false;
                UCBarraNavegacion.btn_buscar.Enabled = true;
                cb_turno.Enabled = true;
                cb_diazafra.Enabled = true;
                cb_zafraact.Enabled = true;
                cb_concepto.Enabled = true;
                cb_articulo.Enabled = true;
                txt_factork.Enabled = true;
                txt_factorq.Enabled = true;

                UCBarraNavegacion.btn_guardar.Enabled = true;
                cb_zafra.Enabled = true;
            }
            if (Convert.ToBoolean(Session["BANDA_AZUCAR"]) == false)
            {
                UCBarraNavegacion.btn_fijarTurno.Visible = false;
                UCBarraNavegacion.btn_buscar.Enabled = true;
                cb_turno.Enabled = true;
                cb_TipoBascula.Enabled = false;
                cb_diazafra.Enabled = false;
                cb_zafraact.Enabled = false;
                cb_concepto.Enabled = false;
                cb_articulo.Enabled = true;
                cb_articulo.Enabled = false;
                txt_factork.Enabled = false;
                txt_factorq.Enabled = false;
                cb_diazafra.Enabled = true; 
                UCBarraNavegacion.btn_guardar.Enabled = false;
                cb_zafra.Enabled = false;
            }

            UCBarraNavegacion.btn_buscar.Text = "Consultar";
            UCBarraNavegacion.btn_guardar.Text = "Cerrar Turno Banda";

            UCBarraNavegacion.Actualizar_Click += _btn_actualizar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Buscar_Click += _btn_buscar_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.fijarTurno_Click += _btn_fijarTurno_Click;
            UCBarraNavegacion.actualizarTurno_Click += _btn_actualizarTurno_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;

            if (!IsPostBack)
            {
                sdscb_zafraact.DataBind();
                cb_zafraact.DataBind();
                cb_zafraact.SelectedIndex = 0;

                //cb_zafra.SelectedIndex = 0;

                sdscb_concepto.DataBind();
                cb_concepto.SelectedIndex = 0;
                sdscb_articulo.DataBind();
                cb_articulo.SelectedIndex = 1;
                sdscb_Diazafraact.DataBind();
                cb_diazafra.SelectedIndex = 0;
                cb_articulo.SelectedIndex = 1;
                //RecuperarDzTurno();

                cb_diazafra.SelectedIndex = 0;
                cb_turno.DataBind();
                RecuperarTurnoAct();
                cb_TipoBascula.DataBind();
                cb_TipoBascula.SelectedIndex = 0;

                sdscb_zafra.DataBind();
                cb_zafra.DataBind();
                cb_zafra.Text = RecuperarZafraAct();

                Dgv_ListM.DataBind();
            }
            else
            {

                //RecuperarReporteBpturno();
                Dgv_ListM.DataBind();
            }
        }

        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cb_zafra.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Zafra !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }
                else if (Convert.ToString(cb_diazafra.Text) == "")
                { //si_msje("Dia Zafra Requerida!!!");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Día Zafra !','error') </script>");
                }
                else if (Convert.ToString(cb_concepto.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Concepto !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else if (Convert.ToString(cb_articulo.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Articulo !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else
                {
                    Conn.cn.Close();
                    Conn.cn.Open();
                    SqlCommand guardar = new SqlCommand("CRE_PRODUCCIONCRUDO_BANDA", Conn.cn);
                    guardar.CommandType = CommandType.StoredProcedure;

                    guardar.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                    guardar.Parameters.AddWithValue("@ID_ZAFRAS", cb_zafra.Value);
                    guardar.Parameters.AddWithValue("@ID_DIA_ZAFRA", cb_diazafra.Value);
                    guardar.Parameters.AddWithValue("@DIAZAFRA", cb_diazafra.Value);
                    guardar.Parameters.AddWithValue("@FECHA", cb_diazafra.Text);
                    guardar.Parameters.AddWithValue("@ID_CONCEPTOES", cb_concepto.Value);
                    guardar.Parameters.AddWithValue("@CONCEPTO", cb_concepto.Text);
                    guardar.Parameters.AddWithValue("@ID_ARTICULO", cb_articulo.Value);
                    guardar.Parameters.AddWithValue("@ID_TURNO", cb_turno.Value);
                    guardar.Parameters.AddWithValue("@TURNO", cb_turno.Text);
                    guardar.Parameters.AddWithValue("@QUINTALES", txt_quintales.Value);
                    guardar.Parameters.AddWithValue("@KILOGRAMOS", txt_kilogramos.Text);
                    guardar.Parameters.AddWithValue("@OBSERVACION", txt_observacion.Text);
                    guardar.Parameters.AddWithValue("@USU_CREA", Session["USUARIO"]);
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                    msgparam.Direction = ParameterDirection.Output;
                    //SqlParameter msgparam1 = new SqlParameter("@idenc", SqlDbType.VarChar, 100);
                    //msgparam1.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    //guardar.Parameters.Add(msgparam1);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Dgv_ListM.DataBind();
                        //MensajeAccion(Mensaje, msgInformativo, msgActivo);
                        //idenc = Convert.ToString(guardar.Parameters["@idenc"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                        sdscb_zafraact.DataBind();
                        //                        cb_zafraact.SelectedIndex = 1;
                        sdscb_zafra.DataBind();
                        cb_zafra.SelectedIndex = 1;
                        sdscb_concepto.DataBind();
                        cb_concepto.SelectedIndex = 0;
                        sdscb_articulo.DataBind();
                        cb_articulo.SelectedIndex = 1;
                        sdscb_Diazafraact.DataBind();
                        cb_diazafra.SelectedIndex = 0;
                        cb_articulo.SelectedIndex = 1;
                        //RecuperarDzTurno();
                        Dgv_ListM.DataBind();
                        cb_diazafra.SelectedIndex = 0;
                        cb_turno.DataBind();
                        RecuperarTurnoAct();
                        RecuperarReporteBpDiario();
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
        private void RecuperarReporteBpDiario()
        {
           try
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Dadapter;
                Conn.cn.Close();
                Conn.cn.Open();
                var View = new SqlCommand("LIST_REPORTE_BPDIA_HIST", Conn.cn);
                View.CommandType = CommandType.StoredProcedure;
                View.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                View.Parameters.AddWithValue("@ID_ZAFRAS", Convert.ToInt32(cb_zafra.Value));
                View.Parameters.AddWithValue("@DIAZAFRA", Convert.ToInt32(cb_diazafra.Value));
                View.Parameters.AddWithValue("@ID_TURNO", Convert.ToInt32(cb_turno.Value));
                Dadapter = new SqlDataAdapter(View);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txt_observacion.Text="QUINTALES: "+ row["DESCARGA_QQ"].ToString()+" /  "+"KILOGRAMOS: "+ row["DESCARGA_KG"].ToString()+ " /  " + "RANGO"+" "+"DEL "+ row["MIN_ID"].ToString()+" "+"AL "+row["MAX_ID"].ToString()+" /  "+"CANTIDAD DESCARGAS: "+ row["TOTAL_DESCARGAS"].ToString();
                   
                    se_IdInicial.Value = row["MIN_ID"].ToString();
                    se_IdFinal.Value = row["MAX_ID"].ToString();
                    txt_kilogramos.Value = row["DESCARGA_KG"].ToString();
                    txt_quintales.Value = row["DESCARGA_QQ"].ToString();
                    txt_totalDescargas.Value = row["TOTAL_DESCARGAS"].ToString();




                }
                else
                {
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
        private string RecuperarZafraAct()
        {
            string zafra = "";
            try
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Dadapter;
                Conn.cn.Close();
                Conn.cn.Open();
                var View = new SqlCommand("CB_ZAFRA_ACT_BP", Conn.cn);
                View.CommandType = CommandType.StoredProcedure;
                //View.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                Dadapter = new SqlDataAdapter(View);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    zafra = row["NOMBRE_ZAFRA"].ToString();
                }
                else
                {
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
            return zafra;
        }
        private void RecuperarTurnoAct()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlDataAdapter Dadapter;
                Conn.cn.Close();
                Conn.cn.Open();
                var View = new SqlCommand("CB_TURNO_BP_ACT", Conn.cn);
                View.CommandType = CommandType.StoredProcedure;
                //View.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                Dadapter = new SqlDataAdapter(View);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    cb_turno.Text = row["TURNO"].ToString();
                }
                else
                {
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
        protected void _btn_buscar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cb_zafra.Text) == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Zafra !','error') </script>");  //si_msje("Zafra Requerida!!!");
            }
            else if (Convert.ToString(cb_diazafra.Text) == "")
            { //si_msje("Dia Zafra Requerida!!!");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Día Zafra !','error') </script>");
            }
            else if (Convert.ToString(cb_articulo.Text) == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Articulo !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
            }
            else if (Convert.ToString(cb_turno.Text) == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Turno !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
            }
            else
            {
                sds_ListM.DataBind();
                RecuperarReporteBpDiario();

            }
        }
        protected void _btn_actualizar_Click(object sender, EventArgs e)
        {
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
        protected void Unnamed_CustomFiltering(object sender, ListEditCustomFilteringEventArgs e)
        {
            string[] words = e.Filter.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] columns = new string[] { "DIAZAFRA", "FECHA" };
            e.FilterExpression = GroupOperator.And(words.Select(w =>
                GroupOperator.Or(
                    columns.Select(c =>
                        new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty(c), w)
                    )
                )
            )).ToString();
            e.CustomHighlighting = columns.ToDictionary(c => c, c => words);
        }
        protected void txt_tarima_TextChanged(object sender, EventArgs e)
        {
            try
            {

                txt_sacos.Text = Convert.ToString(Convert.ToDouble(txt_tarima.Text) * 30);
                txt_quintales.Text = "0";
                txt_kilogramos.Text = "0";
                if (Convert.ToString(txt_sacos.Text) == "")
                {
                    txt_quintales.Text = "0";
                    txt_kilogramos.Text = "0";
                }
                else
                {
                    txt_quintales.Text = Convert.ToString(Convert.ToDouble(txt_sacos.Text) * Convert.ToDouble(txt_factorq.Text));
                    txt_kilogramos.Text = Convert.ToString(Convert.ToDouble(txt_sacos.Text) * Convert.ToDouble(txt_factork.Text));
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
            }
        }
        protected void txt_sacos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txt_sacos.Text) == "")
                {
                    txt_quintales.Text = "0";
                    txt_kilogramos.Text = "0";
                }
                else
                {
                    txt_quintales.Text = Convert.ToString(Convert.ToDouble(txt_sacos.Text) * Convert.ToDouble(txt_factorq.Text));
                    txt_kilogramos.Text = Convert.ToString(Convert.ToDouble(txt_sacos.Text) * Convert.ToDouble(txt_factork.Text));
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
            }
        }
        protected void _btn_fijarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cb_turno.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Turno !','error') </script>");
                }
                else if (Convert.ToString(cb_diazafra.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Día Zafra !','error') </script>");
                }
                else
                {
                    Conn.cn.Close();
                    Conn.cn.Open();
                    SqlCommand guardar = new SqlCommand("UPD_TURNO_BP", Conn.cn);
                    guardar.CommandType = CommandType.StoredProcedure;

                    guardar.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                    guardar.Parameters.AddWithValue("@ID_ZAFRAS", cb_zafra.Value);
                    guardar.Parameters.AddWithValue("@ID_DIA_ZAFRA", cb_diazafra.Value);
                    guardar.Parameters.AddWithValue("@DIAZAFRA", cb_diazafra.Value);
                    //guardar.Parameters.AddWithValue("@FECHA", cb_diazafra.Text);
                    //guardar.Parameters.AddWithValue("@ID_CONCEPTOES", cb_concepto.Value);
                    //guardar.Parameters.AddWithValue("@CONCEPTO", cb_concepto.Text);
                    //guardar.Parameters.AddWithValue("@ID_ARTICULO", cb_articulo.Value);
                    guardar.Parameters.AddWithValue("@ID_TURNO", cb_turno.Value);
                    //guardar.Parameters.AddWithValue("@TURNO", cb_turno.Text);
                    guardar.Parameters.AddWithValue("@USU_ACT", Session["USUARIO"]);
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                    msgparam.Direction = ParameterDirection.Output;
                    //SqlParameter msgparam1 = new SqlParameter("@idenc", SqlDbType.VarChar, 100);
                    //msgparam1.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    //guardar.Parameters.Add(msgparam1);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Dgv_ListM.DataBind();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                        ////cb_zafra.SelectedIndex = -1;
                        ////cb_diazafra.SelectedIndex = -1;
                        ////cb_concepto.SelectedIndex = -1;
                        ////cb_articulo.SelectedIndex = -1;
                        ///
                        RecuperarTurnoAct();
                        RecuperarReporteBpDiario();
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
        protected void se_IdInicial_ValueChanged(object sender, EventArgs e)
        {
            //RecuperarReporteBpturno();
        }
        protected void se_IdFinal_ValueChanged(object sender, EventArgs e)
        {
            //RecuperarReporteBpturno();
        }
        protected void _btn_actualizarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cb_zafra.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Zafra !','error') </script>");  //si_msje("Zafra Requerida!!!");
                }
                else if (Convert.ToString(cb_diazafra.Text) == "")
                { //si_msje("Dia Zafra Requerida!!!");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Día Zafra !','error') </script>");
                }
                else if (Convert.ToString(cb_concepto.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Concepto !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else if (Convert.ToString(cb_articulo.Text) == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Seleccionar Articulo !','error') </script>"); // si_msje("Concepto Requerida!!!"); 
                }
                else
                {
                    Conn.cn.Close();
                    Conn.cn.Open();
                    SqlCommand guardar = new SqlCommand("UPD_REPORTES_BP_RANGO", Conn.cn);
                    guardar.CommandType = CommandType.StoredProcedure;

                    guardar.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
                    guardar.Parameters.AddWithValue("@ID_ZAFRAS", cb_zafra.Value);
                    guardar.Parameters.AddWithValue("@DIAZAFRA", cb_diazafra.Value);
                    guardar.Parameters.AddWithValue("@INICIAL", se_IdInicial.Value);
                    guardar.Parameters.AddWithValue("@FINAL", se_IdFinal.Value);
                    guardar.Parameters.AddWithValue("@ID_TURNO", cb_turno.Value);
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                    msgparam.Direction = ParameterDirection.Output;
                    //SqlParameter msgparam1 = new SqlParameter("@idenc", SqlDbType.VarChar, 100);
                    //msgparam1.Direction = ParameterDirection.Output;
                    guardar.Parameters.Add(msgparam);
                    //guardar.Parameters.Add(msgparam1);
                    int rowsAffected = guardar.ExecuteNonQuery();
                    string Mensaje = "";
                    if (rowsAffected > 0)
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Dgv_ListM.DataBind();
                        //MensajeAccion(Mensaje, msgInformativo, msgActivo);
                        //idenc = Convert.ToString(guardar.Parameters["@idenc"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    }
                    else
                    {
                        Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                        sdscb_zafraact.DataBind();
                        cb_zafraact.SelectedIndex = 1;
                        sdscb_zafra.DataBind();
                        cb_zafra.SelectedIndex = 1;
                        sdscb_concepto.DataBind();
                        cb_concepto.SelectedIndex = 0;
                        sdscb_articulo.DataBind();
                        cb_articulo.SelectedIndex = 1;
                        sdscb_Diazafraact.DataBind();
                        cb_diazafra.SelectedIndex = 0;
                        cb_articulo.SelectedIndex = 1;
                        //RecuperarDzTurno();
                        Dgv_ListM.DataBind();
                        cb_diazafra.SelectedIndex = 0;
                        cb_turno.DataBind();
                        //RecuperarReporteBpturno();
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
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            if (cb_turno.Text != "")
            {

                string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();
                if (HostName == "SV1-ITINJ03.injiboa.local")
                {

                    string _open = "window.open('/forms/movimiento_auto/wfViewReportesBP.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else if (HostName == "SV1-ITINJ01.injiboa.local")
                {

                    string _open = "window.open('/forms/movimiento_auto/wfViewReportesBP.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
                else
                {

                    string _open = "window.open('/ADMINPT/forms/movimiento_auto/wfViewReportesBP.aspx?idz='+'" + Convert.ToInt32(cb_zafra.Value) + "&iddz=" + Convert.ToInt32(cb_diazafra.Value) + "&idt=" + Convert.ToInt32(cb_turno.Value) + "&rpt=" + 1 + "', '_newtab');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                }
            }

        }
        protected void cb_diazafra_TextChanged(object sender, EventArgs e)
        {
            _btn_buscar_Click(null,null);
        }
        //private void RecuperarReporteBpturno()
        //{
        //    try
        //    {
        //        DataTable Dt = new DataTable();
        //        SqlDataAdapter Dadapter;
        //        Conn.cn.Close();
        //        Conn.cn.Open();
        //        var View = new SqlCommand("LIST_REPORTE_BPTURNO", Conn.cn);
        //        View.CommandType = CommandType.StoredProcedure;
        //        //View.Parameters.AddWithValue("@ID_EMPRESA", Session["ID_EMPRESA"]);
        //        Dadapter = new SqlDataAdapter(View);
        //        Dadapter.Fill(Dt);
        //        if (Dt.Rows.Count > 0)
        //        {
        //            DataRow row = Dt.Rows[0];
        //            se_IdInicial.Value = row["MIN_ID"].ToString();
        //            se_IdFinal.Value = row["MAX_ID"].ToString();
        //            txt_kilogramos.Value = row["DESCARGA_KG"].ToString();
        //            txt_quintales.Value = row["DESCARGA_QQ"].ToString();
        //            txt_totalDescargas.Value = row["TOTAL_DESCARGAS"].ToString();
        //        }
        //        else
        //        {
        //        }
        //        Conn.cn.Close();
        //    }
        //    catch (System.Data.SqlClient.SqlException sqlEx)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
        //    }
        //    catch (Exception sqlEx)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + sqlEx.Message + " !','error') </script>");
        //    }
        //    finally
        //    {
        //        Conn.cn.Close();
        //    }
        //}
        protected void cb_turno_TextChanged(object sender, EventArgs e)
        {
            RecuperarReporteBpDiario();
        }
    }

}
