using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT.controles.movimiento_traslado.traslados
{
    public partial class RptMoviVentasDiariosP : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMoviVentasDiariosP(int ID_BODEGAO, DateTime FECHAD, DateTime FECHAH, string ID_CONCE)
        {
            InitializeComponent();
            rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CBTableAdapter1.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_CB, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE);
            rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_RESUMENTableAdapter2.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS_RESUMEN, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE);
        rpT_SALIDAS_FAMILIA_BODEGA_DT_VENTASTableAdapter2.Fill(ds_ventasview1.RPT_SALIDAS_FAMILIA_BODEGA_DT_VENTAS, ID_BODEGAO, FECHAD, FECHAH, ID_CONCE);
        }

    }
}
