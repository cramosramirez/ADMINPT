using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptNotaExpress : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaExpress(int ID_ES_ENCA)
        {
            InitializeComponent();
            // rpt.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZA, ID_ES_ENCA);
            rpT_ENTRADA_SALIDA_ENCA_TTableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_T, ID_ES_ENCA);
        }

    }
}
