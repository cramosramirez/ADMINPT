using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProduccionMelaza : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProduccionMelaza(int ID_ZAFRA_PROD,DateTime  FECHA)
        {
            InitializeComponent();
            rpT_MELAZA_PRODUCCIONTableAdapter1.Fill(dsInventario1.RPT_MELAZA_PRODUCCION, ID_ZAFRA_PROD, FECHA);
        }

    }
}
