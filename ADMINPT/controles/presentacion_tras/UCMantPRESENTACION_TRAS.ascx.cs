using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.presentacion_tras
{
    public partial class UCMantPRESENTACION_TRAS : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "CATALOGO DE PRESENTACION TRASLADO";
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
            UCListaPRESENTACION_TRAS1.Visible = true;
            UCVistaPRESENTACION_TRAS1.Visible = false;
            UCListaPRESENTACION_TRAS1.CargarDatos();
        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UCVistaPRESENTACION_TRAS1.Visible = true;
            UCListaPRESENTACION_TRAS1.Visible = false;
        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UCVistaPRESENTACION_TRAS1.Identificador = 0;
            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")
            {
                string Ret = UCVistaPRESENTACION_TRAS1.Actualizar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UCVistaPRESENTACION_TRAS1.Eliminar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }

        protected void UCListaPRESENTACION_TRAS1_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UCVistaPRESENTACION_TRAS1.Identificador = Identificador;
        }

    }
}