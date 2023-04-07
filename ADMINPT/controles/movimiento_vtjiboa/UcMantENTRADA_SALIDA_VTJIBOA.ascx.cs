using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimiento_vtjiboa
{
    public partial class UcMantENTRADA_SALIDA_VTJIBOA : System.Web.UI.UserControl
    {
        DateTime dteFecha;
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Cancelar_Click += _btn_cancelar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporteDia_Click;
            if (!IsPostBack)
            {
                Inicializar();
                if (Convert.ToInt32(Session["ID_ES_ENCA"]) != 0) { _btn_reporte_Click(null, null); }
            }
            else { if (Convert.ToInt32(Session["ID_ES_ENCA"]) != 0) { _btn_reporte_Click(null, null); } }
        }
        private void Inicializar()
        {
            UCEncabezado.Titulo = "VENTA DE AZUCAR JIBOA";
            UCBarraOpciones.ModoMantenimiento = true;
            UCBarraNavegacion.btn_reporte.Visible = true;
            UCBarraOpciones.CargarOpciones();
            InicializarLista();
            _btn_nuevo_Click(null, null);
        }

        private void InicializarLista()
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, false);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Visible = false;
            UcListaENTRADA_SALIDA_ENCA_VTJIBOA.Visible = true;
            UcListaENTRADA_SALIDA_ENCA_VTJIBOA.CargarDatos();
        }
        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Visible = true;
            UcListaENTRADA_SALIDA_ENCA_VTJIBOA.Visible = false;
        }
        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            //if (x == "Nuevo")
            //{
            //    InicializarDetalle(false);
            //    UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = 0;
            //}
            //if (x == "Cancelar")
            //{
            //    Session["DT"] = null;
            //    InicializarLista();
            //}
            //if (x == "Guardar")

            //{
            //    string Ret = UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.ActualizarVtaJiboa();


            //    if (Ret == string.Empty)
            //    {
            //        InicializarLista();
            //    }

            //}
            //if (x == "Eliminar")
            //{
            //    //string Ret = UcVistaMOVIMIENTO_ENCA_TRASLADO.Eliminar();


            //    //if (Ret == string.Empty)
            //    //{
            //    //    InicializarLista();
            //    //}
            //}
        }

        protected void UcListaENTRADA_SALIDA_ENCA_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = Identificador;
        }
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;

        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            string Ret = UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.ActualizarVtaJiboa();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! "+ Ret + " !','error') </script>");
            if (Convert.ToString(Ret) != "0")
            {
                //InicializarDetalle(false);
                UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = 0;
                UCBarraNavegacion.btn_nuevo.Visible = true;
                UCBarraNavegacion.btn_guardar.Visible = false;
                UCBarraNavegacion.btn_eliminar.Visible = false;
                UCBarraNavegacion.btn_cancelar.Visible = false;
                UCBarraNavegacion.btn_atras.Visible = false;
                InicializarLista();
                Response.Redirect("~/forms/wfMantENTRADA_SALIDA_VTJIBOA.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! SE CREO CORRECTAMENTE' !','success') </script>");
            }
            else
            {
                //    // Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "<script> swal('Mensaje','! Ha ocurrido un error, por favor inténtelo de nuevo !','error') </script>");
            }
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaENTRADA_SALIDA_ENCA_VTJIBOA.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = true;
            UCBarraNavegacion.btn_guardar.Visible = false;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = false;
            UCBarraNavegacion.btn_atras.Visible = false;
            InicializarLista();
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();

            string mv = "1";
            string TipoRpt = "";

            TipoRpt = "5";
            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(Session["ID_ES_ENCA"]) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
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
                    dteFecha = Convert.ToDateTime(row["FECHA"].ToString());

                }
                else
                {
                    dteFecha = DateTime.Now;
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
        protected void _btn_reporteDia_Click(object sender, EventArgs e)
        {
            FechaDoc();
            var ibog = 0;
            ibog = Convert.ToInt32(Session["ID_BODEP"]);
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();
            string mv = "2";
            string TipoRpt = "";

            TipoRpt = "11";
            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-1") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-1") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-1") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-1") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(ibog) + "&f=" + Convert.ToString(dteFecha) + "&cn=" + Convert.ToString("14") + "&bd=" + Convert.ToString("0") + "&P=" + Convert.ToString("-1") + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }
    }
}