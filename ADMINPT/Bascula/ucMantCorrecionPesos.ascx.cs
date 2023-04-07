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
    public partial class ucMantCorrecionPesos : System.Web.UI.UserControl
    {
        private void Inicializar()
        {
            UCEncabezado.Titulo = "CORRECCION PESO BASCULO";

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
            txt_ndocument.Text = string.Empty;
            txtIdentificadorDt.Text = string.Empty;
            txt_prod.Text = string.Empty;
            lbProd.Text = string.Empty;
            txt_tarima.Text = string.Empty;
            txt_tara.Text = string.Empty;
            txt_ftara.Text = string.Empty;
            txt_bruto.Text = string.Empty;
            txt_fbruto.Text = string.Empty;
            txt_neto.Text = string.Empty;
            txt_kilogramos.Text = string.Empty;
            txt_quintales.Text = string.Empty;
            txt_galones.Text = string.Empty;

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
                    txtIdentificadorDt.Text = Convert.ToString(row["ID_BASCULADETA"].ToString());
                    txt_prod.Text = Convert.ToString(row["NOMBRE_KARDEX"].ToString());
                    lbProd.Text = Convert.ToString(row["ID_PRODUCTO"].ToString());
                    txt_factor.Text = Convert.ToString(row["FACTOR"].ToString());
                    txt_tarima.Text = Convert.ToString(row["PESOTARIMA"].ToString());
                    txt_tara.Text = Convert.ToString(row["TARA"].ToString());
                    if(Convert.ToString(Convert.ToDateTime(row["FECHA_TARA"])) =="")
                    { txt_ftara.Text = string.Empty; } else { txt_ftara.Date = Convert.ToDateTime(row["FECHA_TARA"]); }                    
                    txt_bruto.Text = Convert.ToString(row["BRUTO"].ToString());
                    if (Convert.ToString(Convert.ToDateTime(row["FECHA_BRUTO"])) == "")
                    { txt_fbruto.Text = string.Empty; } else { txt_fbruto.Date = Convert.ToDateTime(row["FECHA_BRUTO"]); }                        
                    txt_neto.Text = Convert.ToString(row["NETO"].ToString());
                    txt_kilogramos.Text = Convert.ToString(row["KILOGRAMOS"].ToString());
                    txt_quintales.Text = Convert.ToString(row["QUINTALES"].ToString());
                    txt_galones.Text = Convert.ToString(row["GALONES"].ToString());
                }
                else
                {
                    txtIdentificadorDt.Text = string.Empty;
                    txt_prod.Text = string.Empty;
                    lbProd.Text = string.Empty;
                    txt_tarima.Text = string.Empty;
                    txt_tara.Text = string.Empty;
                    txt_ftara.Text = string.Empty;
                    txt_bruto.Text = string.Empty;
                    txt_fbruto.Text = string.Empty;
                    txt_neto.Text = string.Empty;
                    txt_kilogramos.Text = string.Empty;
                    txt_quintales.Text = string.Empty;
                    txt_galones.Text = string.Empty;
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
                if (txtIdentificador.Text == string.Empty)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Nº Documento Requerido !','error') </script>"); }
                else if (txtIdentificador.Text == string.Empty)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! Nº Documento Requerido !','error') </script>"); }
                else
                {
                    Conn.cn.Close();
                    Conn.cn.Open();
                    //SqlCommand guardar = new SqlCommand("CRE_ENTRADA_SALIDA_ENCA_TRASLADO_EXPRESWIN", Conn.cn);
                    SqlCommand guardar = new SqlCommand("UPD_CORRECCION_PESOS", Conn.cn);
                    guardar.CommandType = CommandType.StoredProcedure;
                    guardar.Parameters.AddWithValue("@ID_BASCULADETA", txtIdentificadorDt.Text);
                    guardar.Parameters.AddWithValue("@ID_ES_ENCA", txtIdentificador.Text);
                     guardar.Parameters.AddWithValue("PESOTARIMA", Convert.ToDecimal(txt_tarima.Text));
                    guardar.Parameters.AddWithValue("TARA",Convert.ToDecimal(txt_tara.Text));
                     guardar.Parameters.AddWithValue("BRUTO", Convert.ToDecimal(txt_bruto.Text));
                    guardar.Parameters.AddWithValue("NETO", Convert.ToDecimal(txt_neto.Text));
                    guardar.Parameters.AddWithValue("KILOGRAMOS", Convert.ToDecimal(txt_kilogramos.Text));
                    guardar.Parameters.AddWithValue("QUINTALES", Convert.ToDecimal(txt_quintales.Text));
                    guardar.Parameters.AddWithValue("GALONES", Convert.ToDecimal(txt_galones.Text));
                    if(Convert.ToString(txt_ftara.Text) !="")
                    { guardar.Parameters.AddWithValue("FECHA_TARA", Convert.ToDateTime(txt_ftara.Text)); }
                    else
                    { guardar.Parameters.AddWithValue("FECHA_TARA", DBNull.Value); }
                    if (Convert.ToString(txt_fbruto.Text) != "")
                    { guardar.Parameters.AddWithValue("FECHA_BRUTO", Convert.ToDateTime(txt_fbruto.Text)); }
                    else
                    { guardar.Parameters.AddWithValue("FECHA_BRUTO", DBNull.Value); }
                        
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

        protected void txt_bruto_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txt_bruto.Text) != 0 || Convert.ToDecimal(txt_tara.Text) != 0)
            {

                if (Convert.ToInt32(lbProd.Text) == 5)
                {
                    txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text), 2));
                    txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174), 2));
                    txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100), 2));
                    txt_galones.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(txt_factor.Text), 2));
                }
                else
                {
                    txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text), 2));
                    txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174), 2));
                    txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100), 2));
                    txt_galones.Text = "0";
                }
            }
            else
            {
                txt_neto.Text = "0";
                txt_kilogramos.Text = "0";
                txt_quintales.Text = "0";
                txt_galones.Text = "0";
            }

        }

        protected void txt_tara_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txt_bruto.Text) != 0 || Convert.ToDecimal(txt_tara.Text) != 0)
            {

                if (Convert.ToInt32(lbProd.Text) == 5)
                {
                    txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text), 2));
                    txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174), 2));
                    txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100), 2));
                    txt_galones.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(txt_factor.Text), 2));
                }
                else
                {
                    txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text), 2));
                    txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174), 2));
                    txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100), 2));
                    txt_galones.Text = "0";
                }
            }
            else
            {
                txt_neto.Text = "0";
                txt_kilogramos.Text = "0";
                txt_quintales.Text = "0";
                txt_galones.Text = "0";
            }

        }

        protected void txt_tarima_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(txt_tarima.Text) != 0)
            //{

            if (Convert.ToDecimal(txt_bruto.Text) != 0 ||  Convert.ToDecimal(txt_tara.Text) != 0)
             { 

            if (Convert.ToInt32(lbProd.Text)==5)
            {
                txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - (Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text)),2));
                txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174),2));
                txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100),2));
                txt_galones.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(txt_factor.Text),2));
            }
            else 
            {
                txt_neto.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_bruto.Text) - (Convert.ToDecimal(txt_tara.Text) + Convert.ToDecimal(txt_tarima.Text)),2));
                txt_kilogramos.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(2.174), 2));
                txt_quintales.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txt_neto.Text) / Convert.ToDecimal(100), 2));
                txt_galones.Text = "0";
            }
            }
            else
                {
                    txt_neto.Text = "0";
                    txt_kilogramos.Text = "0";
                    txt_quintales.Text = "0";
                    txt_galones.Text = "0";
                }
            //}


        }
    }
}