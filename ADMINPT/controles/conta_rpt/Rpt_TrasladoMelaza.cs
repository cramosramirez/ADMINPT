using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.conta_rpt
{
    public partial class Rpt_TrasladoMelaza : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TrasladoMelaza(int ID_BODEP, int ID_BODEGAD, int ID_ZAFRA, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            cONTA_RPT_TRASLADO_MELAZATableAdapter.Fill(dsReporteCont1.CONTA_RPT_TRASLADO_MELAZA, ID_BODEP, ID_BODEGAD, ID_ZAFRA, FECHAD, FECHAH);
        }

    }
}
