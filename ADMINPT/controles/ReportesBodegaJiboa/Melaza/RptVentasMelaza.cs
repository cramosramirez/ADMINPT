using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza
{
    public partial class RptVentasMelaza : DevExpress.XtraReports.UI.XtraReport
    {
        public RptVentasMelaza(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH,string ID_CONCE,int ID_ZAFRA)
        {
            InitializeComponent();
            rpT_BODE_JB_MEL_VENTASTableAdapter1.Fill(dsMelaza1.RPT_BODE_JB_MEL_VENTAS,ID_BODEGAO,FECHAD,FECHAH,ID_CONCE,ID_ZAFRA);
        }

    }
}
