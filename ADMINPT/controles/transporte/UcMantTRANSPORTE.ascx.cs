using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.transporte
{
     public partial class UcMantTRANSPORTE : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "MANTENIMIENTO TRANSPORTE";
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
            UcListaTRANSPORTE.Visible = true;
            UcVistaTRANSPORTE.Visible = false;
            UcListaTRANSPORTE.CargarDatos();


        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaTRANSPORTE.Visible = true;
            UcListaTRANSPORTE.Visible = false;


        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaTRANSPORTE.Identificador = 0;


            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")
            {
                string Ret = UcVistaTRANSPORTE.Actualizar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaTRANSPORTE.Eliminar();


                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }
        protected void UcListaTRANSPORTE_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaTRANSPORTE.Identificador = Identificador;
        }
    }
}
