using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptNotaVJiboa : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaVJiboa(int ID_ES_ENCA)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCA_MELAZATableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZA, ID_ES_ENCA);
        }

    }
}
