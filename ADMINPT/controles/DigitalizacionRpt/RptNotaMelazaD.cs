using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.DigitalizacionRpt
{
    public partial class RptNotaMelazaD : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaMelazaD(int ID_ES_ENCA)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCA_MELAZADTableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZAD, ID_ES_ENCA);
        }
    }
}
