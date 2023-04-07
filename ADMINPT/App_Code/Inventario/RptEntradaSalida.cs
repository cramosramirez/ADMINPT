using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptEntradaSalida : DevExpress.XtraReports.UI.XtraReport
    {
        public RptEntradaSalida(int ID_ES_ENCA)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCATableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA, ID_ES_ENCA);
        }

    }
}
