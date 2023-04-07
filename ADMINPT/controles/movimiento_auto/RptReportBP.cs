using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimiento_auto
{
    public partial class RptReportBP : DevExpress.XtraReports.UI.XtraReport
    {
        public RptReportBP(int ID_EMPRESA, int ID_ZAFRAS, int DIAZAFRA, int ID_TURNO)
        {
            InitializeComponent();
            rPT_REPORTES_BP_HISTTableAdapter.Fill(dsReportesBP1.RPT_REPORTES_BP_HIST, ID_EMPRESA, ID_ZAFRAS, DIAZAFRA, ID_TURNO);
        }
    }
}
