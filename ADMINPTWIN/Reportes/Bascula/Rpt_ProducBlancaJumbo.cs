using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_ProducBlancaJumbo : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ProducBlancaJumbo(int ID_PRODUCTO, DateTime FECHA)
        {
            InitializeComponent();
            this.rpT_PRODUCCION_AZUCAR_BLANCA_JUMBOTableAdapter1.Fill(this.dsBascula1.RPT_PRODUCCION_AZUCAR_BLANCA_JUMBO, ID_PRODUCTO, FECHA);
        }

    }
}
