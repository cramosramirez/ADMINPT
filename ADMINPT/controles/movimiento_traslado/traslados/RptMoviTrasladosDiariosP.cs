using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimiento_traslado.traslados
{
    public partial class RptMoviTrasladosDiariosP : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMoviTrasladosDiariosP(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string ID_CONCE, int ID_BODEGAD)
        {
            InitializeComponent();
            rpT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CBTableAdapter1.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CB, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_BODEGAD);
            rPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMENTableAdapter.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_BODEGAD);
            rPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN2TableAdapter.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN2, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_BODEGAD);
            rPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOSTableAdapter.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_BODEGAD);
        }

    }
}
