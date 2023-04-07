using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPT
{
    public partial class RptMovBascula : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMovBascula(DateTime FECHAD, DateTime FECHAH, string HORARIO, int TIPO, int ID_PRODUCTO, int ID_BODEGAD)
        {
            InitializeComponent();
            rPT_MOVIMIENTOS_BASCULATableAdapter.Fill(dsMovEntSal1.RPT_MOVIMIENTOS_BASCULA,FECHAD, FECHAH, HORARIO, TIPO, ID_PRODUCTO, ID_BODEGAD);
        }

    }
}
