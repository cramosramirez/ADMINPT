using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.conta_rpt
{
    public partial class Rpt_TrasladoMorenojblocal : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TrasladoMorenojblocal(int ID_BODEP, int ID_BODEGAD, int ID_ZAFRA, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            contA_RPT_TRASLADO_MORENOJBLOCALTableAdapter1.Fill(dsReporteCont1.CONTA_RPT_TRASLADO_MORENOJBLOCAL, ID_BODEP, ID_BODEGAD, ID_ZAFRA, FECHAD, FECHAH);
        }

    }
}
