using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptCrudoFiscal : DevExpress.XtraReports.UI.XtraReport
    {
        public RptCrudoFiscal(DateTime FECHAD, DateTime FECHAH, int ID_BODEP, int ID_PRODUCTO)
        {
            InitializeComponent();
            rpT_KARDEX_CRUDO_FTableAdapter2.Fill(ds_KardexFiscal1.RPT_KARDEX_CRUDO_F, FECHAD, FECHAH, ID_BODEP, ID_PRODUCTO);
        }

    }
}
