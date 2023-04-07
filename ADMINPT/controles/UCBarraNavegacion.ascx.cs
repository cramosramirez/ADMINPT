using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UCBarraNavegacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler Guardar_Click;
        public event EventHandler Nuevo_Click;
        public event EventHandler Atras_Click;
        public event EventHandler Eliminar_Click;
        public event EventHandler Cancelar_Click;
        public event EventHandler Salir_Click;
        public event EventHandler Reporte_Click;
        public event EventHandler Buscar_Click;
        public event EventHandler ReporteConta_Click;
        public event EventHandler fijarTurno_Click;
        public event EventHandler actualizarTurno_Click;
        public event EventHandler Actualizar_Click;

        public DevExpress.Web.ASPxButton btn_guardar
        {
            get { return _btn_guardar; }
            set { _btn_guardar = value; }
        }
        public DevExpress.Web.ASPxButton btn_eliminar
        {
            get { return _btn_eliminar; }
            set { _btn_eliminar = value; }
        }
        public DevExpress.Web.ASPxButton btn_cancelar
        {
            get { return _btn_cancelar; }
            set { _btn_cancelar = value; }
        }
        public DevExpress.Web.ASPxButton btn_nuevo
        {
            get { return _btn_nuevo; }
            set { _btn_nuevo = value; }
        }
        public DevExpress.Web.ASPxButton btn_atras
        {
            get { return _btn_atras; }
            set { _btn_atras = value; }
        }
        public DevExpress.Web.ASPxButton btn_salir
        {
            get { return _btn_salir; }
            set { _btn_salir = value; }
        }
        public DevExpress.Web.ASPxButton btn_reporte
        {
            get { return _btn_reporte; }
            set { _btn_reporte = value; }
        }
        public DevExpress.Web.ASPxButton btn_reporteConta
        {
            get { return _btn_reporteConta; }
            set { _btn_reporteConta = value; }
        }
        public DevExpress.Web.ASPxButton btn_buscar
        {
            get { return _btn_buscar; }
            set { _btn_buscar = value; }
        }
        public DevExpress.Web.ASPxButton btn_fijarTurno
        {
            get { return _btn_fijarTurno; }
            set { _btn_fijarTurno = value; }
        }
        public DevExpress.Web.ASPxButton btn_actualizarTurno
        {
            get { return _btn_actualizarTurno; }
            set { _btn_actualizarTurno = value; }
        }


        protected void _btn_guardar_Click(object sender, EventArgs e)
        {
            if (Guardar_Click != null)
            {
                Guardar_Click(sender, e);
            }
        }
        protected void _btn_salir_Click(object sender, EventArgs e)
        {
            if (Salir_Click != null)
            {
                Salir_Click(sender, e);
            }
        }
        protected void _btn_cancelar_Click(object sender, EventArgs e)
        {
            if (Cancelar_Click != null)
            {
                Cancelar_Click(sender, e);
            }
        }
        protected void _btn_nuevo_Click(object sender, EventArgs e)
        {
            if (Nuevo_Click != null)
            {
                Nuevo_Click(sender, e);
            }
        }
        protected void _btn_actualizar_Click(object sender, EventArgs e)
        {
            if (Actualizar_Click != null)
            {
                Actualizar_Click(sender, e);
            }
        }
        protected void _btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Eliminar_Click != null)
            {
                Eliminar_Click(sender, e);
            }
        }
        protected void _btn_atras_Click(object sender, EventArgs e)
        {
            if (Atras_Click != null)
            {
                Atras_Click(sender, e);
            }
        }
        protected void _btn_reporte_Click(object sender, EventArgs e)
        {
            if (Reporte_Click != null)
            {
                Reporte_Click(sender, e);
            }
        }
        protected void _btn_reporteConta_Click(object sender, EventArgs e)
        {
            if (ReporteConta_Click != null)
            {
                ReporteConta_Click(sender, e);
            }
        }
        protected void _btn_buscar_Click(object sender, EventArgs e)
        {
            if (Buscar_Click != null)
            {
                Buscar_Click(sender, e);
            }
        }
        protected void _btn_fijarTurno_Click(object sender, EventArgs e)
        {
            if (fijarTurno_Click != null)
            {
                fijarTurno_Click(sender, e);
            }
        }
        protected void _btn_actualizarTurno_Click(object sender, EventArgs e)
        {
            if (actualizarTurno_Click != null)
            {
                actualizarTurno_Click(sender, e);
            }
        }
    }
}
