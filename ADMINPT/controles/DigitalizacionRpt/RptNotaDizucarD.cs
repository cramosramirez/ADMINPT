using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.DigitalizacionRpt
{
    public partial class RptNotaDizucarD : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNotaDizucarD(int ID_ES_ENCA)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCA_VTADIZUCARTableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_VTADIZUCAR, ID_ES_ENCA);
        }

    }
}
