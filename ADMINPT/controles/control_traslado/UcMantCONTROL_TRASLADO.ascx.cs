using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.control_traslado
{
    public partial class UcMantCONTROL_TRASLADO : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Cancelar_Click += _btn_cancelar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;
            UCBarraNavegacion.Reporte_Click += _btn_reporte_Click;
            UCBarraNavegacion.Buscar_Click += _btn_buscar_Click;

            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = false;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;

            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            UCEncabezado.Titulo = "CONTROL_TRASLADO";
            UCBarraOpciones.ModoMantenimiento = true;
            UCBarraOpciones.CargarOpciones();
            InicializarLista();
        }

        private void InicializarLista()
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, false);
            UcListaCONTROL_TRASLADO.Visible = true;
            UcVistaCONTROL_TRASLADO.Visible = false;
            UcListaCONTROL_TRASLADO.CargarDatos();
        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaCONTROL_TRASLADO.Visible = true;
            UcListaCONTROL_TRASLADO.Visible = false;
        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaCONTROL_TRASLADO.Identificador = 0;


            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")

            {


                string Ret = UcVistaCONTROL_TRASLADO.Actualizar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaCONTROL_TRASLADO.Eliminar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }

        protected void UcListaCONTROL_TRASLADO_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaCONTROL_TRASLADO.Identificador = Identificador;

        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            //string Ret = UcVistaCONTROL_TRASLADO.ActualizarVtaDizucar();

            //if (Ret == string.Empty)
            //{
            //    InicializarDetalle(false);
            //    UcVistaCONTROL_TRASLADO.Identificador = 0;
            //    UCBarraNavegacion.btn_nuevo.Visible = true;
            //    UCBarraNavegacion.btn_guardar.Visible = false;
            //    UCBarraNavegacion.btn_eliminar.Visible = false;
            //    UCBarraNavegacion.btn_cancelar.Visible = false;
            //    UCBarraNavegacion.btn_atras.Visible = false;
            //    InicializarLista();
            //    Response.Redirect("~/forms/wfMantENTRADA_SALIDA_DESPACHO.aspx");
            //}
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaCONTROL_TRASLADO.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = false;
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaCONTROL_TRASLADO.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = true;
            UCBarraNavegacion.btn_guardar.Visible = false;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = false;
            UCBarraNavegacion.btn_atras.Visible = false;
            UCBarraNavegacion.btn_reporte.Visible = false;
            InicializarLista();
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            string HostName = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName.ToString();

            string mv = "2";
            string TipoRpt = "3";


            if (HostName == "PORTAL")
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(UcVistaCONTROL_TRASLADO.txt_Identificador.Text) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-IT03")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(UcVistaCONTROL_TRASLADO.txt_Identificador.Text) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SV1-ITINJ03.injiboa.local")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(UcVistaCONTROL_TRASLADO.txt_Identificador.Text) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else if (HostName == "SVR_DSISTMASSV")
            {
                string _open = "window.open('/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(UcVistaCONTROL_TRASLADO.txt_Identificador.Text) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
            else
            {
                string _open = "window.open('/ADMINPT/forms/wfREPORTE.aspx?mv='+'" + mv + "&id=" + Convert.ToString(UcVistaCONTROL_TRASLADO.txt_Identificador.Text) + "&rpt=" + TipoRpt + "', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            }
        }
        protected void _btn_buscar_Click(object sender, EventArgs e)
        {

        }

    }
}
