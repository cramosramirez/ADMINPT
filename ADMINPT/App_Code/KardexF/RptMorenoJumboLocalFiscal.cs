using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMorenoJumboLocalFiscal : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMorenoJumboLocalFiscal(DateTime FECHAD, DateTime FECHAH, int ID_BODEP, int ID_PRODUCTO)
        {
            InitializeComponent();
            rpT_KARDEX_MORENA_JUMBO_LOCAL_FTableAdapter1.Fill (ds_KardexFiscal1.RPT_KARDEX_MORENA_JUMBO_LOCAL_F, FECHAD, FECHAH, ID_BODEP, ID_PRODUCTO);
        }

    }
}
