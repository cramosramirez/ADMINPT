using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProduccionMelazadt : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProduccionMelazadt(int ID_PRODUCTO, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
          rpT_MELAZA_PRODUCCIONDTTableAdapter1.Fill(dsInventario1.RPT_MELAZA_PRODUCCIONDT, ID_PRODUCTO, FECHAD, FECHAH);
        }

    }
}
