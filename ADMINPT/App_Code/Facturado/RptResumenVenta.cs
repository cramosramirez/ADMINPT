using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptResumenVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public RptResumenVenta(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string USUARIO)
        {
            InitializeComponent();
            rPT_VENTASRESUMENTableAdapter.Fill(dsFacturacion1.RPT_VENTASRESUMEN, ID_BODEGAO, FECHAD, FECHAH, USUARIO);
        }

    }
}
