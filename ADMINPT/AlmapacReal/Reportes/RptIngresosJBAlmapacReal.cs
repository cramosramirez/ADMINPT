using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.AlmapacReal.Reportes
{
    public partial class RptIngresosJBAlmapacReal : DevExpress.XtraReports.UI.XtraReport
    {
        public RptIngresosJBAlmapacReal(int ID_PRODUCTO, string ZAFRA, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            rpT_INGRESOSJB_ALMAPAC_REALTableAdapter1.Fill(dsReal1.RPT_INGRESOSJB_ALMAPAC_REAL, ID_PRODUCTO, ZAFRA, FECHAD, FECHAH);
        }

    }
}
