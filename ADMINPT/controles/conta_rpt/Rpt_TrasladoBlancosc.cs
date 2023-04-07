using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.conta_rpt
{
    public partial class Rpt_TrasladoBlancosc : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TrasladoBlancosc(int ID_BODEP, int ID_BODEGAD, int ID_ZAFRA, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            contA_RPT_TRASLADO_BLANCOSCTableAdapter1.Fill(dsReporteCont1.CONTA_RPT_TRASLADO_BLANCOSC, ID_BODEP, ID_BODEGAD, ID_ZAFRA, FECHAD, FECHAH);
        }

    }
}
