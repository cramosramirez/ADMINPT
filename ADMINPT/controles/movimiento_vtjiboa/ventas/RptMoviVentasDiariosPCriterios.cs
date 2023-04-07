using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimiento_traslado.traslados
{
    public partial class RptMoviVentasDiariosPCriterios : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMoviVentasDiariosPCriterios(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string ID_CONCE, int ID_PRODUCTO)
        {
            InitializeComponent();
            rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CBTableAdapter1.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CB, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_RESUMEN_CRITERIOSTableAdapter1.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_RESUMEN_CRITERIOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_PRODUCTO);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CRITERIOSTableAdapter1.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CRITERIOS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE, ID_PRODUCTO);
        }

    }
}
