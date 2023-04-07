using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.DigitalizacionRpt
{
    public partial class RptNotaExpressD : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaExpressD(int ID_ES_ENCA)
        {
            InitializeComponent();
            // rpt.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZA, ID_ES_ENCA);
            rpT_ENTRADA_SALIDA_ENCA_TTableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_T, ID_ES_ENCA);
        }

    }
}
