using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADMINPT.controles
{
    public partial class UCCriterios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler Producto_TextChanged;

        public System.Web.UI.HtmlControls.HtmlTableRow ContInventario
        {
            get { return _ContInventario; }
            set { _ContInventario = value; }
        }
        public System.Web.UI.HtmlControls.HtmlTableRow ContFechas
        {
            get { return _ContFechas; }
            set { _ContFechas = value; }
        }
        public DevExpress.Web.ASPxComboBox cbxBodegaOrigen
        {
            get { return _cbxBodegaOrigen; }
            set { _cbxBodegaOrigen = value; }
        }
        public DevExpress.Web.ASPxComboBox cbxProducto
        {
            get { return _cbxProducto; }
            set { _cbxProducto = value; }
        }
        public DevExpress.Web.ASPxComboBox cbxPrestanciontras
        {
            get { return _cbxPrestanciontras; }
            set { _cbxPrestanciontras = value; }
        }
        public DevExpress.Web.ASPxComboBox cbxUnidad
        {
            get { return _cbxUnidad; }
            set { _cbxUnidad = value; }
        }
        public DevExpress.Web.ASPxDateEdit dteFechaInicial
        {
            get { return _dteFechaInicial; }
            set { _dteFechaInicial = value; }
        }
        public DevExpress.Web.ASPxDateEdit dteFechaFinal
        {
            get { return _dteFechaFinal; }
            set { _dteFechaFinal = value; }
        }
        protected void _cbxProducto_TextChanged(object sender, EventArgs e)
        {
            if (Producto_TextChanged != null)
            {
                Producto_TextChanged(sender, e);
            }
        }
    }
}