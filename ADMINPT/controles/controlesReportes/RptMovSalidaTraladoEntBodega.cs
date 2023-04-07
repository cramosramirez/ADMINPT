using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.controlesReportes
{
    public partial class RptMovSalidaTraladoEntBodega : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovSalidaTraladoEntBodega(int ID_BODEGAO,int ID_BODEGAD, int TPPRODUCTO, DateTime  FECHAD, DateTime FECHAH, string ZAFRAPRODUCTO)
        {
            InitializeComponent();
            rpT_SALIDAS_FAMILIA_BODEGATableAdapter1.Fill(dsMovEntSal1.RPT_SALIDAS_FAMILIA_BODEGA, ID_BODEGAO, ID_BODEGAD, TPPRODUCTO, FECHAD, FECHAH,ZAFRAPRODUCTO);
        }

    }
}
