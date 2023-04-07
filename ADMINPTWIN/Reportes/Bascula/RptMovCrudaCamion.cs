using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class RptMovCrudaCamion : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovCrudaCamion(int ID_BODEP, DateTime FECHA, string HORARIO)
        {
            InitializeComponent();
            rpT_PROD_CRUDA_DIATableAdapter1.Fill(dsProd1.RPT_PROD_CRUDA_DIA, ID_BODEP, FECHA, HORARIO);
        }

    }
}
