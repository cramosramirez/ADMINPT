using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_TrasladoInterno : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TrasladoInterno(int ID_PRODUCTO, DateTime FECHA, int ID_ZAFRA_PROD)
        {
            InitializeComponent();
            this.veW_BASCULA_CONTROL_SALDOTableAdapter1.Fill(this.dsBascula1.VEW_BASCULA_CONTROL_SALDO, ID_PRODUCTO, FECHA, ID_ZAFRA_PROD);
            //this.rPT_BASCULA_ENCA_ES_PESOSTableAdapter.Fill(this.dsBascula1.RPT_BASCULA_ENCA_ES_PESOS, ID_BASCULAENCA);
        }

    }
}
