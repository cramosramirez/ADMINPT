using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles.tipo_producto
{
    public partial class UcMantTIPO_PRODUCTO : System.Web.UI.UserControl
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
            UCEncabezado.Titulo = "CATALOGO DE TIPO DE PRODUCTO";
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
            UcListaTIPO_PRODUCTO1.Visible = true;
            UcVistaTIPO_PRODUCTO1.Visible = false;
            UcListaTIPO_PRODUCTO1.CargarDatos();
        }

        private void InicializarDetalle(Boolean EsEdicion)
        {
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Nuevo, false);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Guardar, true);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Eliminar, EsEdicion);
            UCBarraOpciones.VerOpcion(UCBarraOpciones.NombreBotonesMantenimiento.Cancelar, true);
            UcVistaTIPO_PRODUCTO1.Visible = true;
            UcListaTIPO_PRODUCTO1.Visible = false;
        }

        protected void UCBarraOpciones_OpcionSeleccionada(string x)
        {
            if (x == "Nuevo")
            {
                InicializarDetalle(false);
                UcVistaTIPO_PRODUCTO1.Identificador = 0;
            }
            if (x == "Cancelar")
            {
                InicializarLista();
            }
            if (x == "Guardar")
            {
                string Ret = UcVistaTIPO_PRODUCTO1.Actualizar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
            if (x == "Eliminar")
            {
                string Ret = UcVistaTIPO_PRODUCTO1.Eliminar();
                if (Ret == string.Empty)
                {
                    InicializarLista();
                }
            }
        }

        protected void UcListaTIPO_PRODUCTO1_Editando(int Identificador)
        {
            InicializarDetalle(true);
            UcVistaTIPO_PRODUCTO1.Identificador = Identificador;
        }
       

    }
}