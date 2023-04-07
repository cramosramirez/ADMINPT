using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza.TanqueNivel
{
    public partial class RptNivelTanqueMelaza : DevExpress.XtraReports.UI.XtraReport
    {
        public RptNivelTanqueMelaza(DateTime FECHA_INICIAL,DateTime FECHA_FINAL)
        {
            InitializeComponent();
            rPT_BODE_JB_MEL_NIVEL_TANQUETableAdapter.Fill(dsMelaza1.RPT_BODE_JB_MEL_NIVEL_TANQUE, FECHA_INICIAL, FECHA_FINAL);
        }
    }
}
