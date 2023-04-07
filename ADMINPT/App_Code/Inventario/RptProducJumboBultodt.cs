using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProducJumboBultodt : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProducJumboBultodt(int ID_PRODUCTO, DateTime FECHAD, DateTime FECHAH)
        {
            InitializeComponent();
            //rpT_PRODUC_JUMBO_BULTOTableAdapter1.Fill(dsInventario1.RPT_PRODUC_JUMBO_BULTO, HORARIO, FECHA, ID_PRODUCTO);
            // rpT_PRODUC_JUMBO_BULTOTableAdapter2.Fill(dsInventario1.RPT_PRODUC_JUMBO_BULTO, HORARIO, FECHA, ID_PRODUCTO);
            rpT_PRODUC_JUMBO_BULTODTTableAdapter1.Fill(dsInventario1.RPT_PRODUC_JUMBO_BULTODT, ID_PRODUCTO, FECHAD, FECHAH);

        }
    }
}
