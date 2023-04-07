using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProduccionTarimadt : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProduccionTarimadt(int ID_PRODUCTO, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            // rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter1.Fill(dsInventario1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA, ID_PRODUCTO, FECHA, HORARIO);
            // rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter3.Fill(dsInventario1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA, ID_PRODUCTO, FECHA, HORARIO);
            rpT_PRODUCCION_AZUCAR_BLANCA_TARIMADTTableAdapter1.Fill(dsInventario1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMADT, ID_PRODUCTO, FECHAD, FECHAH);

        }

    }
}
