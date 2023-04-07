using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_MovimientosBascula : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_MovimientosBascula(DateTime FECHAD, DateTime FECHAH, string HORARIO,int TIPO, int ID_PRODUCTO,int ID_BODEGAD)
        {
            InitializeComponent();
            rPT_MOVIMIENTOS_BASCULATableAdapter.Fill(dsReportes1.RPT_MOVIMIENTOS_BASCULA, FECHAD, FECHAH, HORARIO, TIPO, ID_PRODUCTO, ID_BODEGAD);
        }

    }
}
