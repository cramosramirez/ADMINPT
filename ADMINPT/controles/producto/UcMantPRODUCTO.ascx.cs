using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.producto
{
    public partial class UcMantPRODUCTO : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "CATALOGO DE PRODUCTOS";
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
            UcListaPRODUCTO1.Visible = true;
            UcVistaPRODUCTO1.Visible = false;
            UcListaPRODUCTO1.CargarDatos();
        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaPRODUCTO1.Visible = true;
            UcListaPRODUCTO1.Visible = false;
        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaPRODUCTO1.Identificador = 0;
            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")
            {
                string Ret = UcVistaPRODUCTO1.Actualizar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaPRODUCTO1.Eliminar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }

        protected void UcListaPRODUCTO1_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaPRODUCTO1.Identificador = Identificador;
        }

    }
}