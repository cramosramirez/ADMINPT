using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptEstExistenciaGeneral : DevExpress.XtraReports.UI.XtraReport
    {
        public RptEstExistenciaGeneral(DateTime FECHA_DESPACHO)
        {
            InitializeComponent();
            rpT_EST_1_EXIST_PTTableAdapter1.Fill(dsEstrategicos1.RPT_EST_1_EXIST_PT, FECHA_DESPACHO);
        }

    }
}
