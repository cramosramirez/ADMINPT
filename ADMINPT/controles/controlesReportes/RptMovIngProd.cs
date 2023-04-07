using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMovIngProd : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovIngProd(int ID_FAMILIA, DateTime FECHA_INI ,DateTime FECHA_FIN)
        {
            InitializeComponent();
            rpT_EST_INGRESOS_PRODUCCIONTableAdapter1.Fill(dsMovEntSal1.RPT_EST_INGRESOS_PRODUCCION, ID_FAMILIA, FECHA_INI, FECHA_FIN);
        }
    }
}
