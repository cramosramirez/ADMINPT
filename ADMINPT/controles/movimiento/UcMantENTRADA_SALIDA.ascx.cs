using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.movimiento
{
        public partial class UcMantENTRADA_SALIDA : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "REGISTRO MOVIMIENTOS DE ENTRADA/SALIDA";
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
            UcVistaENTRADA_SALIDA_ENCA.Visible = false;
            UcListaENTRADA_SALIDA_ENCA.Visible = true;
            UcListaENTRADA_SALIDA_ENCA.CargarDatos();
        }
        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaENTRADA_SALIDA_ENCA.Visible = true;
            UcListaENTRADA_SALIDA_ENCA.Visible = false;
        }
        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaENTRADA_SALIDA_ENCA.Identificador = 0;
            }
            if (x == "Cancelar")
            {
                Session["DT"] = null;
                InicializarLista();
            }
            if (x == "Guardar")

            {
                string Ret = UcVistaENTRADA_SALIDA_ENCA.Actualizar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
               
            }
            if (x == "Eliminar")
            {
                //string Ret = UcVistaMOVIMIENTO_ENCA.Eliminar();


                //if (Ret == string.Empty)
                //{
                //    InicializarLista();
                //}
            }
        }

        protected void UcListaENTRADA_SALIDA_ENCA_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaENTRADA_SALIDA_ENCA.Identificador = Identificador;
        }

    }
}