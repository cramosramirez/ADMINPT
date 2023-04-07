using DevExpress.Utils.Commands;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMoviSalidas : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMoviSalidas(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            // rpT_SALIDAS_FAMILIA_BODEGATableAdapter1.Fill(dsFacturacion1.RPT_SALIDAS_FAMILIA_BODEGA_DT, FECHA);
            rpT_SALIDAS_FAMILIA_BODEGA_DTTableAdapter1.Fill(dsFacturacion1.RPT_SALIDAS_FAMILIA_BODEGA_DT, ID_BODEGAO, FECHAD, FECHAH);
           
        }

        private void xrTableCell12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //var amountValue = GetCurrentColumnValue("S_CANT");
            //if (Convert.ToString(amountValue) == "0.00")
            //{
            //    ((XRTableCell)sender).ForeColor = Color.Red;
            //}
        }
    }
}
