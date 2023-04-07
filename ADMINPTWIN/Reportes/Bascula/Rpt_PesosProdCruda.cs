using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_PesosProdCruda : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_PesosProdCruda(int ID_BASCULAENCA)
        {
            InitializeComponent();
            rPT_PESOS_CRUDA_PRODTableAdapter.Fill(dsProd1.RPT_PESOS_CRUDA_PROD, ID_BASCULAENCA);
        }

    }
}
