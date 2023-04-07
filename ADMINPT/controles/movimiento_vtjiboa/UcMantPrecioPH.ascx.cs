using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADMINPT.BL;
using ADMINPT.DL.Entidades;
using ADMINPT.DL.Modelo;
using DevExpress.Web;

namespace ADMINPT.controles.movimiento_vtjiboa
{
    public partial class UcMantPrecioPH : System.Web.UI.UserControl
    {
        private CENTRADA_SALIDA_ENCA Controlador = new CENTRADA_SALIDA_ENCA();
        private CENTRADA_SALIDA_DETA ControladorDt = new CENTRADA_SALIDA_DETA();
        char[] charsToTrim = { '*', ' ', '\'' };
        private void Inicializar()
        {
            UCEncabezado.Titulo = "FORMA DE PAGO";
            Nuevo();
        }
        protected void Page_Init(object sender, EventArgs e)
        { Inicializar();
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
        }
        private void Nuevo()
        {
            txtIdentificador.Text = string.Empty;
            txt_ndocument.Text = string.Empty;
            cbxTipoDocument.Value = "CF";
            cb_fmpago.SelectedIndex = -1;
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtNotaAbono.Text = "0";
            txtmCheque.Text = "0";
            txtmNotaAbono.Text = "0";
            txtTotal.Text = "0";
            txtBanco.Text = "";
            txtNCheque.Text = "";
            txtNCuenta.Text = "";
            ObtenerNDoc();
            FechaDoc();

            speCantidad.Value = 0; 
            txtFechaDespacho.Text = string.Empty;

            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = null;
            UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();
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

        private void DetFact()
        {

            DataSet DS_DT = new DataSet("DS_DT");
            DataTable DT = DS_DT.Tables.Add("DT");

            try
            {
                Conn.cn.Close();
                Conn.cn.Open();

                DT = CDats.SEL_ENTRADA_SALIDA_DETA(Convert.ToInt32(txtIdentificador.Text));
                speCantidad.Value = 0;
                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = null;
                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();

                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataSource = DT;
                UcListaENTRADA_SALIDA_DETA_VTJIBOAEMP._gridLista.DataBind();

                foreach (DataRow dr in DT.Rows)
                {

                   speCantidad.Value = Convert.ToInt32(speCantidad.Value) + Convert.ToInt32(dr["cantidad"]);



                }

                Conn.cn.Close();
            }
            catch (System.Data.OleDb.OleDbException sqlEx)
            {
                lbl_mensaje.Text = sqlEx.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cnph.Close();

            }
        }
        private void EncaFact()
        {
            try
            {
                string SALF;
                SALF = Convert.ToString(dteFecha.Date.ToString("MM/dd/yyyy"));


                DataTable Dt = new DataTable();
                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select c.nombrecli,c.direcli,c.registro,c.nit, d.nom_deptog, mm.nombre as municipio, a.efectivo,a.cheques,a.tarjeta " +
                    " from facturas a, clientes c, deptog d, municipi mm " +
                    " where a.cliente=c.cliente and d.deptog=c.depto and mm.codmuni=c.codmuni and" +
                    " SUBS(a.tipofact,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fecha={" + SALF + "}", Conn.cnph);
                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                   
                    txtEfectivo.Text = Convert.ToString(row["efectivo"].ToString());
                    txtCheque.Text = Convert.ToString(row["cheques"].ToString());
                    txtNotaAbono.Text = Convert.ToString(row["tarjeta"].ToString());
                    txtTotal.Text = Convert.ToString(Convert.ToDecimal(row["efectivo"]) + Convert.ToDecimal(row["cheques"]) + Convert.ToDecimal(row["tarjeta"]));
                    if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 1; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 2; }
                    else if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) == "0.00")
                    { cb_fmpago.Value = 3; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 4; }
                    else if (Convert.ToString(row["efectivo"]) != "0.00" & Convert.ToString(row["cheques"]) == "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 5; }
                    else if (Convert.ToString(row["efectivo"]) == "0.00" & Convert.ToString(row["cheques"]) != "0.00" & Convert.ToString(row["tarjeta"]) != "0.00")
                    { cb_fmpago.Value = 6; }
                    txtmCheque.Text = "0";
                    txtmNotaAbono.Text = "0";

                }
                else
                {
                    lbl_mensaje.Text = "";
                    lbl_mensaje.Visible = false;
                }
                Conn.cnph.Close();
            }
            catch (System.Data.OleDb.OleDbException sqlEx)
            {
                lbl_mensaje.Text = sqlEx.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cnph.Close();
            }
        }
        private void EncaNCH()
        {
            try
            {

                string SALF;
                SALF = Convert.ToString(dteFecha.Date.ToString("MM/dd/yyyy"));


                DataTable Dt = new DataTable();
                OleDbDataAdapter Dadapter;
                Conn.cnph.Close();
                Conn.cnph.Open();
                System.Data.OleDb.OleDbCommand Comando = new System.Data.OleDb.OleDbCommand("select rtrim(b.nombre) as banco, rtrim(a.cuentachk) as cuentachk, rtrim(a.numchk) as numchk, rtrim(a.nombrechk) as nombrechk" +
                    " from movchk a, bancos b " +
                    " where a.bancoc=b.banco and" +
                    " SUBS(a.tipodoc,1,2)=='" + Convert.ToString(cbxTipoDocument.SelectedItem.Value) + "' and  val(a.Numero)= " + txt_ndocument.Text + "  and a.fechachk={" + SALF + "}", Conn.cnph);
                Comando.CommandType = CommandType.Text;
                Dadapter = new OleDbDataAdapter(Comando);
                Dadapter.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtBanco.Text = Convert.ToString(row["banco"].ToString().Trim(charsToTrim));
                    txtNCuenta.Text = Convert.ToString(row["cuentachk"].ToString().Trim(charsToTrim));
                    txtNCheque.Text = Convert.ToString(row["numchk"].ToString().Trim(charsToTrim));

                }
                else
                {
                    lbl_mensaje.Text = "";
                    lbl_mensaje.Visible = false;
                }
                Conn.cnph.Close();
            }
            catch (System.Data.OleDb.OleDbException sqlEx)
            {
                lbl_mensaje.Text = sqlEx.Message;
                lbl_mensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.Visible = true;
            }
            finally
            {
                Conn.cnph.Close();
            }
        }
        public void ID_ES_ENCA()
        {
            try
            {

                Conn.cn.Close();
                Conn.cn.Open();
                DataTable Dt;
                Dt = CDats.VIEW_ID_ENTRADA_SALIDA_ENCA(Convert.ToDateTime(dteFecha.Text),Convert.ToInt32(txt_ndocument.Text));
                if (Dt.Rows.Count > 0)
                {
                    DataRow row = Dt.Rows[0];
                    txtIdentificador.Text = Convert.ToString(row["ID_ES_ENCA"].ToString());
                    txtNCheque.Text = Convert.ToString(row["FECHADESPACHO"].ToString());
                   
                    if (Convert.ToString(row["FECHADESPACHO"]) =="" )
                    { txtFechaDespacho.Text = string.Empty; }
                   else { txtFechaDespacho.Date = Convert.ToDateTime(row["FECHADESPACHO"]); }
                    
                }
                else
                {
                    txtIdentificador.Text = string.Empty;
                    txtFechaDespacho.Text = string.Empty;
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
        protected void ObtenerNDoc()
        {
            try
            {

            
            if (Convert.ToString(cbxTipoDocument.SelectedItem.Value) == "FA")
            {
                ENTRADA_SALIDA_ENCA lEntidadd = new CENTRADA_SALIDA_ENCA().ObtenerNDoc(Convert.ToInt32(2), Convert.ToInt32(Session["ID_BODEP"]));
                if (lEntidadd != null)
                {

                    txt_ndocument.Text = lEntidadd.ULT_NUM_ASIGNADO;

                }
                if (lEntidadd == null)
                {
                    txt_ndocument.Text = string.Empty;
                }
            }
            else if (Convert.ToString(cbxTipoDocument.SelectedItem.Value) == "CF")
            {
                ENTRADA_SALIDA_ENCA lEntidadd = new CENTRADA_SALIDA_ENCA().ObtenerNDoc(Convert.ToInt32(3), Convert.ToInt32(Session["ID_BODEP"]));
                if (lEntidadd != null)
                {

                    txt_ndocument.Text = lEntidadd.ULT_NUM_ASIGNADO;

                }
                if (lEntidadd == null)
                {
                    txt_ndocument.Text = string.Empty;
                }
            }

            }
            catch (Exception sqlEx)
            {

                lbl_mensaje.Text = sqlEx.Message;
                lbl_mensaje.Visible = true;
            }
        }
        private void InsEnc()
        {
            string Mensaje = "";
            try
            {
                Conn.cn.Close();
                if (Convert.ToString(txtFechaDespacho.Text) == string.Empty)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! NO SE HA PROCESADO EL DESPACHO DEL DOCUMENTO " + txt_ndocument.Text + " !','error') </script>"); }
                else { 
                Conn.cn.Close();
                Conn.cn.Open();
                SqlCommand guardar = new SqlCommand("UPD_FORMA_PAGO_ENC", Conn.cn);
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.AddWithValue("@ID_ES_ENCA", txtIdentificador.Text);
                guardar.Parameters.AddWithValue("@NUM_DOC", txt_ndocument.Text);
                if (Convert.ToString(cbxTipoDocument.Value) == "FA")
                { guardar.Parameters.AddWithValue("@ID_TIPO", Convert.ToInt32(2)); }
                else if (Convert.ToString(cbxTipoDocument.Value) == "CF")
                { guardar.Parameters.AddWithValue("@ID_TIPO", Convert.ToInt32(3)); }
                guardar.Parameters.AddWithValue("@ID_FMPAGO", Convert.ToDecimal(cb_fmpago.Value));
                guardar.Parameters.AddWithValue("@EFECTIVO", Convert.ToDecimal(txtEfectivo.Text));
                guardar.Parameters.AddWithValue("@CHEQUE", Convert.ToDecimal(txtCheque.Text));
                guardar.Parameters.AddWithValue("@NOTAABONO", Convert.ToDecimal(txtNotaAbono.Text));
                guardar.Parameters.AddWithValue("@TOTAL", Convert.ToDecimal(txtTotal.Text));
                guardar.Parameters.AddWithValue("@NCUENTA", Convert.ToString(txtNCuenta.Text));
                guardar.Parameters.AddWithValue("@NCHEQUE", Convert.ToString(txtNCheque.Text));
                guardar.Parameters.AddWithValue("@BANCO", Convert.ToString(txtBanco.Text));
                    guardar.Parameters.AddWithValue("@MCHEQUE", Convert.ToDecimal(txtmCheque.Text));
                    guardar.Parameters.AddWithValue("@MNOTAABONO", Convert.ToDecimal(txtmNotaAbono.Text));
                    SqlParameter msgparam = new SqlParameter("@msg", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                guardar.Parameters.Add(msgparam);
                int rowsAffected = guardar.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! " + Mensaje + " !','success') </script>");                        
                        Nuevo();
                    }
                else
                {
                    Mensaje = Convert.ToString(guardar.Parameters["@msg"].Value);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Error','! " + Mensaje + " !','error') </script>");
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
        protected void cbxTipoDocument_TextChanged(object sender, EventArgs e)
        {
            ObtenerNDoc();
        }

        protected void btImportar_Click(object sender, EventArgs e)
        {
            EncaFact();
            ID_ES_ENCA();
            EncaNCH();
            DetFact();

            System.Threading.Thread.Sleep(500);

        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            InsEnc();

            
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}