using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_ProducBlancaTarima : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ProducBlancaTarima(int ID_PRODUCTO, DateTime FECHA)
        {
            InitializeComponent();
           // this.rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter1.Fill(this.dsBascula1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA, ID_PRODUCTO, FECHA);
            //this.rPT_BASCULA_ENCA_ES_PESOSTableAdapter.Fill(this.dsBascula1.RPT_BASCULA_ENCA_ES_PESOS, ID_BASCULAENCA);
        }

    }
}
