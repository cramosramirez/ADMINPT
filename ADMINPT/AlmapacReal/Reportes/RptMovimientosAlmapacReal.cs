using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.AlmapacReal.Reportes
{
    public partial class RptMovimientosAlmapacReal : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovimientosAlmapacReal(int ID_PRODUCTO,string ZAFRA,DateTime FECHAD,DateTime FECHAH)
        {
            InitializeComponent();
            rPT_MOVIMIENTOS_ALMAPAC_REALTableAdapter.Fill(dsReal1.RPT_MOVIMIENTOS_ALMAPAC_REAL, ID_PRODUCTO, ZAFRA, FECHAD, FECHAH);
        }

    }
}
