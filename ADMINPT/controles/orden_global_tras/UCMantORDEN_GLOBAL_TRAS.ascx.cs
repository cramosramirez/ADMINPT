using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.orden_global_tras
{
    public partial class UCMantORDEN_GLOBAL_TRAS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }

        private void Inicializar()
        {
            UCEncabezado.Titulo = "ORDEN GLOBAL DE TRASLADO EXTERNO";
            UCBarraOpciones.ModoMantenimiento = true;
            UCBarraOpciones.CargarOpciones();
            InicializarLista();
        }

        private void InicializarLista()
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, false);
            UcListaORDEN_GLOBAL_TRAS.Visible = true;
            UcVistaORDEN_GLOBAL_TRAS.Visible = false;
            UcListaORDEN_GLOBAL_TRAS.CargarDatos();


        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaORDEN_GLOBAL_TRAS.Visible = true;
            UcListaORDEN_GLOBAL_TRAS.Visible = false;


        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaORDEN_GLOBAL_TRAS.Identificador = 0;


            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")

            {


                string Ret = UcVistaORDEN_GLOBAL_TRAS.Actualizar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaORDEN_GLOBAL_TRAS.Eliminar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }

        protected void UCListaORDEN_GLOBAL_TRAS_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaORDEN_GLOBAL_TRAS.Identificador = Identificador;

        }

    }
}