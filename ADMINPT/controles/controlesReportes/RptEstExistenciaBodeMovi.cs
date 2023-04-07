using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptEstExistenciaBodeMovi : DevExpress.XtraReports.UI.XtraReport
    {
        public RptEstExistenciaBodeMovi(DateTime FECHA_INICIO, DateTime FECHA_FIN, int ID_ZAFRA, int ID_BODEP, int CONSOLIDADO, int ID_TIPO_PROD)
        {
            InitializeComponent();
            rpT_EST_4_EXIST_PT_BODEGA_ZAFRA_MOVIMIENTOSTableAdapter1.Fill(dsEstrategicos1.RPT_EST_4_EXIST_PT_BODEGA_ZAFRA_MOVIMIENTOS, FECHA_INICIO, FECHA_FIN, ID_ZAFRA, ID_BODEP, CONSOLIDADO, ID_TIPO_PROD);
        }
        private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        private void xrLabel29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
