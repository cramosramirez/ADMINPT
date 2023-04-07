using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.ReportesBodegaJiboa.Melaza
{
    public partial class RptTrasladosMelazaAlmapac : DevExpress.XtraReports.UI.XtraReport
    {
        public RptTrasladosMelazaAlmapac(int ID_BODEGAO, int TPPRODUCTO, DateTime FECHAD, DateTime FECHAH, int ID_ZAFRA)
        {
            InitializeComponent();

            rpT_BODE_JB_MEL_TRASLADOSTableAdapter2.Fill(dsMelaza1.RPT_BODE_JB_MEL_TRASLADOS,ID_BODEGAO, TPPRODUCTO, FECHAD,FECHAH,ID_ZAFRA);
           
        }

    }
}
