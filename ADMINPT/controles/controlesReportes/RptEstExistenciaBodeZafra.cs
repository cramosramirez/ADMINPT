using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptEstExistenciaBodeZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public RptEstExistenciaBodeZafra(DateTime FECHA_INICIO, DateTime FECHA_FIN,int ID_BODEP)
        {
            InitializeComponent();
            
            rpT_EST_2_EXIST_PT_BODEGA_ZAFRATableAdapter1.Fill(dsEstrategicos1.RPT_EST_2_EXIST_PT_BODEGA_ZAFRA, FECHA_INICIO,FECHA_FIN, ID_BODEP);
        }

        private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
