using DevExpress.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimientos_registroTraslado
{
    public partial class UcViewTransito : System.Web.UI.UserControl
    {
       

        private void Inicializar()
        {
            UCEncabezado.Titulo = "REGISTRO DE INGRESO DE TRASLADO";
            UCBarraNavegacion.btn_nuevo.Visible = false;
            FechaDoc();
            if (Convert.ToInt16(Session["FECHAHB"]) == 1) { txtfechaing.ClientEnabled = true; }
            else { txtfechaing.ClientEnabled = false; }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            Inicializar();
      
        //gv.ExpandAll();
        }
            protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_MENUPERFIL"] != null) { }
            else { Response.Redirect("~/Login.aspx"); }
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
                    txtfechaing.Value = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    txtfechaing.Text = string.Empty;
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
        protected void gv_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandName == "AddBasket")
            { 
                ASPxGridView grid = (ASPxGridView)sender;
            object id = e.KeyValue;
            DateTime fdoc = Convert.ToDateTime(grid.GetRowValuesByKeyValue(id, "FECHA"));
                string ndoc_ = grid.GetRowValuesByKeyValue(id, "NUM_DOC").ToString();
            string cant = grid.GetRowValuesByKeyValue(id, "CANTIDAD").ToString();
            string prod = grid.GetRowValuesByKeyValue(id, "NOMBRE_KARDEX").ToString();

                txtfechadoc.Text = string.Empty;
                txtndoc.Text = string.Empty;
                txtcantida.Text = string.Empty;
                txtcantidaing.Text = string.Empty;
                observacion.Text = string.Empty;
                txtProducto.Text = string.Empty;

                txtProducto.Text = prod.Trim();
            txtfechadoc.Value = Convert.ToDateTime(fdoc);
            txtndoc.Text = ndoc_; 
            txtcantida.Text = cant;           
            txtcantidaing.Text = txtcantida.Text;

            pcLogin.ShowOnPageLoad = true;
            }
        }
      

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            { 
               
                Conn.cn.Close();
                 Conn.cn.Open();
                 SqlCommand guardar = new SqlCommand("CRE_REGISTRO_TRASLADO", Conn.cn);
                 guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@FECHA", Convert.ToDateTime(txtfechadoc.Text));
                 guardar.Parameters.AddWithValue("@NUM_DOC", Convert.ToString(txtndoc.Text));
                 guardar.Parameters.AddWithValue("@FECHA_RGTRASLADO", Convert.ToDateTime(txtfechaing.Text));//Convert.ToDateTime(txtfechaing.Text));
                 guardar.Parameters.AddWithValue("@CANTIDA_RGTRASLADO", Convert.ToDouble(txtcantidaing.Text));
                 guardar.Parameters.AddWithValue("@OBSERVACION_RGTRASLADO", Convert.ToString(observacion.Text));
                 SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 500);
                 msgparam.Direction = ParameterDirection.Output;
                 guardar.Parameters.Add(msgparam);
                 int rowsAffected = guardar.ExecuteNonQuery();
                 string Mensaje;
                 if (rowsAffected > 0)
                 {
                     Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                    //Sds_ListTrancito.DataBind();
                   // gv.DataBind();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");
                    pcLogin.ShowOnPageLoad = false;
                    txtfechadoc.Text = string.Empty;
                    txtndoc.Text = string.Empty;
                    txtcantida.Text = string.Empty;
                    txtcantidaing.Text = string.Empty;
                    observacion.Text = string.Empty;
                    txtProducto.Text = string.Empty;
                    Sds_ListTrancito.DataBind();
                    gv.DataBind();

                }
                 else
                 {
                     Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','error') </script>");
                   
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
                Sds_ListTrancito.DataBind();
                gv.DataBind();
            }
        }
        //
    }
}