using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.ReportesBodegaJiboa.VentaBM
{
    public partial class RptVentasBM : DevExpress.XtraReports.UI.XtraReport
    {
        public RptVentasBM(int ID_BODEGAO,DateTime FECHAD, DateTime FECHAH,string ID_CONCE, int ID_ZAFRA)
        {
            InitializeComponent();
            rPT_BODE_JB_AZC_VENTASTableAdapter.Fill(dsVentas1.RPT_BODE_JB_AZC_VENTAS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_ZAFRA);
        }

    }
}
