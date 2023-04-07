using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptProducJumboBulto : DevExpress.XtraReports.UI.XtraReport
    {
        public RptProducJumboBulto(string HORARIO,DateTime FECHA,int ID_PRODUCTO)
        {
            InitializeComponent();
            //rpT_PRODUC_JUMBO_BULTOTableAdapter1.Fill(dsInventario1.RPT_PRODUC_JUMBO_BULTO, HORARIO, FECHA, ID_PRODUCTO);
            rpT_PRODUC_JUMBO_BULTOTableAdapter2.Fill(dsInventario1.RPT_PRODUC_JUMBO_BULTO, HORARIO, FECHA, ID_PRODUCTO);


        }
    }
}
