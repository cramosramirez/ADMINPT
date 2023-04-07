using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptDetalleVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public RptDetalleVenta(int ID_BODEGAO,DateTime FECHAD,DateTime FECHAH, string USUARIO)
        {
            InitializeComponent();
            rpT_VENTASTableAdapter1.Fill(dsFacturacion1.RPT_VENTAS, ID_BODEGAO, FECHAD, FECHAH, USUARIO);
        }

    }
}
