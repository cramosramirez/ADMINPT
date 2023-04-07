using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace ADMINPTWIN.Reportes.Bascula
{
    public partial class Rpt_PesosBruto : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_PesosBruto(int ID_BASCULAENCA)
        {
            InitializeComponent();
            //this.rpT_GEN_PAGO_MECANIZACION_OPERADORWINexcliTableAdapter2.Fill(this.dts_Comprobantes1.RPT_GEN_PAGO_MECANIZACION_OPERADORWINexcli, NUMEMPR, FECHA, NEXCLUIDO, ID_MECOPERADOR, ANIO, MES, ESTADO, USUARIO);
            this.rPT_BASCULA_ENCA_ES_PESOSTableAdapter.Fill(this.dsBascula1.RPT_BASCULA_ENCA_ES_PESOS, ID_BASCULAENCA);
        }

    }
}
