using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class RptProduccionTarimaUnidad : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProduccionTarimaUnidad(int ID_PRODUCTO,DateTime FECHA, string HORARIO)
        {
            InitializeComponent();
            this.rpT_PRODUCCION_AZUCAR_BLANCA_TARIMATableAdapter1.Fill(dsBascula1.RPT_PRODUCCION_AZUCAR_BLANCA_TARIMA,ID_PRODUCTO,FECHA,HORARIO);
               
        }

    }
}
