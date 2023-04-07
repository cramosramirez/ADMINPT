using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class TARIMA_BARRA : DevExpress.XtraReports.UI.XtraReport
    {
        public TARIMA_BARRA(int ID_TARIMA)
        {
            InitializeComponent();
            seL_TARIMATableAdapter1.Fill(dsReportes1.SEL_TARIMA, ID_TARIMA);
        }

    }
}
