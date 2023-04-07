using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMovimentos : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovimentos(DateTime FECHAD, DateTime FECHAH, int ID_CONCE, int ID_ESPECI)
        {
            InitializeComponent();
            rpT_ENTRADA_SALIDA_ENCA_MOVITableAdapter1.Fill(dsFacturacion1.RPT_ENTRADA_SALIDA_ENCA_MOVI, FECHAD, FECHAH, ID_CONCE, ID_ESPECI);
        }

    }
}
