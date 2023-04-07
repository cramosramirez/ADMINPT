using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptVtMelazaAcumulado : DevExpress.XtraReports.UI.XtraReport
    {
        public RptVtMelazaAcumulado(int ID_BODEP, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            rpT_VIEW_VENTA_MELAZA_ACTableAdapter1.Fill(dsFacturacion1.RPT_VIEW_VENTA_MELAZA_AC, ID_BODEP, FECHAD, FECHAH);
        }

    }
}
