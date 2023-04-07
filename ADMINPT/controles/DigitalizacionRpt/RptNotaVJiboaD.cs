using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.DigitalizacionRpt
{
    public partial class RptNotaVJiboaD : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaVJiboaD(int ID_ES_ENCA)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCA_MELAZATableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZA, ID_ES_ENCA);
        }

    }
}
