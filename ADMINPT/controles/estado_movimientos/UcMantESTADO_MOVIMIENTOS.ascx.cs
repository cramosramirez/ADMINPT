using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.estado_movimientos
{
     public partial class UcMantESTADO_MOVIMIENTOS : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "MANTENIMIENTO ESTADO MOVIMIENTOS";
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
            UcListaESTADO_MOVIMIENTOS.Visible = true;
            UcVistaESTADO_MOVIMIENTOS.Visible = false;
            UcListaESTADO_MOVIMIENTOS.CargarDatos();


        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaESTADO_MOVIMIENTOS.Visible = true;
            UcListaESTADO_MOVIMIENTOS.Visible = false;


        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaESTADO_MOVIMIENTOS.Identificador = 0;


            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")
            {
                string Ret = UcVistaESTADO_MOVIMIENTOS.Actualizar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaESTADO_MOVIMIENTOS.Eliminar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }
        protected void UcListaESTADO_MOVIMIENTOS_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaESTADO_MOVIMIENTOS.Identificador = Identificador;
        }
    }
}
