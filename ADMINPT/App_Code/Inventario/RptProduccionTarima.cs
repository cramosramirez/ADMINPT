using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProduccionTarima : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProduccionTarima(int ID_PRODUCTO, DateTime FECHA, string HORARIO)
        {
            InitializeComponent();
            // rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter1.Fill(dsInventario1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA, ID_PRODUCTO, FECHA, HORARIO);
            rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter3.Fill(dsInventario1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA, ID_PRODUCTO, FECHA, HORARIO);


        }

    }
}
