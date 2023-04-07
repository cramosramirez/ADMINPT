using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.orden_global_saldo
{
    public partial class UcMantORDEN_GLOBAL_SALDO : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCBarraNavegacion.Nuevo_Click += _btn_nuevo_Click;
            UCBarraNavegacion.Guardar_Click += _btn_guardar_Click;
            UCBarraNavegacion.Eliminar_Click += _btn_eliminar_Click;
            UCBarraNavegacion.Cancelar_Click += _btn_cancelar_Click;
            UCBarraNavegacion.Atras_Click += _btn_atras_Click;
            UCBarraNavegacion.Salir_Click += _btn_salir_Click;

            if (!IsPostBack)
            {
                Inicializar();

            }
        }

        private void Inicializar()
        {
            UCEncabezado.Titulo = "AMPLIACION A ORDEN GLOBAL DE TRASLADO EXTERNO";
            UCBarraOpciones.ModoMantenimiento = true;
            UCBarraOpciones.CargarOpciones();
            InicializarLista();
            _btn_nuevo_Click(null,null);
        }

        private void InicializarLista()
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, false);
            UcListaORDEN_GLOBAL_SALDO.Visible = true;
            UcVistaORDEN_GLOBAL_SALDO.Visible = false;
            UcListaORDEN_GLOBAL_SALDO.CargarDatos();
          

        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaORDEN_GLOBAL_SALDO.Visible = true;
            UcListaORDEN_GLOBAL_SALDO.Visible = false;


        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            //if (x == "Nuevo")
            //{
            //    InicializarDetalle(false);
            //    UcVistaORDEN_GLOBAL_SALDO.Identificador = 0;


            //}
            //if (x == "Cancelar")
            //{
            //        Response.Redirect("~/forms/wfORDEN_GLOBAL_TRAS.aspx");
            //    // InicializarLista();
            //}
            //if (x == "Guardar")

            //{


            //    string Ret = UcVistaORDEN_GLOBAL_SALDO.Actualizar();


            //    if (Ret == string.Empty)
            //    {
            //        Response.Redirect("~/forms/wfORDEN_GLOBAL_TRAS.aspx");
            //        InicializarLista();
            //    }
            //}
            //if (x == "Eliminar")
            //{
            //    string Ret = UcVistaORDEN_GLOBAL_SALDO.Eliminar();


            //    if (Ret == string.Empty)
            //    {
            //        InicializarLista();
            //    }
            //}
        }

        protected void UCListaORDEN_GLOBAL_SALDO_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaORDEN_GLOBAL_SALDO.Identificador = Identificador;

        }

        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaORDEN_GLOBAL_SALDO.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;

        }
        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            string Ret = UcVistaORDEN_GLOBAL_SALDO.Actualizar();

            if (Ret == string.Empty)
            {
                InicializarDetalle(false);
                UcVistaORDEN_GLOBAL_SALDO.Identificador = 0;
                UCBarraNavegacion.btn_nuevo.Visible = true;
                UCBarraNavegacion.btn_guardar.Visible = false;
                UCBarraNavegacion.btn_eliminar.Visible = false;
                UCBarraNavegacion.btn_cancelar.Visible = false;
                UCBarraNavegacion.btn_atras.Visible = false;
                InicializarLista();
                Response.Redirect("~/forms/wfORDEN_GLOBAL_TRAS.aspx");
            }

        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaORDEN_GLOBAL_SALDO.Identificador = 0;
            UCBarraNavegacion.btn_nuevo.Visible = false;
            UCBarraNavegacion.btn_guardar.Visible = true;
            UCBarraNavegacion.btn_eliminar.Visible = false;
            UCBarraNavegacion.btn_cancelar.Visible = true;
            UCBarraNavegacion.btn_atras.Visible = false;
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            InicializarDetalle(false);
            UcVistaORDEN_GLOBAL_SALDO.Identificador = 0;
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

    }
}
