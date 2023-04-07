using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptResumenVentatpProducto : DevExpress.XtraReports.UI.XtraReport
    {
        public RptResumenVentatpProducto(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string USUARIO)
        {
            InitializeComponent();
            rpT_VENTASRESUMEN2TableAdapter1.Fill(dsFacturacion1.RPT_VENTASRESUMEN2, ID_BODEGAO, FECHAD, FECHAH, USUARIO);
        }

    }
}
