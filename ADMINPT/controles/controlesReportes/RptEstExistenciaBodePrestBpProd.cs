using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptEstExistenciaBodePrestBpProd : DevExpress.XtraReports.UI.XtraReport
    {
        public RptEstExistenciaBodePrestBpProd(DateTime FECHA_DESPACHO,int BODEMOV,int ID_TIPO_PROD)
        {
            InitializeComponent();
            rpT_EST_3_EXIST_PT_BODEGA_ZAFRA_PREST_BP_PRODTableAdapter1.Fill(dsEstrategicos1.RPT_EST_3_EXIST_PT_BODEGA_ZAFRA_PREST_BP_PROD, FECHA_DESPACHO, BODEMOV, ID_TIPO_PROD);
        }
        private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
