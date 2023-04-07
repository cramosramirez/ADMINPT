using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptFacturado : DevExpress.XtraReports.UI.XtraReport
    {
        public RptFacturado(DateTime FECHAD, DateTime FECHAH,int TIPO)
        {
            InitializeComponent();
            // rpT_ENTRADA_SALIDA_ENCA_MELAZATableAdapter1.Fill(dsInventario1.RPT_ENTRADA_SALIDA_ENCA_MELAZA, ID_ES_ENCA);
            rPT_FACTURADOTableAdapter.Fill(dsFacturacion1.RPT_FACTURADO, FECHAD, FECHAH, TIPO);
        }

    }
}
