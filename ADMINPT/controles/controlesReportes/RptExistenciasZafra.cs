using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptExistenciasZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public RptExistenciasZafra()
        {
            InitializeComponent();
            vieW_EXISTENCIA_ZAFRASTableAdapter1.Fill(ds_KardexZafra1.VIEW_EXISTENCIA_ZAFRAS);
        }

    }
}
