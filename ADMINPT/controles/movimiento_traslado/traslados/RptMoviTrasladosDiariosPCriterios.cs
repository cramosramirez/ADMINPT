using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimiento_traslado.traslados
{
    public partial class RptMoviTrasladosDiariosPCriterios : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMoviTrasladosDiariosPCriterios(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string ID_CONCE,int ID_PRODUCTO, int ID_BODEGAD)
        {
            InitializeComponent();
            rpT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CBTableAdapter1.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CB, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_BODEGAD);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN_CRITERIOSTableAdapter1.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN_CRITERIOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_PRODUCTO, ID_BODEGAD);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN2_CRITERIOSTableAdapter1.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_RESUMEN2_CRITERIOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_PRODUCTO, ID_BODEGAD);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CRITERIOSTableAdapter1.Fill(ds_trasladosview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_TRASLADOS_CRITERIOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_PRODUCTO, ID_BODEGAD);
        }

    }
}
